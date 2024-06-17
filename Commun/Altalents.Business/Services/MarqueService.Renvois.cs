namespace Altalents.Business.Services
{
    // PARTIAL RENVOIS
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        public async Task DeleteMarqueRenvoisAsync(Guid marqueIdASupprimer, Guid marqueIdTravail, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueIdTravail, cancellationToken);
            await CheckMarqueExistAsync(marqueIdASupprimer, cancellationToken);

            IQueryable<MarqueRenvoisTemporaire> marquesTemporaires = DbContext.MarqueRenvoisTemporaires.Where(x => x.MarqueIdTravail == marqueIdTravail);

            List<Guid> marqueIds = await marquesTemporaires.Where(x => x.MarqueId1 == marqueIdASupprimer)
                                                           .Select(x => x.MarqueId2)
                                                           .ToListAsync(cancellationToken);

            await marquesTemporaires.Where(p => marqueIds.Contains(p.MarqueId1) && p.MarqueId2 == marqueIdASupprimer)
                                    .ExecuteDeleteAsync(cancellationToken);
            await marquesTemporaires.Where(p => marqueIds.Contains(p.MarqueId2) && p.MarqueId1 == marqueIdASupprimer)
                                    .ExecuteDeleteAsync(cancellationToken);

            await MajDateMajMarqueAsync(marqueIdTravail, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<Guid> InsertMarqueRenvoisAsync(Guid marqueIdAAjouter, Guid marqueIdTravail, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueIdTravail, cancellationToken);
            await CheckMarqueExistAsync(marqueIdAAjouter, cancellationToken);

            List<Guid> marqueIds = await GetMarquesRenvoisTemporairesIdsByMarqueIdTravailAsync(marqueIdTravail, cancellationToken);
            List<Guid> marqueIdsAAjouter = await GetMarquesRenvoisIdsByMarqueIdTravailAsync(marqueIdAAjouter, cancellationToken);
            marqueIds.AddRange(marqueIdsAAjouter);

            MarqueRenvoisTemporaire[] marqueRenvoisTemporaires = (from left in marqueIds
                                                                  from right in marqueIds
                                                                  where right != left
                                                                  select new MarqueRenvoisTemporaire
                                                                  {
                                                                      MarqueId1 = right,
                                                                      MarqueId2 = left,
                                                                      MarqueIdTravail = marqueIdTravail,
                                                                  }).ToArray();

            await PurgeMarquesRenvoisTemporairesByMarqueIdTravailAsync(marqueIdTravail, cancellationToken);
            await DbContext.MarqueRenvoisTemporaires.AddRangeAsync(marqueRenvoisTemporaires, cancellationToken);

            await MajDateMajMarqueAsync(marqueIdTravail, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return marqueIdTravail;
        }

        private async Task<List<Guid>> GetMarquesRenvoisTemporairesIdsByMarqueIdTravailAsync(Guid marqueIdTravail, CancellationToken cancellationToken)
        {
            List<MarqueRenvoisTemporaire> marquesRenvoisTemporairesActuels = await DbContext.MarqueRenvoisTemporaires.Where(x => x.MarqueIdTravail == marqueIdTravail)
                                                                                                                     .ToListAsync(cancellationToken);
            List<Guid> marqueIds = marquesRenvoisTemporairesActuels.Select(x => x.MarqueId1)
                                                                   .Union(marquesRenvoisTemporairesActuels.Select(x => x.MarqueId2))
                                                                   .Distinct()
                                                                   .ToList();
            if (!marqueIds.Contains(marqueIdTravail))
            {
                marqueIds.Add(marqueIdTravail);
            }

            return marqueIds;
        }

        public async Task<List<Guid>> GetMarquesRenvoisIdsByMarqueIdTravailAsync(Guid marqueIdTravail, CancellationToken cancellationToken, bool onlyPublie = false)
        {
            IQueryable<MarqueRenvois> marqueRenvoisQuery = DbContext.MarqueRenvois.Where(x => x.MarqueId1 == marqueIdTravail);
            if (onlyPublie)
            {
                marqueRenvoisQuery = marqueRenvoisQuery.Where(x => x.Marque2.Notices.Any(n => n.IsPublie));
            }
            List<Guid> marqueIds = await marqueRenvoisQuery
                                                                .Select(x => x.MarqueId2)
                                                                .ToListAsync(cancellationToken);
            if (!marqueIds.Contains(marqueIdTravail))
            {
                marqueIds.Add(marqueIdTravail);
            }

            return marqueIds;
        }

        public async Task PurgeMarquesRenvoisTemporairesByMarqueIdTravailAsync(Guid marqueIdTravail, CancellationToken cancellationToken)
        {
            await DbContext.MarqueRenvoisTemporaires.Where(p => p.MarqueIdTravail == marqueIdTravail)
                                                    .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task PurgeMarquesRenvoisByMarqueIdTravailAsync(Guid marqueIdTravail, CancellationToken cancellationToken)
        {
            List<Guid> marquesRenvoisIds = await GetMarquesRenvoisIdsByMarqueIdTravailAsync(marqueIdTravail, cancellationToken);
            await DbContext.MarqueRenvois.Where(p => marquesRenvoisIds.Contains(p.MarqueId1))
                                         .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task LoadMarqueRenvoisInMarqueRenvoisTemporairesAsync(Guid marqueId, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            await PurgeMarquesRenvoisTemporairesByMarqueIdTravailAsync(marqueId, cancellationToken);

            List<Guid> marqueIds = await DbContext.MarqueRenvois.Where(x => x.MarqueId1 == marqueId)
                                                                .Select(x => x.MarqueId2)
                                                                .ToListAsync(cancellationToken);
            marqueIds.Add(marqueId);

            List<MarqueRenvoisTemporaire> marquesRenvoisTemporaires = await DbContext.MarqueRenvois.Where(x => marqueIds.Contains(x.MarqueId1))
                                                                                                   .Select(x => new MarqueRenvoisTemporaire()
                                                                                                   {
                                                                                                       MarqueId1 = x.MarqueId1,
                                                                                                       MarqueId2 = x.MarqueId2,
                                                                                                       MarqueIdTravail = marqueId
                                                                                                   }).ToListAsync(cancellationToken);

            await DbContext.MarqueRenvoisTemporaires.AddRangeAsync(marquesRenvoisTemporaires, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task UpdateMarqueRenvoisAsync(Guid marqueIdTravail, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueIdTravail, cancellationToken);

            List<Guid> marqueIds = await GetMarquesRenvoisTemporairesIdsByMarqueIdTravailAsync(marqueIdTravail, cancellationToken);
            foreach (Guid marqueId in marqueIds)
            {
                await PurgeMarquesRenvoisByMarqueIdTravailAsync(marqueId, cancellationToken);
            }

            MarqueRenvois[] marqueRenvois = (from left in marqueIds
                                             from right in marqueIds
                                             where right != left
                                             select new MarqueRenvois
                                             {
                                                 MarqueId1 = right,
                                                 MarqueId2 = left,
                                             }).ToArray();

            await PurgeMarquesRenvoisTemporairesByMarqueIdTravailAsync(marqueIdTravail, cancellationToken);
            await DbContext.MarqueRenvois.AddRangeAsync(marqueRenvois, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<IQueryable<MarqueLightDto>> GetMarquesRenvoisByMarqueIdAsync(Guid marqueId, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            List<Guid> marquesRenvoisIds = await GetMarquesRenvoisTemporairesIdsByMarqueIdTravailAsync(marqueId, cancellationToken);
            marquesRenvoisIds.Remove(marqueId);

            return DbContext.Marques.Where(x => marquesRenvoisIds.Contains(x.Id))
                                    .ProjectTo<MarqueLightDto>(Mapper.ConfigurationProvider);
        }

        public async Task<List<MarqueLightDto>> GetMarquesAjoutablesMarqueRenvoisAsync(string text, Guid marqueId, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            IOrderedQueryable<Marque> query = GetMarquesFinaliseesQuery(text);
            List<MarqueLightDto> marquesSelectables = await query.ProjectTo<MarqueLightDto>(Mapper.ConfigurationProvider)
                                                                 .ToListAsync(cancellationToken);
            List<Guid> marqueIdsAExclure = await GetMarquesRenvoisTemporairesIdsByMarqueIdTravailAsync(marqueId, cancellationToken);
            marqueIdsAExclure.Add(marqueId);
            return marquesSelectables.Where(x => !marqueIdsAExclure.Contains(x.IdMarque)).OrderBy(x => x.ReferenceLugt).ToList();
        }

        public void PurgeMarquesRenvoisTemporaires()
        {
            DbContext.MarqueRenvoisTemporaires.Where(x => x.DateCrea.AddDays(1) < DateTime.Now).ExecuteDelete();
        }

        public async Task<MarqueNombreRenvoisDto> GetNombreMarqueAssociesByMarqueIdAsync(Guid marqueId, CancellationToken cancellationToken)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            int nombreRenvois = await DbContext.Marques.Where(x => x.Id == marqueId).Select(x => x.MarqueRenvois1.Count()).SingleAsync(cancellationToken);
            return new MarqueNombreRenvoisDto()
            {
                NombreRenvois = nombreRenvois
            };
        }
    }
}
