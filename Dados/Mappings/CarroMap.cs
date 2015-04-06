using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;
using FluentNHibernate.Mapping;

namespace Dados.Mappings
{
    public class CarroMap : ClassMap<Carro>
    {
        public CarroMap()
        {
            Table("tab_carro");
            Id(x => x.Id).GeneratedBy.Identity().Unique().Not.Nullable();
            Map(x => x.Nome).Length(20).Not.Nullable().Unique();
            Map(x => x.Preco).Not.Nullable();
            References(x => x.MarcaCarro).Not.Nullable().Column("id_marca");
        }
    }
}
