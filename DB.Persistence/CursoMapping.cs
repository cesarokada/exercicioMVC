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
    public class CursoMapping : EntityTypeConfiguration<Curso>
    {
        public CursoMapping()
        {
            this.HasKey(p => p.IdCurso);

            this.Property(p => p.IdCurso)
                //.HasColumnType("int")
                .HasColumnName("cod_curso")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            this.Property(p => p.NomeCurso)
                //.HasColumnType("string")
                .HasColumnName("nome_curso")
                .HasMaxLength(50);
        }
    }
}
