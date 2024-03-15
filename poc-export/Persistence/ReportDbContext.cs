using poc_export.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace poc_export.Persistence
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options ) : base(options)
        {}

        public DbSet<User> User { get; set; }
        public DbSet<Sped> Speds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);

                user.Property(u => u.UserName).IsRequired().HasColumnType("varchar(20)");
                user.Property(u => u.BirthDate).IsRequired().HasColumnName("Birth_Date");
                user.Property(u => u.Email).IsRequired().HasColumnType("varchar(50)");
                user.Property(u => u.CreatedAt).HasColumnName("Created_at").IsRequired();
            });

            builder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), UserName = "John Doe", BirthDate = new DateTime(2004, 03, 12), Email = "john@doe" },
                new User { Id = Guid.NewGuid(), UserName = "Jane Smith", BirthDate = new DateTime(2020, 10, 12), Email = "jane@smith" },
                new User { Id = Guid.NewGuid(), UserName = "Alice Johnson", BirthDate = new DateTime(1980, 08, 1), Email= "alice@johnson" }
            );

            builder.Entity<Sped>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.F200);
                entity.Property(e => e.descr_obr);
                entity.Property(e => e.cpf_pes);
                entity.Property(e => e.F2);
                entity.Property(e => e.Identificador_unid);
                entity.Property(e => e.NumVend_Itv);
                entity.Property(e => e.ValorTot_Ven);
                entity.Property(e => e.Data_Ven);
            });
        }
    }
}
