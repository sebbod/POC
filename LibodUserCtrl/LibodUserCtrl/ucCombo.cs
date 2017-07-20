using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libod.Ctrl;

namespace LibodUserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucCombo: UserControl
        {
                public delegate void ComboValueChangeEventHandler (object source, ctrlItem e);
                public event ComboValueChangeEventHandler ValueChange;

                private void Init ()
                {
                        InitializeComponent ();
                }

                public ucCombo ()
                {
                        Init ();
                }

                public ucCombo (string lblText, int lblWidth, List<ctrlItem> comboValues, int margin = 3)
                {
                        Init ();

                        if (comboValues != null)
                        {
                                cmbCombo.Items.Clear ();
                                foreach (var i in comboValues)
                                {
                                        cmbCombo.Items.Add (i);
                                }
                        }

                        lblLabel.Text = lblText;
                        lblLabel.Width = lblWidth;
                        cmbCombo.Left = lblWidth;
                        cmbCombo.Width = this.Width - lblWidth - (margin * 2);
                }

                private void cmbCombo_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbCombo.SelectedItem != null)
                        {
                                if (ValueChange != null)
                                {
                                        ValueChange (this, cmbCombo.SelectedItem as ctrlItem);
                                }
                        }
                }

        }
}
