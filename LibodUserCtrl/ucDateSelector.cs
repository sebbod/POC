using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using Libod;
using Libod.Ctrl;
using Libod.Culture;
using Libod.DataType;


namespace LibodUserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucDateSelector: UserControl
        {
                /// <summary>
                /// default years list init in constructor
                /// </summary>
                private List<ctrlItem> YearsLst { get; set; }

                public int Year { get; set; }
                public int Month { get; set; }
                public int Day { get; set; }
                /// <summary>
                /// current
                /// </summary>
                public int DayInMonth { get; set; }

                public delegate void DateSelectorValueChangeEventHandler (object source, DateSelectorInfo e);
                public event DateSelectorValueChangeEventHandler ValueChange;


                private void Init ()
                {
                        InitializeComponent ();

                        lblYear.Text = ResourceText.year + ResourceText.Space + ResourceText.colon;
                        lblMonth.Text = ResourceText.Month + ResourceText.Space + ResourceText.colon;
                        lblDay.Text = ResourceText.Day + ResourceText.Space + ResourceText.colon;
                }

                public ucDateSelector ()
                {
                        Init ();
                }

                public ucDateSelector (List<ctrlItem> years)
                {
                        Init ();

                        if (years != null)
                        {
                                YearsLst = years;
                        }
                }

                private void ucDateSelector_Load (object sender, EventArgs e)
                {
                        int lastMonthEnded = DateTime.Now.Month - 1;

                        //var years = new Operation ().GetYears ().ToList ();

                        if (YearsLst == null || !YearsLst.Any ())
                        {
                                return;
                        }

                        foreach (var i in YearsLst)
                        {
                                cmbYear.Items.Add (i);
                        }
                        /*
                         * auto select year
                         */
                        ctrlItem year2select;
                        int countYear = YearsLst.Count (y => (int)y.Value != 0);
                        if (lastMonthEnded != 12 && countYear > 1)
                        {
                                year2select = YearsLst.Skip (countYear - 1).First ();
                        }
                        else
                        {
                                year2select = YearsLst.Last ();
                        }
                        cmbYear.SelectedItem = year2select;

                        foreach (var i in Calendrier.GetMonths ())
                        {
                                cmbMonth.Items.Add (i);
                                /*
                                 * auto select Month
                                 */
                                if ((int)i.Value == lastMonthEnded)
                                {
                                        cmbMonth.SelectedItem = i;
                                }
                        }

                        Refresh_cmbDay ();
                }

                //private void Refresh_cmbMonth ()
                //{
                //        foreach (var i in Calendrier.GetMonths ())
                //        {
                //                cmbMonth.Items.Add (i);
                //        }
                //}

                private void Refresh_cmbDay ()
                {
                        if (Year == 0 || Month == 0)
                        {
                                return;
                        }
                        // -1 for blank value
                        if (DayInMonth - 1 == DateTime.DaysInMonth (Year, Month))
                        {
                                return;
                        }

                        DayInMonth = 0;
                        cmbDay.Items.Clear ();
                        foreach (var i in Calendrier.GetDaysInMonth (Year, Month))
                        {
                                cmbDay.Items.Add (i);
                                DayInMonth++;
                        }
                }




                private void cmbYear_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbYear.SelectedItem != null)
                        {
                                int y = (int)(cmbYear.SelectedItem as ctrlItem).Value;
                                if (y != Year)
                                {
                                        Year = y;
                                        if (Year == 0)
                                        {
                                                if (Month != 0)
                                                {
                                                        cmbMonth.SelectedItem = cmbMonth.Items[0];
                                                }
                                                cmbMonth.Enabled = false;
                                        }
                                        else
                                        {
                                                cmbMonth.Enabled = true;
                                        }
                                        if (ValueChange != null)
                                        {
                                                ValueChange (this, new DateSelectorInfo (Year, Month, Day));
                                        }
                                }
                        }
                }

                private void cmbMonth_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbMonth.SelectedItem != null)
                        {
                                int m = (int)(cmbMonth.SelectedItem as ctrlItem).Value;
                                if (m != Month)
                                {
                                        Month = m;
                                        if (Month == 0 )
                                        {
                                                if (Day != 0)
                                                {
                                                        cmbDay.SelectedItem = cmbDay.Items[0];
                                                }
                                                cmbDay.Enabled = false;
                                        }
                                        else
                                        {
                                                cmbDay.Enabled = true;
                                                Refresh_cmbDay ();              // recharger les jours quand le mois change
                                        }
                                        if (ValueChange != null)
                                        {
                                                ValueChange (this, new DateSelectorInfo (Year, Month, Day));
                                        }
                                }

                        }
                }

                private void cmbDay_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbDay.SelectedItem != null)
                        {
                                int d = (int)(cmbDay.SelectedItem as ctrlItem).Value;
                                if (d != Day)
                                {
                                        Day = d;
                                        if (ValueChange != null)
                                        {
                                                ValueChange (this, new DateSelectorInfo (Year, Month, Day));
                                        }
                                }

                        }
                }






        }
}
