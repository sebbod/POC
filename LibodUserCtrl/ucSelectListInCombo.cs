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
        public partial class ucSelectListInCombo<T>: UserControl
                where T: ICtrlItem
        {
                /// <summary>
                /// sample can containt list of CompteHasBeneficiare object
                /// </summary>
                public IEnumerable<T> SelectedValue
                {
                        get
                        {
                                foreach (ctrlItem<T> ci in lstResult.Items.Cast<ctrlItem<T>> ().ToList())
                                {
                                        yield return ci.Value;
                                }
                        }
                }

                private void Init ()
                {
                        InitializeComponent ();
                }

                public ucSelectListInCombo ()
                {
                        Init ();
                }

                public ucSelectListInCombo (IEnumerable<ctrlItem<T>> ComboItems, IEnumerable<ctrlItem<T>> SelectedItems)
                {
                        Init ();

                        cmbSelector.Items.AddRange (ComboItems.ToArray ());

                        if (SelectedItems == null)
                        {
                                SelectedItems = new List<ctrlItem<T>> ();
                        }
                        // supprimer de la combo ceux qui sont déja sélectionné
                        foreach (ctrlItem<T> si in SelectedItems)
                        {
                                foreach (ctrlItem<T> cmbI in cmbSelector.Items)
                                {
                                        if (si.Value.id == cmbI.Value.id)
                                        {
                                                cmbSelector.Items.Remove (cmbI);
                                                break;
                                        }
                                }
                        }
                        // sélectionner le premier s'il en reste au moins un dans la combo
                        if (cmbSelector.Items.Count > 0)
                        {
                                cmbSelector.SelectedItem = cmbSelector.Items[0];
                        }
                        lstResult.Items.AddRange (SelectedItems.ToArray ());
                }

                public override string Text
                {
                        get
                        {
                                return base.Text;
                        }
                        set
                        {
                                base.Text = value;
                                lblTitle.Text = value;
                        }
                }

                protected virtual void btnAdd_Click (object sender, EventArgs e)
                {
                        if (cmbSelector.SelectedItem != null)
                        {
                                lstResult.Items.Add (cmbSelector.SelectedItem);
                                cmbSelector.Items.Remove (cmbSelector.SelectedItem);
                        }
                }

                protected virtual  void btnDel_Click (object sender, EventArgs e)
                {
                        if (lstResult.SelectedItem != null)
                        {
                                cmbSelector.Items.Add (lstResult.SelectedItem);
                                lstResult.Items.Remove (lstResult.SelectedItem);
                        }
                }
        }
}
