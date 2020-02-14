namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    // for funcking aspcore components injector
    public static class LightPropResolver
    {
        internal static readonly List<Func<PropertyInfo, bool>> resolverContainer 
            = new List<Func<PropertyInfo, bool>>();
        static LightPropResolver() 
            => resolverContainer.Add(x => x.IsDefined(typeof(InjectAttribute)));

        public static void AddCustomFilterAttribute(Func<PropertyInfo, bool> functor)
            => resolverContainer.Add(functor);
    }
}