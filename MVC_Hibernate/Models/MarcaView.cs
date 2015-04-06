using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hibernate.Models
{
    public class MarcaView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        public string Nome { get; set; }

        [StringLength(250,ErrorMessage = "Máximo 250 caracteres.")]
        public string Descricao { get; set; }
    }
}