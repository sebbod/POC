using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodget.UserCtrl.CtrlExtension
{
        public class LabelEx: Label
        {
                public LabelEx ()
                {
                        MouseDown += lbl_MouseDown;
                        MouseMove += lbl_MouseMove;
                        MouseUp += lbl_MouseUp;
                }

                private void lbl_MouseDown (object sender, MouseEventArgs e)
                {
                        
                }

                private void lbl_MouseMove (object sender, MouseEventArgs e)
                {

                }

                private void lbl_MouseUp (object sender, MouseEventArgs e)
                {

                }
        }
}
