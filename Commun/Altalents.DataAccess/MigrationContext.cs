namespace Altalents.DataAccess
{
    public class MigrationContext : CustomDbContext
    {
        public MigrationContext() : base()
        {
            Database.SetCommandTimeout(240000);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=localhost\\MSSQLSERVER03;Database=Altalents;Trusted_Connection=True;");
    }
}
