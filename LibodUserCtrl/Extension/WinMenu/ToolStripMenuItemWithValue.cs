using System.Windows.Forms;

namespace LibodUserCtrl.Extension.WinMenu
{
        public class ToolStripMenuItemWithValue<T>: ToolStripMenuItem
        {
                public ToolStripMenuItemWithValue (string text, T Value, Control sender)
                        : base (text)
                {
                        this.Value = Value;
                        this.sender = sender;
                }

                public T Value { get; set; }
                public Control sender { get; set; }
        }


}
