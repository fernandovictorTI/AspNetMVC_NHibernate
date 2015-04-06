using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces
{
    public interface IRepositorio<T>
    {
        void Salvar(T entidade);
        void Editar(T entidade);
        void Excluir(int id);
        T Buscar(int id);
        IList<T> Listar();
    }
}
