using System;
using System.Globalization;
using System.Threading;

namespace Libod
{
        public static class BoolEx
        {
                /// <summary>
                /// inverse une valeur boolean
                /// </summary>
                /// <param name="val"></param>
                /// <returns></returns>
                public static bool Not (this bool val)
                {
                        return !val;
                }

        }
}
