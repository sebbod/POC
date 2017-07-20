using System;
using System.Globalization;
using System.Threading;

namespace Libod
{
        public static class Int64Ex
        {
                public static bool isNullOrZero (this Int64? val)
                {
                        return val == null || val == 0;
                }

                public static String ToStrInvCul (this Int64 val)
                {
                        return val.ToString (CultureInfo.InvariantCulture);
                }

                /// <summary>
                /// Est-ce la valeur d'un Int64 est dans une liste/tableau de valeurs
                /// </summary>
                /// <param name="e"></param>
                /// <param name="vals"></param>
                /// <returns></returns>
                public static bool In (this Int64 e, params Int64[] vals)
                {
                        foreach (Int64 val in vals)
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
