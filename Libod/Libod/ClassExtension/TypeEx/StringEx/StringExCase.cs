using System;
using System.Globalization;
using RESX = Libod.ResourceText;

namespace Libod
{
        partial class StringEx
        {
                /// <summary>
                /// Capitalize the first character and add a dot at the end
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static string ToSentence (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        if (strVal.Length == 1)
                        {
                                strVal = strVal.ToUpper ();
                        }
                        else
                        {
                                strVal = strVal.Substring (0, 1).ToUpper () + strVal.Substring (1);
                        }

                        return string.Format ("{0}{1}", strVal, RESX.dot);
                }

                /// <summary>
                /// Capitalize the first character and add a space and a colon at the end
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static string ToLabel (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        if (strVal.Length == 1)
                        {
                                strVal = strVal.ToUpper ();
                        }
                        else
                        {
                                strVal = strVal.Substring (0, 1).ToUpper () + strVal.Substring (1);
                        }

                        return string.Format ("{0} {1}", strVal, RESX.colon);
                }

                public static string ToTitle (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        if (strVal.Length == 1)
                        {
                                return strVal.ToUpper ();
                        }
                        else
                        {
                                return strVal.Substring (0, 1).ToUpper () + strVal.Substring (1);
                        }
                }

                /// <summary>
                /// Capitalize the first character
                /// this is a test string => Thisisateststring
                /// </summary>
                /// <param name="the_string"></param>
                /// <returns></returns>
                public static string ToTitleCase (this string the_string)
                {
                        TextInfo textInfo = new CultureInfo ("en-US", false).TextInfo;
                        return textInfo.ToTitleCase (the_string);
                }

                /// <summary>
                /// Add space before and after strVal
                /// </summary>
                /// <param name="strVal"></param>
                /// <returns></returns>
                public static string UnTrim (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        return string.Format (" {0} ", strVal);
                }

                public static string AddSpaceBefore (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        return string.Format (" {0}", strVal);
                }

                public static string AddSpaceAfter (this string strVal)
                {
                        if (strVal == null)
                        {
                                return strVal;
                        }

                        return string.Format ("{0} ", strVal);
                }

                /// <summary>
                /// Convert the string to Pascal case
                /// this is a test string => ThisIsATestString
                /// </summary>
                /// <param name="the_string"></param>
                /// <returns></returns>
                public static string ToPascalCase (this string the_string)
                {
                        // If there are 0 or 1 characters, just return the string.
                        if (the_string == null)
                                return the_string;
                        if (the_string.Length < 2)
                                return the_string.ToUpper ();

                        // Split the string into words.
                        string[] words = the_string.Split (
                            new char[] { },
                            StringSplitOptions.RemoveEmptyEntries);

                        // Combine the words.
                        string result = "";
                        foreach (string word in words)
                        {
                                result +=
                                    word.Substring (0, 1).ToUpper () +
                                    word.Substring (1);
                        }

                        return result;
                }

                /// <summary>
                /// Convert the string to camel case
                /// this is a test string => thisIsATestString
                /// </summary>
                /// <param name="the_string"></param>
                /// <returns></returns>
                public static string ToCamelCase (this string the_string)
                {
                        // If there are 0 or 1 characters, just return the string.
                        if (the_string == null || the_string.Length < 2)
                                return the_string;

                        // Split the string into words.
                        string[] words = the_string.Split (
                            new char[] { },
                            StringSplitOptions.RemoveEmptyEntries);

                        // Combine the words.
                        string result = words[0].ToLower ();
                        for (int i = 1; i < words.Length; i++)
                        {
                                result +=
                                    words[i].Substring (0, 1).ToUpper () +
                                    words[i].Substring (1);
                        }

                        return result;
                }



                /// <summary>
                /// Capitalize the first character and add a space before each capitalized letter (except the first character).
                /// this is a test string => This Is A Test String
                /// </summary>
                /// <param name="the_string"></param>
                /// <returns></returns>
                public static string ToProperCase (this string the_string)
                {
                        // If there are 0 or 1 characters, just return the string.
                        if (the_string == null)
                                return the_string;
                        if (the_string.Length < 2)
                                return the_string.ToUpper ();

                        // Start with the first character.
                        string result = the_string.Substring (0, 1).ToUpper ();

                        // Add the remaining characters.
                        for (int i = 1; i < the_string.Length; i++)
                        {
                                if (char.IsUpper (the_string[i]))
                                        result += " ";
                                result += the_string[i];
                        }

                        return result;
                }
        }
}
