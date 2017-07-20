using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Libod
{
        public static class AssemblyEx
        {
                public static Type[] GetTypesInNamespace (this Assembly assembly, string nameSpace)
                {
                        return assembly.GetTypes ().Where (t => String.Equals (t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray ();
                }
        }
}
