using System;
using System.Linq;

namespace GenShop.Invoicing.Domain.Helpers
{
    public static class Loader
    {
        public static T[] LoadAllInterfaceImplementations<T>()
            where T : class
        {
            var type = typeof(T);

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x) as T)
                .ToArray();
        }
    }
}
