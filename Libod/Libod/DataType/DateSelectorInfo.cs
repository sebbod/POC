using System;
using RESX = Libod.ResourceText;

namespace Libod.DataType
{
        public class DateSelectorInfo //: EventArgs
        {
                public DateSelectorInfo (int y, int m, int d)
                {
                        Year = y;
                        Month = m;
                        Day = d;
                }

                public int Year { get; set; }
                public int Month { get; set; }
                public int Day { get; set; }

                public DateTime dtStart
                {
                        get
                        {
                                int y = Year;
                                int m = Month;
                                int d = Day;
                                DateTime dtMin = DateTime.MinValue;
                                if (y <= 0)
                                {
                                        y = dtMin.Year;
                                }
                                if (m <= 0)
                                {
                                        m = dtMin.Month;
                                }
                                if (d <= 0)
                                {
                                        d = dtMin.Day;
                                }
                                return new DateTime (y, m, d);
                        }
                }

                public DateTime dtStop
                {
                        get
                        {
                                int y = Year;
                                int m = Month;
                                int d = Day;
                                DateTime dtMax = DateTime.MaxValue;
                                if (y <= 0)
                                {
                                        y = dtMax.Year;
                                }
                                if (m <= 0)
                                {
                                        m = dtMax.Month;
                                }
                                if (d <= 0)
                                {
                                        d = DateTime.DaysInMonth (y, m);
                                }
                                return new DateTime (y, m, d);
                        }
                }

                new public string ToString ()
                {
                        return string.Format ("{0} {1} {2} {3}", RESX.de, dtStart.ToString ("dd/MM/yyyy"), RESX.aAccentue, dtStop.ToString ("dd/MM/yyyy"));
                }
        }


}
