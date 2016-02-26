using DB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Persistence
{
    public class Context : DbContext
    {
        public Context()
            :base("MyConstr")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMapping());
            modelBuilder.Configurations.Add(new CursoMapping());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

    }
}
