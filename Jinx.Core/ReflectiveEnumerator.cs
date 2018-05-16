using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jinx.Core
{
    public static class ReflectiveEnumerator
    {
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                yield return (T)Activator.CreateInstance(type, constructorArgs);
            }
        }
    }
}
