using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Persistence
{
    class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            this.HasKey(p => p.IdProduto);

            this.Property(p => p.IdProduto)
                //.HasColumnType("int")
                .HasColumnName("cod_produto")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            this.Property(p => p.NomeProduto)
                //.HasColumnType("string")
                .HasColumnName("nome_produto")
                .HasMaxLength(50);


            this.Property(p => p.QtdProduto)
                //.HasColumnType("int")
                .HasColumnName("qtd_produto");
        }
    }
}
