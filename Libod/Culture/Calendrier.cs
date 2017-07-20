using System;
using Libod.Ctrl;
using System.Collections.Generic;

namespace Libod.Culture
{
        public static class Calendrier
        {
                public static IEnumerable<ctrlItem> GetMonths ()
                {
                        yield return new ctrlItem { Text = ResourceText.BlankValue      /**/, Value = 0 };
                        yield return new ctrlItem { Text = ResourceText.January         /**/, Value = 1 };
                        yield return new ctrlItem { Text = ResourceText.February        /**/, Value = 2 };
                        yield return new ctrlItem { Text = ResourceText.March           /**/, Value = 3 };
                        yield return new ctrlItem { Text = ResourceText.April           /**/, Value = 4 };
                        yield return new ctrlItem { Text = ResourceText.May             /**/, Value = 5 };
                        yield return new ctrlItem { Text = ResourceText.June            /**/, Value = 6 };
                        yield return new ctrlItem { Text = ResourceText.July            /**/, Value = 7 };
                        yield return new ctrlItem { Text = ResourceText.August          /**/, Value = 8 };
                        yield return new ctrlItem { Text = ResourceText.September       /**/, Value = 9 };
                        yield return new ctrlItem { Text = ResourceText.October         /**/, Value = 10 };
                        yield return new ctrlItem { Text = ResourceText.November        /**/, Value = 11 };
                        yield return new ctrlItem { Text = ResourceText.December        /**/, Value = 12 };
                }

                public static IEnumerable<ctrlItem> GetDaysInMonth (int year, int month)
                {
                        yield return new ctrlItem { Text = ResourceText.BlankValue, Value = 0 };

                        for (int d = 1; d <= DateTime.DaysInMonth (year, month); d++)
                        {
                                yield return new ctrlItem { Text = d.ToString (), Value = d };
                        }
                }

                public static IEnumerable<DateTime> GetDatesInMonth (int year, int month)
                {
                        int days = DateTime.DaysInMonth (year, month);
                        for (int d = 1; d <= days; d++)
                        {
                                yield return new DateTime (year, month, d);
                        }
                }
        }
}
