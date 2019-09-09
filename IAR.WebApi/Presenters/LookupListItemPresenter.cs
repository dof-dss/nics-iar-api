using DSS.Architecture.Patterns.DotNet.Clean.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IAR.WebApi.Presenters
{
    public class LookupListItemPresenter<TInput, TOutput> : IPresenter<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        private readonly List<PropertyMapping> mappings;

        public LookupListItemPresenter(List<PropertyMapping> mappings)
        {
            this.mappings = mappings;
        }

        public LookupListItemPresenter(string keyMapping, string valueMapping)
            : this(new List<PropertyMapping>
                   {
                       new PropertyMapping() { SourcePropertyName = keyMapping, TargetPropertyName = "Id" },
                       new PropertyMapping() { SourcePropertyName = valueMapping, TargetPropertyName = "Description" }
                   })
        { }

        public TOutput Build(TInput source)
        {
            var result = Activator.CreateInstance<TOutput>();
            Type t = result.GetType();

            foreach (var mapping in mappings)
            {
                result.GetType().GetProperty(mapping.TargetPropertyName).SetValue(result, source.GetType().GetProperty(mapping.SourcePropertyName).GetValue(source));
            }
            return result;
        }
    }

}
