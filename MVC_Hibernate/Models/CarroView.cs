using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hibernate.Models
{
    public class CarroView
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "O nome é obrigatório"), StringLength(20, ErrorMessage = "Máximo 20 caracteres",MinimumLength = 1)]
        public string Nome { get; set; }

        [Required( ErrorMessage = "O Preço é obrigatório")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "A Marca do carro é obrigatória"),]
        public int IdMarca { get; set; }

        public MarcaView MarcaCarro { get; set; }

        public CarroView()
        {
            this.MarcaCarro = new MarcaView();
        }
    }
}