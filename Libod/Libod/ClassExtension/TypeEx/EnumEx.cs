using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Libod
{
        public static class EnumEx
        {
                /// <summary>
                /// sample :
                /// MyEnum tester = MyEnum.FlagA | MyEnum.FlagB;
                /// if(tester.IsSet(MyEnum.FlagA))
                /// <para>Il vaut mieux de préférence utiliser la même Enum pour input et pour matchTo mais il n'y a pas de restriction a ce niveau dans cette fonction</para>
                /// </summary>
                /// <param name="input"></param>
                /// <param name="matchTo"></param>
                /// <returns></returns>
                public static bool IsSet (this Enum input, Enum matchTo)
                {
                        return (Convert.ToUInt32 (input) & Convert.ToUInt32 (matchTo)) != 0;
                }

                public static List<int> Values (this Enum e)
                {
                        var enumValues = new List<int> ();

                        foreach (int enumValue in Enum.GetValues (e.GetType ()))
                                enumValues.Add (enumValue);

                        return enumValues;
                }

                public static Type GetEnumType<T> ()
                {
                        Type enumType = typeof (T);

                        // Can't use type constraints on value types, so have to do check like this
                        if (enumType.BaseType != typeof (Enum))
                                throw new ArgumentException ("T must be of type System.Enum");

                        return enumType;
                }

                public static List<T> EnumToList<T> (this Enum e)
                {
                        Type enumType = GetEnumType<T> ();

                        Array enumValArray = Enum.GetValues (enumType);

                        List<T> enumValList = new List<T> (enumValArray.Length);

                        foreach (int val in enumValArray)
                                enumValList.Add ((T)Enum.Parse (enumType, val.ToStrInvCul ()));

                        return enumValList;
                }

                public static List<T> EnumToList<T> (this Enum e, List<T> excludeList)
                {
                        return e.EnumToList<T> ().Except (excludeList).ToList ();
                }

                public static List<T> EnumToList<T> (this Enum e, T exclude)
                {
                        return e.EnumToList (new List<T> { exclude });
                }




                public static T ToName<T> (this Enum value)
                {
                        if (value == null)
                                throw new ArgumentNullException ();//"EnumEx::ToName:value is null");

                        string name = Enum.GetName (enumType : value.GetType (), value : value);

                        if (name == null)
                                throw new ArgumentNullException ();//"EnumEx::ToName:name is null");

                        return (T)Enum.Parse (typeof (T), name);
                }

                /// <summary>
                /// Change le type d'une liste d'enum 
                /// <para>pour convertir en liste de short ou de int par exemple</para>
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="values"></param>
                /// <returns></returns>
                public static IEnumerable<T> ToValues<T> (this IEnumerable<Enum> values)
                {
                        foreach (Enum enumValue in values)
                        {
                                yield return enumValue.ToValue<T> ();
                        }
                }

                public static T ToValue<T> (this Enum value)
                {
                        return (T)((dynamic)((int)((object)value)));
                }



                /// <summary>
                /// retourne la liste des réseaux sous forme de chaine au format 'XXXXXXXX','XXXXXXXX',...
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <returns></returns>
                public static string EnumToString4INclause<T> (this Enum e)
                {
                        return Enum.GetNames (GetEnumType<T> ()).Aggregate ("", (inClause, rscCode) => inClause + ",'" + rscCode + "'").Substring (1);
                }

                /// <summary>
                /// retourne la liste des réseaux sous forme de chaine au format 'XXXXXXXX','XXXXXXXX',...
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <returns></returns>
                public static string EnumToString4INclause<T> (this Enum e, List<T> excludeList)
                {
                        return e.EnumToList (excludeList).Aggregate ("", (inClause, rscCode) => inClause + ",'" + rscCode + "'").Substring (1);
                }

                /// <summary>
                /// retourne la liste des réseaux sous forme de chaine au format 'XXXXXXXX','XXXXXXXX',...
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <returns></returns>
                public static string EnumToString4INclause<T> (this Enum e, T exclude)
                {
                        return e.EnumToString4INclause (new List<T> { exclude });
                }

                /// <summary>
                /// Est-ce la valeur d'une enum est dans une liste/tableau de valeurs
                /// </summary>
                /// <param name="e"></param>
                /// <param name="vals"></param>
                /// <returns></returns>
                public static bool In (this Enum e, params Enum[] vals)
                {
                        foreach (Enum val in vals)
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
