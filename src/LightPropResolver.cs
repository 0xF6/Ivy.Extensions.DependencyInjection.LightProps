namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Reflection;

    public static class LightPropResolver
    {
        internal static Func<PropertyInfo, bool> Resolver = x => x.IsDefined(typeof(InjectAttribute));

        public static void ConfigureCustomFilterAttribute<T>(Func<PropertyInfo, bool> functor) 
            => Resolver = functor;
    }
}