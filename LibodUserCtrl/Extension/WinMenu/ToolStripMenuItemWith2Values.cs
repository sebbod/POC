using System.Windows.Forms;

namespace LibodUserCtrl.Extension.WinMenu
{
        public class ToolStripMenuItemWith2Values<T1,T2>: ToolStripMenuItem
        {
                public ToolStripMenuItemWith2Values (string text, T1 value1, T2 value2, Control sender)
                        : base (text)
                {
                        this.Value1 = value1;
                        this.Value2 = value2;
                        this.sender = sender;
                }

                public T1 Value1 { get; set; }
                public T2 Value2 { get; set; }
                public Control sender { get; set; }
        }


}
