using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    [DataContract]
    [Table("TB_Curso")]
    public class Curso
    {
        [DataMember]
        [Key]
        [Required]
        public int IdCurso { get; set; }

        [DataMember]
        [StringLength(50)]
        [Required]
        public string NomeCurso { get; set; }
    }
}
