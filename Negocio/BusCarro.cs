using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Dao;
using Entidade;

namespace Negocio
{
    public class BusCarro
    {
        public void Salvar(Carro carro)
        {
            var daoCarro = new DaoCarro();
            var busMarca = new BusMarca();

            carro.MarcaCarro = busMarca.Buscar(carro.IdMarca);

            if (carro.Id > 0)
            {
                daoCarro.Editar(carro);
            }
            else
            {
                daoCarro.Salvar(carro);
            }
        }

        public void Excluir(int id)
        {
            var daoCarro = new DaoCarro();

            daoCarro.Excluir(id);
        }

        public Carro Buscar(int id)
        {
            var daoCarro = new DaoCarro();
            return daoCarro.Buscar(id);
        }

        public List<Carro> Listar()
        {
            var daoCarro = new DaoCarro();
            var busMarca = new BusMarca();
            var listaCarros = daoCarro.ListarCarros();

            foreach (var carro in listaCarros)
            {
                carro.MarcaCarro = busMarca.Buscar(carro.MarcaCarro.Id);
                carro.IdMarca = carro.MarcaCarro.Id;
            }

            return listaCarros;
        }
    }
}
