using System.Linq;
using Libod.Win32;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Bodget.UserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucOperationContainer: UserControl
        {

                new public event MouseEventHandler MouseDown;

                /// <summary>
                /// Height without detail
                /// </summary>
                public int HeigthTitleBar { get; set; }

                public ucOperationContainer ()
                {
                        InitializeComponent ();
                        opContainer = pnl;      // ne pas faire dans le load
                        MouseIsInBottomEdge = false;
                        HeightMin = 50;
                        if (Parent != null)
                        {
                                HeightMax = Parent.Height - Top;
                        }
                        else
                        {
                                HeightMax = 600;
                        }
                }

                private void ucOperationContainer_Load (object sender, EventArgs e)
                {
                        var row = tlp.GetRow (ucTitleBar);
                        HeigthTitleBar = tlp.GetRowHeights ()[row];
                        DetailVisible = Category.isOpen4ucOperationContainer; // must set after HeigthTitleBar is set

                        this.tlp.SuspendLayout ();
                        this.SuspendLayout ();

                        tlp.AutoScroll = false;

                        ucTitleBar.Dock = DockStyle.Fill;

                        pnl.Dock = DockStyle.Fill;
                        pnl.AutoScroll = true;

                        HeigthWithDetail = Category.height4ucOperationContainer;

                        this.tlp.ResumeLayout (false);
                        this.ResumeLayout (false);
                }


                private Point MousePointOnParent (object sender, MouseEventArgs e)
                {
                        Point mouseLoc = new Point ();
                        Control childCtrl = sender as Control;
                        if (childCtrl == null)
                        {
                                throw new Exception ();
                        }
                        mouseLoc.X = e.X + childCtrl.Left;
                        mouseLoc.Y = e.Y + childCtrl.Top;
                        return mouseLoc;
                }

                private void pnl_Resize (object sender, EventArgs e)
                {
                        bool sbVisible = pnl.VerticalScroll.Visible;
                        int sbWidth = 0;
                        if (sbVisible)
                        {
                                sbWidth = SystemInformation.VerticalScrollBarWidth;
                        }

                        foreach (ucOperation ucOp in pnl.Controls.OfType<ucOperation> ())
                        {
                                ucOp.Width = pnl.Width - sbWidth;
                        }

                        foreach (ucOperationHeader ucOpHdr in pnl.Controls.OfType<ucOperationHeader> ())
                        {
                                ucOpHdr.Width = pnl.Width - sbWidth;
                        }
                }

                private void pnl_SizeChanged (object sender, EventArgs e)
                {
                        // pour ne pas afficher les scrollBarHorizontal qui ne serve à rien
                        // lors d'un redimentionnement qui rapetisse le panel
                        /*
                         * Mis en commentaire car consomme énormement de ressource CPU
                         */
                        //foreach (ucOperation ucOp in pnl.Controls.OfType<ucOperation> ())
                        //{
                        //        ucOp.Width--;
                        //}
                }

        }
}
