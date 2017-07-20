using System.Collections.Generic;
using System.Windows.Forms;
using Libod;
using LibodUserCtrl.Extension.WinMenu;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;
using RESX = Libod.ResourceText;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        static partial class CellEx
        {
                public static void AddPopupMenuController<T> (this ICell c, Dictionary<MouseButtons, Func<ToolStripMenuItemWithValue4sourceGrid<T>, object>> dicAction)
                {
                        c.AddController (new PopupMenu<T> (c.Grid, dicAction));
                }

                public class PopupMenu<T>: RowSelector
                {
                        private Dictionary<MouseButtons, Func<ToolStripMenuItemWithValue4sourceGrid<T>, object>> _dicAction;

                        private ContextMenuStrip ctxMnu = new ContextMenuStrip ();
                        private ToolStripMenuItem tsi;
                        private Grid _g;

                        public PopupMenu (Grid g, Dictionary<MouseButtons, Func<ToolStripMenuItemWithValue4sourceGrid<T>, object>> dicAction)
                        {
                                _g = g;
                                _dicAction = dicAction;
                                ctxMnu.ItemClicked += ctxMnu_ItemClicked;
                        }

                        void ctxMnu_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
                        {
                                ToolStripItem clickedMenuItem = e.ClickedItem;
                                ToolStripMenuItemWithValue4sourceGrid<T> tsmi = clickedMenuItem as ToolStripMenuItemWithValue4sourceGrid<T>;
                                tsmi.action.Invoke (tsmi);
                        }

                        public override void OnMouseUp (CellContext sender, MouseEventArgs e)
                        {
                                base.OnMouseUp (sender, e);

                                if (_dicAction.ContainsKey (e.Button))
                                {
                                        int iRselected = sender.Position.Row;
                                        T obj = (T)_g.Rows[iRselected].Tag;
                                        tsi = new ToolStripMenuItemWithValue4sourceGrid<T> (RESX.supprimer.ToTitle (), obj, _g, iRselected, _dicAction[e.Button]);
                                        ctxMnu.Items.Add (tsi);
                                        //ctxMnu.Show ();
                                        ctxMnu.Show (_g, e.Location, ToolStripDropDownDirection.Default);
                                }

                        }

                }

        }
}
