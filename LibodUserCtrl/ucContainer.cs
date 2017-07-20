using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace LibodUserCtrl
{
        //[Designer (typeof (CtrlDesigner))]
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucContainer: UserControl
        {
                public ucContainer ()
                {
                        InitializeComponent ();
                }

                [Category ("Appearance"), DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
                public Panel WorkingArea
                {
                        get
                        {
                                return this.pnl;
                        }
                }
        }
}
