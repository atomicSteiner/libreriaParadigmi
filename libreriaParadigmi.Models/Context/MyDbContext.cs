using libreriaParadigmi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Libro> Libri { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=LAPTOP-URQH5S09;Database=master;User Id=paradigmi;Password=paradigmi;trusted_connection=true;");
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
