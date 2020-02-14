﻿namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ServiceProviderExtensions
    {
        public static void InjectFor<T>(this IServiceProvider provider, T obj)
            => InjectFor(provider, (object)obj);
        public static void InjectFor(this IServiceProvider provider, object obj)
        {
            var _injectablePropertyBindingFlags
                = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var type = obj.GetType();
            var injectableProperties =
                MemberAssignmentStatic.GetPropertiesIncludingInherited(obj.GetType(), _injectablePropertyBindingFlags);

            injectableProperties = injectableProperties.Where(LightPropResolver.Resolver);

            var tableOfInjectionData = injectableProperties.Select(property =>
            (
                propertyName: property.Name,
                propertyType: property.PropertyType,
                setter: MemberAssignmentStatic.CreatePropertySetter(obj.GetType(), property, false)
            )).ToArray();

            foreach (var (propertyName, propertyType, setter) in tableOfInjectionData)
            {
                var serviceInstance = provider.GetService(propertyType);
                if (serviceInstance == null)
                    throw new InvalidOperationException(
                        $"Cannot provide a value for property '{propertyName}' on type '{type.FullName}'. There is no registered service of type '{propertyType}'.");
                setter.SetValue(obj, serviceInstance);
            }
        }
    }
}
