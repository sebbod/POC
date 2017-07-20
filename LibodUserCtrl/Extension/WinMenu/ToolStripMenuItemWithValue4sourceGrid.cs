using SourceGrid;
using System;
using System.Windows.Forms;

namespace LibodUserCtrl.Extension.WinMenu
{
        public class ToolStripMenuItemWithValue4sourceGrid<T>: ToolStripMenuItemWithValue<T>
        {

                public ToolStripMenuItemWithValue4sourceGrid (string text, T Value, Control sender, int iRselected, Func<ToolStripMenuItemWithValue4sourceGrid<T>, object> action)
                        : base (text, Value, sender)
                {
                        this.action = action;
                        this.iRselected = iRselected;
                }

                public int iRselected { get; set; }
                public Func<ToolStripMenuItemWithValue4sourceGrid<T>, object> action;

        }


}
