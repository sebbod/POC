using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        public static partial class CellEx
        {
                public static void AddClickController (this ICell c)
                {
                        c.AddController (new CellClick ());
                }

                public class CellClick: ControllerBase
                {
                        public override void OnClick (CellContext sender, EventArgs e)
                        {
                                base.OnClick (sender, e);
                                sender.Grid.Selection.SelectRow (sender.Position.Row, true);
                        }
                }
        }
}
