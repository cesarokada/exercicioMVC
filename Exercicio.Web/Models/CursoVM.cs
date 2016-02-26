﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercicio.Web.Models
{
    public class CursoVM
    {
        [Key]
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}