using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Libod
{
        partial class StringEx
        {


                public static int ToInt (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return default (int);
                        int retVal;
                        if (int.TryParse (str, out retVal))
                                return retVal;
                        return default (int);
                }

                public static Int32 ToInt32 (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return default (Int32);
                        Int32 retVal;
                        if (Int32.TryParse (str, out retVal))
                                return retVal;
                        return default (Int32);
                }

                public static bool IsInt32 (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return false;

                        Int32 retVal;
                        if (Int32.TryParse (str, out retVal))
                                return true;

                        return false;
                }

                public static Int64 ToInt64 (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return default (Int64);
                        Int64 retVal;
                        if (Int64.TryParse (str, out retVal))
                                return retVal;
                        return default (Int64);
                }

                public static decimal ToDecimal (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return default (decimal);
                        decimal retVal;
                        if (decimal.TryParse (str, out retVal))
                                return retVal;
                        return default (decimal);
                }

                public static bool IsDecimal (this string str)
                {
                        if (string.IsNullOrEmpty (str))
                                return false;

                        decimal retVal;
                        if (decimal.TryParse (str, out retVal))
                                return true;

                        return false;
                }
        }
}
