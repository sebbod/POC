using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGrid;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        static partial class GridEx
        {
                public static void AddKeyEventController<T> (this Grid g, Dictionary<Keys, Func<CellContext, object>> dicAction)
                {
                        g.Controller.AddController (new KeyEvent<T> (dicAction));
                }
        }

        public class KeyEvent<T>: SourceGrid.Cells.Controllers.ControllerBase
        {
                private Dictionary<Keys, Func<CellContext, object>> _dicAction;

                public KeyEvent (Dictionary<Keys, Func<CellContext, object>> dicAction)
                {
                        _dicAction = dicAction;
                }

                public override void OnKeyDown (SourceGrid.CellContext sender, KeyEventArgs e)
                {
                        base.OnKeyDown (sender, e);

                        if(_dicAction.ContainsKey(e.KeyCode))
                        {
                                _dicAction[e.KeyCode].Invoke (sender);
                        }
                }
        }

}
