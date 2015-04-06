using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;
using FluentNHibernate.Mapping;

namespace Dados.Mappings
{
    public class MarcaMap : ClassMap<Marca>
    {
        public MarcaMap()
        {
            Table("tab_marca_carro");
            Id(x => x.Id).Unique().GeneratedBy.Identity().Not.Nullable();
            Map(x => x.Nome).Length(20).Not.Nullable().Unique();
            Map(x => x.Descricao).Length(250);
        }
    }
}
