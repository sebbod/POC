using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodget.UserCtrl
{
        public partial class ucOperationContainer
        {
                public int HeigthWithDetail { get; set; }

                public bool DetailVisible
                {
                        get
                        {
                                return ucTitleBar.DetailVisible;
                        }
                        set
                        {
                                ucTitleBar.DetailVisible = value;
                                if (ucTitleBar.DetailVisible)
                                {
                                        if (HeigthWithDetail > 0)
                                        {
                                                Height = HeigthWithDetail;
                                        }
                                }
                                else
                                {
                                        Height = HeigthTitleBar;
                                }
                        }
                }


                public event EventHandler DetailVisibilityChange;

                private void ucTitleBar_DetailVisibilityChange (object sender, EventArgs e)
                {
                        if (DetailVisibilityChange != null)
                        {
                                DetailVisibilityChange (this, e);
                        }
                        //Console.WriteLine (pnl.Location + " - " + pnl.Size + " - " + pnl.Controls.Count);
                }

                private void ucTitleBar_MouseDown (object sender, MouseEventArgs e)
                {
                        if (MouseDown != null)
                        {
                                MouseDown (this, e);
                        }
                        //Point mouseLoc = MousePointOnParent (sender, e);
                        //OnMouseDown (new MouseEventArgs (MouseButtons.Left, 1, mouseLoc.X, mouseLoc.Y, 0));
                }

        }
}
