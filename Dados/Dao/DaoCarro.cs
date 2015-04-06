using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Infra;
using Dados.Interfaces;
using Entidade;

namespace Dados.Dao
{
    public class DaoCarro : Repositorio<Carro>
    {
        private NHibernateHelper helper = null;

        public List<Carro> ListarCarros()
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                try
                {
                    var lista = base.Listar();

                    return (from carros in lista select carros ).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    session.Close();
                }
            }
        }
    }
}
