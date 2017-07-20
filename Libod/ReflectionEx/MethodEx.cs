using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libod.ReflectionEx
{
        public static class MethodEx
        {
                public static MethodInfo[] GetAllMethods (this object o)
                {
                        return o.GetType ().GetMethods (); //BindingFlags.Public | BindingFlags.Instance);
                }

                public static MethodInfo[] GetAllMethods (this Type t)
                {
                        return t.GetMethods (); //BindingFlags.Public | BindingFlags.Instance);
                }

                public static string GetParamName (System.Reflection.MethodInfo method, int index)
                {
                        string retVal = string.Empty;

                        if (method != null && method.GetParameters ().Length > index)
                                retVal = method.GetParameters ()[index].Name;


                        return retVal;
                }
        }
}
