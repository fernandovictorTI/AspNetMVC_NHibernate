using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Carro
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual float Preco { get; set; }
        public virtual int IdMarca { get; set; }
        public virtual Marca MarcaCarro { get; set; }

        public Carro()
        {
            this.MarcaCarro = new Marca();
        }
    }
}
