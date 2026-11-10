using Microsoft.EntityFrameworkCore.Design;

namespace Mizon.Database;

internal sealed class MizonDatabaseContextFactory : IDesignTimeDbContextFactory<MizonDatabaseContext>
{
    public MizonDatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MizonDatabaseContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=Mizon;Trusted_Connection=True;TrustServerCertificate=True");

        return new MizonDatabaseContext(optionsBuilder.Options);
    }
}
