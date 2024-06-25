using Altalents.Commun.Enums;

using AlteaTools.Api.Core.Extensions;

namespace Altalents.IBusiness.DTO
{
    public class TypeCompteDto
    {
        public string Text => Value.GetDisplayName(false);
        public TypeUtilisateurEnum Value { get; set; }
    }
}
