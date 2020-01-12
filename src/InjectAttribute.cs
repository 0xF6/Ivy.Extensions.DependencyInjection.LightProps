namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    // maybe conflict with Microsoft.AspNetCore.Components.InjectAttribute 
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InjectAttribute : Attribute
    {
    }
}