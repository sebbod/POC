using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libod
{
        public static class IEnumeratorEx
        {
                public static IEnumerator<T> Cast<T> (this IEnumerator iterator)
                {
                        while (iterator.MoveNext ())
                        {
                                yield return (T)iterator.Current;
                        }
                }

                public static List<T> ToList<T> (this IEnumerator iterator)
                {
                        var list = new List<T> ();
                        while (iterator.MoveNext ())
                        {
                                list.Add ((T)iterator.Current);
                        }
                        return list;
                }

                public static List<T> ToList<T> (this IEnumerator<T> iterator)
                {
                        var list = new List<T> ();
                        while (iterator.MoveNext ())
                        {
                                list.Add (iterator.Current);
                        }
                        return list;
                }

        }
}
