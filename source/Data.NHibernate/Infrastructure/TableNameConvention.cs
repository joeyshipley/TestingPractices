using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Data.NHibernate.Infrastructure
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            var typeName = instance.EntityType.Name;
            instance.Table(Inflector.Inflector.Pluralize(typeName));
        }
    }
}