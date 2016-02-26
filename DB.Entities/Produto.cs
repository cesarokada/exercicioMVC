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
    [Table("TB_Produto")]
    public class Produto
    {
        [DataMember]
        [Key]
        public int IdProduto { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string NomeProduto { get; set; }

        [DataMember]
        [Required]
        public int QtdProduto { get; set; }

    }
}
