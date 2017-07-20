using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Bodget.Model;

namespace Bodget.UserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucCategoryContainer: UserControl
        {
                private const int HEIGHT = 200;

                //private Point downPoint;
                //private bool moved;
                ////This is used to store the CellBounds together with the Cell position
                ////so that we can find the Cell position later (after releasing mouse).
                //Dictionary<TableLayoutPanelCellPosition, Rectangle> dict = new Dictionary<TableLayoutPanelCellPosition, Rectangle> ();

                private void Init ()
                {
                        InitializeComponent ();

                        typeof (TableLayoutPanel).GetProperty ("DoubleBuffered"
                                , System.Reflection.BindingFlags.NonPublic
                                | System.Reflection.BindingFlags.Instance).SetValue (tlp, true, null);

                        //tlp.CellPaint += tlp_CellPaint;
                }

                public ucCategoryContainer ()
                {
                        Init ();
                }

                public ucCategoryContainer (SearchCriteria SearchCriteria)
                {
                        Init ();
                        this.SearchCriteria = SearchCriteria;
                }


                private void ucCategoryContainer_Load (object sender, EventArgs e)
                {
                        //RefreshCategories ();
                        tlp.BringToFront ();
                        //Console.WriteLine (tlp.Dock);
                }


                //void ucc_MouseUp (object sender, MouseEventArgs e)
                //{
                //        //Control ucc = sender as Control;
                //        //if (moved)
                //        //{
                //        //        SetControl (ucc, e.Location);
                //        //        ucc.Parent = tlp;
                //        //        moved = false;
                //        //}
                //}

                //void ucc_MouseMove (object sender, MouseEventArgs e)
                //{
                //        //Control ctrl = sender as Control;
                //        //if (e.Button == MouseButtons.Left)
                //        //{
                //        //        ctrl.Left += e.X - downPoint.X;
                //        //        ctrl.Top += e.Y - downPoint.Y;
                //        //        moved = true;
                //        //        tlp.Invalidate ();
                //        //}
                //}

                //void ucc_MouseDown (object sender, MouseEventArgs e)
                //{
                //        ucOperationContainer ctrlSrc = sender as ucOperationContainer;
                //        //Console.WriteLine (ctrlSrc.Name);
                //        downControl (ctrlSrc);
                //        //ctrl.Parent = this;
                //        //ctrl.BringToFront ();
                //        downPoint = e.Location;
                //}

                //private void downControl (ucOperationContainer ctrlSrc)
                //{
                //        int rowSrc = tlp.GetRow (ctrlSrc);
                //        ucOperationContainer ctrlTrg = tlp.GetControlFromPosition (0, rowSrc + 1) as ucOperationContainer;
                //        if (ctrlTrg == null)
                //        {
                //                return;
                //        }
                //        tlp.SetRow (ctrlSrc, rowSrc + 1);
                //        tlp.SetRow (ctrlTrg, rowSrc);
                //}

                //private void SetControl (Control c, Point position)
                //{
                //        Point localPoint = tlp.PointToClient (c.PointToScreen (position));
                //        var keyValue = dict.FirstOrDefault (e => e.Value.Contains (localPoint));
                //        if (!keyValue.Equals (default (KeyValuePair<TableLayoutPanelCellPosition, Rectangle>)))
                //        {
                //                tlp.SetCellPosition (c, keyValue.Key);
                //        }
                //}
                ////CellPaint event handler for your tableLayoutPanel1
                //private void tlp_CellPaint (object sender, TableLayoutCellPaintEventArgs e)
                //{
                //        dict[new TableLayoutPanelCellPosition (e.Column, e.Row)] = e.CellBounds;
                //        if (moved)
                //        {
                //                if (e.CellBounds.Contains (tlp.PointToClient (MousePosition)))
                //                {
                //                        e.Graphics.FillRectangle (Brushes.Yellow, e.CellBounds);
                //                }
                //        }
                //}


        }
}
