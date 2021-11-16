using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Base
{
    internal static class ComponentExtensions
    {
        internal static IReadOnlyCollection<IComponent> GetComponents(this Assembly assembly) =>
            assembly.ExportedTypes
                .Where(IsConstructableInstallerInstance)
                .Select(Activator.CreateInstance)
                .Cast<IComponent>()
                .ToList();

        private static bool IsConstructableInstallerInstance(Type type) =>
            typeof(IComponent).IsAssignableFrom(type) &&
            !type.IsInterface &&
            !type.IsAbstract;
    }
}
