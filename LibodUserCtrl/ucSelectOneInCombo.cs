using System;
using System.Collections;
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
using Libod.Model;

namespace LibodUserCtrl
{
        [Designer ("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
        public partial class ucSelectOneInCombo<T>: ucSelectListInCombo<T>
                where T: ICtrlItem
        {

                private void Init ()
                {
                        InitializeComponent ();

                        btnDel.Visible = false;
                        Height = MinimumSize.Height;
                }

                public ucSelectOneInCombo ()
                {
                        Init ();
                }

                public ucSelectOneInCombo (IEnumerable<ctrlItem<T>> ComboItems, IEnumerable<ctrlItem<T>> SelectedItems)
                        : base (ComboItems, SelectedItems)
                {
                        Init ();
                }

                protected override void btnAdd_Click (object sender, EventArgs e)
                {
                        if (cmbSelector.SelectedItem != null)
                        {
                                lstResult.Items.Add (cmbSelector.SelectedItem);
                                cmbSelector.Items.Remove (cmbSelector.SelectedItem);
                                btnAdd.Visible = false;
                                btnDel.Visible = true;
                        }
                }

                protected override void btnDel_Click (object sender, EventArgs e)
                {
                        if (lstResult.SelectedItem != null)
                        {
                                cmbSelector.Items.Add (lstResult.SelectedItem);
                                lstResult.Items.Remove (lstResult.SelectedItem);
                                btnAdd.Visible = true;
                                btnDel.Visible = false;
                        }
                }

        }
}
