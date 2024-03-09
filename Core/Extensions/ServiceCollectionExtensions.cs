using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
 /* Neyi genişletmek istiyorsak onun için this yazarız yani buradaki IServiceCollection parametre değil */
          (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection); // birden fazla modulu de buraya eklenebildiğini söylüyoruz
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
