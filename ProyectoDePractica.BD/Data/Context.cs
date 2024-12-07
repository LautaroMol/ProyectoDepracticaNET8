using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Especialidad> Especialidades {  get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Titulo> Titulos {  get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<TDocumento> TDocumentos { get; set; } 
        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t =>t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
