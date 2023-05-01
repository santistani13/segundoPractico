using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using segundoPractico.Controllers;
namespace segundoPractico.Data
{
    public class MvcNotebooksContext : DbContext
    {
        public MvcNotebooksContext (DbContextOptions<MvcNotebooksContext> options)
            : base(options)
        {
        }

        public DbSet<segundoPractico.Controllers.Notebook> Notebook { get; set; } = default!;

        public DbSet<segundoPractico.Controllers.Empresa> Empresa { get; set; } = default!;
        public DbSet<segundoPractico.Controllers.PaisOrigen> PaisOrigen { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Notebook>().HasMany(r => r.Empresas).WithOne(p => p.Notebook).HasForeignKey(p => p.NotebookId);
            modelBuilder.Entity<Notebook>().HasOne(r => r.PaisOrigen).WithOne(p => p.Notebook).HasForeignKey(p => p.NotebookId);
            modelBuilder.Entity<Notebook>().HasMany(data => data.Paises).withMany(r => r.Notebook).HasForeignKey(r => r.NotebookId);
        }

    }
}
