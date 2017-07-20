using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        static partial class CellEx
        {
                public static void AddValueChangedController<T> (this ICell c, Func<CellContext, object> action)
                {
                        c.AddController (new CellValueChanged<T> (action));
                }

                public class CellValueChanged<T>: ControllerBase
                {
                        private Func<CellContext, object> _action;

                        public CellValueChanged (Func<CellContext, object> action)
                        {
                                _action = action;
                        }

                        public override void OnValueChanged (CellContext sender, EventArgs e)
                        {
                                base.OnValueChanged (sender, e);
                                _action.Invoke (sender);
                        }
                }
        }
}
