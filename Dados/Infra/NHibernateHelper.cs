using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Dados.Infra
{
    public class NHibernateHelper
    {
        private ISessionFactory _SessionFactory;
        const string dSource = @"FERNANDO-PC\SQLEXPRESS_2008";
        const string iCatalog = "LojaProdutoMarca";
        const string userId = "sa";
        const string password = "123123";

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_SessionFactory == null)
                    InicializarSessionFactory();

                return _SessionFactory;
            }
        }

        private void InicializarSessionFactory()
        {
            string connetionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
               dSource, iCatalog, userId, password);

            _SessionFactory =
                Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(connetionString).ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(cfg => new SchemaExport(cfg)
                        .Create(false, false))
                    .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
