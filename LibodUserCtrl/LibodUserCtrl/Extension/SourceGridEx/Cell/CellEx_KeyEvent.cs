using System.Windows.Forms;
using Libod;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        static partial class CellEx
        {
                public static void AddKeyEventController4decimal (this ICell c)
                {
                        c.AddController (new KeyEvent ());
                }

                public class KeyEvent: ControllerBase
                {

                        public override void OnKeyDown (SourceGrid.CellContext sender, KeyEventArgs e)
                        {
                                base.OnKeyDown (sender, e);
                                
                                if (e.KeyCode == Keys.Decimal)
                                {
                                        e = new KeyEventArgs (Keys.C);
                                  }
                        }
                }
        }
}
