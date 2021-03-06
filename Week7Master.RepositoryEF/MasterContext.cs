using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    public class MasterContext : DbContext
    {
        //Elenco i DBset ovvero le tabelle/entità
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Docente> Docenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = CorsiMaster; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Corso>(new CorsoConfiguration());
            modelBuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());
            modelBuilder.ApplyConfiguration<Lezione>(new LezioneConfiguration());
            modelBuilder.ApplyConfiguration<Docente>(new DocenteConfiguration());
        }

    }
}
