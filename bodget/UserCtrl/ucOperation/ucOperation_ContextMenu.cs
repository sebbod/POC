using System;
using System.Drawing;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using System.Linq;
using LibodUserCtrl.Extension.WinMenu;

namespace Bodget.UserCtrl
{
        partial class ucOperation
        {
                private ContextMenuStrip ctxMnu = new ContextMenuStrip ();
                private ToolStripMenuItem tsi;


                private void CreateCtxMnu ()
                {
                        ctxMnu.ItemClicked += ctxMnu_ItemClicked;
                }

                private void ShowCtxMnu (Control ctrl, Point location)
                {
                        ctxMnu.Items.Clear ();

                        // n'afficher que les bénéficiares du compte de l'opération
                        if (Operation.Compte () != null && Operation.Compte ().Beneficiares () != null)
                        {
                                foreach (Beneficiare b in Operation.Compte ().Beneficiares ())
                                {
                                        tsi = new ToolStripMenuItemWithValue<Beneficiare> (b.nom, b, ctrl);
                                        ctxMnu.Items.Add (tsi);
                                }
                                ctxMnu.Show ();
                        }

                        Show (ctrl, location);
                }

                private void Show (Control control, Point location)
                {
                        if (control == null)
                        {
                                throw new ArgumentNullException ("control");
                        }
                        
                        ctxMnu.Show (control, location, ToolStripDropDownDirection.Default);
                }

                void ctxMnu_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
                {
                        ToolStripItem clickedMenuItem = e.ClickedItem;

                        ToolStripMenuItemWithValue<Beneficiare> tsmi = clickedMenuItem as ToolStripMenuItemWithValue<Beneficiare>;
                        if (Operation.Beneficiare ().id != tsmi.Value.id)
                        {
                                // update base
                                BaseMng<Operation>.Instance.Update (Operation, x => x.idBeneficiare = tsmi.Value.id);

                                // update IHM
                                var ucOp = (ucOperation)tsmi.sender;
                                ucOp.GetLabels ().First (x => x.Name == "idBeneficiare").Text = tsmi.Value.initiales;
                                //foreach (Label lbl in ucOp.GetLabels ())
                                //{
                                //        //Console.WriteLine (lbl.Name);
                                //        if (lbl.Name == "idBeneficiare")
                                //        {
                                //                lbl.Text = tsmi.Value.initiales;
                                //                break;
                                //        }
                                //}
                        }
                }

        }
}
