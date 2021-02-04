using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Teste_Scae.context
{
    public class BancoDados : DbContext
    {
        public DbSet<Models.Usuarios> Usuario { get; set; }

        public DbSet<Models.Enderecos> Endereco { get; set; }

        public BancoDados(DbContextOptions options):base(options){}

        public BancoDados()
        {

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("base");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Usuarios>().HasOne<Models.Enderecos>().WithMany().HasForeignKey(p => p.id);

                           
            modelBuilder.Entity<Models.Usuarios>().HasKey(c => c.id);
            modelBuilder.Entity<Models.Enderecos>().HasKey(d => d.idEnd);
            modelBuilder.Entity<Models.Usuarios>().HasData(new Models.Usuarios()
            {
                id = 1,
                nome = "Jose",
                end = "Nacionalista"

            });
        }

    }

}
