using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Infra;
using FluentNHibernate.Automapping;
using NHibernate.Stat;

namespace Dados.Interfaces
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private NHibernateHelper helper = null;

        public void Salvar(T entidade)
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }

        public void Editar(T entidade)
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }

        public void Excluir(int id)
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var entidade = Buscar(id);
                        session.Delete(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }

        public T Buscar(int id)
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                try
                {
                    return session.Get<T>(id);
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

        public IList<T> Listar()
        {
            helper = new NHibernateHelper();

            using (var session = helper.OpenSession())
            {
                try
                {
                    return session.CreateCriteria<T>().List<T>();
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
