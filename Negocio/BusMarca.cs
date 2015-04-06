using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Dao;
using Entidade;

namespace Negocio
{
    public class BusMarca
    {
        public void Salvar(Marca carro)
        {
            var daoMarca = new DaoMarca();

            if (carro.Id > 0)
            {
                daoMarca.Editar(carro);
            }
            else
            {
                daoMarca.Salvar(carro);
            }
        }

        public void Excluir(int id)
        {
            var daoMarca = new DaoMarca();

            daoMarca.Excluir(id);
        }

        public Marca Buscar(int id)
        {
            var daoMarca = new DaoMarca();

            return daoMarca.Buscar(id);
        }

        public IList<Marca> Listar()
        {
            var daoMarca = new DaoMarca();
            return daoMarca.Listar();
        }
    }
}
