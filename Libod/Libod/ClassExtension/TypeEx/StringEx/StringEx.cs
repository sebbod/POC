using System;
using System.Globalization;
using System.Threading;

namespace Libod
{
        public static partial class StringEx
        {

                public static bool IsNullOrEmpty (this String strVal)
                {
                        return string.IsNullOrEmpty (strVal);
                }

                public static bool IsNotNullOrEmpty (this String strVal)
                {
                        return !strVal.IsNullOrEmpty ();
                }

                public static String ToStrInvCul (this String strVal)
                {
                        return strVal.ToString (CultureInfo.InvariantCulture);
                }

                /// <summary>
                /// Warning if you use this - the month will be before the day like that mm/dd/yyyy
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static String ToStrInvCul (this DateTime strVal)
                {
                        return strVal.ToString (CultureInfo.InvariantCulture);
                }
                public static String ToStrThreadCul (this DateTime strVal)
                {
                        return strVal.ToString (Thread.CurrentThread.CurrentCulture);
                }

                public static String ToStrInvCul (this decimal strVal)
                {
                        return strVal.ToString (CultureInfo.InvariantCulture);
                }


                /// <summary>
                /// tronc la chaine strVal si elle est plus longue que length
                /// </summary>
                /// <param name="strVal"></param>
                /// <param name="length"></param>
                public static String TruncateAt (this String strVal, int length)
                {
                        if (strVal == null)
                        {
                                return null;
                        }
                        if (strVal.Length > length)
                        {
                                strVal = strVal.Substring (0, length);
                        }
                        return strVal;
                }

                public static String RemoveFirstChar (this String strVal, int length = 1)
                {
                        if (strVal.Length >= length)
                        {
                                strVal = strVal.Substring (length, strVal.Length - length);
                        }
                        return strVal;
                }

                public static String RemoveTheFirstChar (this String strVal)
                {
                        return RemoveFirstChar (strVal, strVal.Length - 1);
                }

                /// <summary>
                /// supprime les X derniers caractère d'une chaine
                /// </summary>
                /// <param name="strVal"></param>
                /// <param name="length"></param>
                /// <returns></returns>
                public static String RemoveLastChar (this String strVal, int length = 1)
                {
                        if (strVal.Length >= length)
                        {
                                strVal = strVal.Substring (0, strVal.Length - length);
                        }
                        return strVal;
                }

                /// <summary>
                /// supprime le dernier caractère d'une chaine
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static String RemoveTheLastChar (this String strVal)
                {
                        return RemoveLastChar (strVal);
                }

                /// <summary>
                /// Supprime le dernier caractère SI c'est une fin de ligne (\n)
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static String RemoveFinDeLigneFinal (this String strVal)
                {
                        if (strVal.EndsWith ("\n"))
                        {
                                return RemoveLastChar (strVal, 1);
                        }
                        else
                        {
                                return strVal;
                        }
                }

                public static String RemoveTheFirstAndTheLastChar (this String strVal)
                {
                        return RemoveTheLastChar (RemoveTheFirstChar (strVal));
                }




                /// <summary>
                /// ajoute un saut de ligne si ligne != 1
                /// </summary>
                /// <param name="str"></param>
                /// <param name="line"></param>
                /// <returns></returns>
                public static String AddNewLine (this string str, int line)
                {
                        str += (line == 1 ? string.Empty : "\n");
                        return str;
                }

                public static String Format (this string start, int start_lenght)
                {
                        return start.PadRight (start_lenght, ' ');
                }
                public static String Format (this string start, int start_lenght, string end)
                {
                        return start.PadRight (start_lenght, ' ') + end;
                }

                /// <summary>
                /// retourne le premier carractère d'une chaine (peu retourner plus que le premier)
                /// </summary>
                /// <param name="strVal"></param>
                /// <param name="length"></param>
                /// <returns></returns>
                public static String FirstChar (this String strVal, int length = 1)
                {
                        if (strVal.Length >= length)
                        {
                                strVal = strVal.Substring (0, length);
                        }
                        return strVal;
                }

                /// <summary>
                /// retourne le dernier carractère d'une chaine (peu retourner plus que le dernier)
                /// </summary>
                /// <param name="strVal"></param>
                /// <param name="length"></param>
                /// <returns></returns>
                public static String LastChar (this String strVal, int length=1)
                {
                        if (strVal.Length >= length)
                        {
                                strVal = strVal.Substring (strVal.Length - length, length);
                        }
                        return strVal;
                }

                /// <summary>
                /// ajoute depth à un nombre au format string exemple un numéro de chèque 00000012
                /// </summary>
                /// <param name="strVal"></param>
                /// <param name="depth"></param>
                /// <returns></returns>
                public static String Up (this String strVal, int depth = 1)
                {
                        if (strVal != null && strVal.Length >= 0)
                        {
                                string tpsStr = strVal;
                                int removedChar = 0;
                                string lastChar = tpsStr.LastChar ();
                                while (lastChar == "9")
                                {
                                        removedChar++;
                                        tpsStr = tpsStr.RemoveLastChar (1);
                                        lastChar = tpsStr.LastChar ();
                                }
                                tpsStr = tpsStr.RemoveLastChar (1);     // remove the up char
                                int up = lastChar.ToInt ();
                                up++;
                                if (removedChar > 0)
                                {
                                        return (tpsStr + up).PadRight (strVal.Length, '0');
                                }
                                return tpsStr + up;

                        }
                        return strVal;
                }
        }
}
