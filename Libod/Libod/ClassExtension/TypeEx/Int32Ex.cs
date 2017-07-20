using System;
using System.Globalization;
using System.Threading;

namespace Libod
{
        public static class Int32Ex
        {
                public static bool isNullOrZero (this int? val)
                {
                        return val == null || val == 0;
                }

                public static String ToStrInvCul (this int val)
                {
                        return val.ToString (CultureInfo.InvariantCulture);
                }

                /// <summary>
                /// Est-ce la valeur d'un int est dans une liste/tableau de valeurs
                /// </summary>
                /// <param name="e"></param>
                /// <param name="vals"></param>
                /// <returns></returns>
                public static bool In (this int e, params int[] vals)
                {
                        foreach (int val in vals)
                        {
                                if (e == val)
                                {
                                        return true;
                                }
                        }
                        return false;
                }
        }
}
