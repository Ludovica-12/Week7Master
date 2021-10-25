using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> modelBuilder)
        {
            modelBuilder.ToTable("Docente");  
            modelBuilder.HasKey(d => d.ID);
            modelBuilder.Property(d => d.Nome).IsRequired();
            modelBuilder.Property(d => d.Cognome).IsRequired();
            modelBuilder.Property(d => d.Email).IsRequired();
            modelBuilder.Property(d => d.Telefono).IsRequired().HasMaxLength(10);

            //Relazione Docente 1  ->  Lezioni n (uno a molti)
            modelBuilder.HasMany(d => d.Lezioni).WithOne(l => l.Docente).HasForeignKey(d => d.DocenteID);
        }
    }
}