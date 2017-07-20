using System;
using System.Globalization;
using System.Threading;

namespace Libod
{
        public static class Int16Ex
        {
                public static bool isNullOrZero (this short? val)
                {
                        return val == null || val == 0;
                }

                public static String ToStrInvCul (this short val)
                {
                        return val.ToString (CultureInfo.InvariantCulture);
                }

                /// <summary>
                /// Est-ce la valeur d'un short est dans une liste/tableau de valeurs
                /// </summary>
                /// <param name="e"></param>
                /// <param name="vals"></param>
                /// <returns></returns>
                public static bool In (this short e, params short[] vals)
                {
                        foreach (short val in vals)
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
