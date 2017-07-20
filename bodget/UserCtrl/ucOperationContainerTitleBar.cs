using System.ComponentModel;
using System.ComponentModel.Design;
using Bodget.Properties;
using System;
using System.Windows.Forms;

namespace Bodget.UserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucOperationContainerTitleBar: UserControl
        {
                public event EventHandler DetailVisibilityChange;

                new public event MouseEventHandler MouseDown;

                public ucOperationContainerTitleBar ()
                {
                        InitializeComponent ();

                        this.tlp.SuspendLayout ();
                        this.SuspendLayout ();

                        tlp.Dock = DockStyle.Fill;

                        this.tlp.ResumeLayout (false);
                        this.ResumeLayout (false);
                }

                private void ucOperationContainerTitleBar_Load (object sender, EventArgs e)
                {

                }

                private string _Text;
                public override string Text
                {
                        get { return _Text; }
                        set { _Text = value; lblTitle.Text = _Text; }
                }


                private int _OperationCount;
                public int OperationCount
                {
                        get { return _OperationCount; }
                        set { _OperationCount = value; lblOperationCount.Text = _OperationCount.ToString (); }
                }

                private decimal _Mt;
                public decimal Mt
                {
                        get { return _Mt; }
                        set { _Mt = value; lblMt.Text = _Mt.ToString (Settings.Default.FormatMoney); }
                }

                private bool _DetailVisible;

                public bool DetailVisible 
                {
                        get
                        {
                                return _DetailVisible;
                        }
                        set
                        {
                                _DetailVisible = value;
                                if (_DetailVisible)
                                {
                                        // show
                                        pbxDetailSwitchShowHide.Image = Resources.grp_detail_show_17x9;
                                }
                                else
                                {
                                        // hide
                                        pbxDetailSwitchShowHide.Image = Resources.grp_detail_hide_17x9;
                                }
                        }
                }

                private void pbxMove_MouseDown (object sender, MouseEventArgs e)
                {
                        if (MouseDown != null)
                        {
                                MouseDown (this, e);
                        }
                }

                private void pbxDetailSwitchShowHide_Click (object sender, EventArgs e)
                {
                        if (DetailVisibilityChange != null)
                        {
                                DetailVisibilityChange (this, e);
                        }

                        DetailVisible = !DetailVisible;
                }


        }
}
