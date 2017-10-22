using System;
using System.Drawing;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using System.Linq;
using Bodget.Windows;
using LibodUserCtrl.Extension.WinMenu;
using RESX = Libod.ResourceText;

namespace Bodget.UserCtrl
{
        partial class ucOperation
        {
                private ContextMenuStrip ctxMnu = new ContextMenuStrip ();
                private ToolStripMenuItem tsi;


                private void CreateCtxMnu ()
                {
                        //ctxMnu.ItemClicked += ctxMnu_ItemClicked;
                }

                private void ShowCtxMnu (Control ctrl, Point location)
                {
                        ctxMnu.Items.Clear ();

                        tsi = new ToolStripMenuItem ("Le bénéficiaire est");
                        ctxMnu.Items.Add (tsi);
                        ToolStripMenuItem mnuParentBeneficiare = ctxMnu.Items[ctxMnu.Items.Count - 1] as ToolStripMenuItem;

                        // n'afficher que les bénéficiares du compte de l'opération
                        if (Operation.Compte () != null && Operation.Compte ().Beneficiares () != null)
                        {
                                foreach (Beneficiare b in Operation.Compte ().Beneficiares ())
                                {
                                        tsi = new ToolStripMenuItemWithValue<Beneficiare> (b.nom, b, ctrl);
                                        mnuParentBeneficiare.DropDownItemClicked += ctxMnu_Beneficiare_ItemClicked;
                                        mnuParentBeneficiare.DropDownItems.Add (tsi);
                                }
                                //ctxMnu.Show ();
                        }

                        tsi = new ToolStripMenuItem ("Remboursement de");
                        ctxMnu.Items.Add (tsi);
                        ToolStripMenuItem mnuParentPersonne = ctxMnu.Items[ctxMnu.Items.Count - 1] as ToolStripMenuItem;
                        foreach (Personne p in BaseMng<Personne>.Instance.All)
                        {
                                tsi = new ToolStripMenuItemWithValue<Personne> (p.nom, p, ctrl);
                                mnuParentPersonne.DropDownItems.Add (tsi);
                                ToolStripMenuItem mnuPersonne = mnuParentPersonne.DropDownItems[mnuParentPersonne.DropDownItems.Count - 1] as ToolStripMenuItem;
                                /*  /
                                 * / construction du menu de chaque personne pour cette opération \
                                 */
                                // est-ce que cette personne doit déjà rembourser un montant sur cette opération ?
                                // si oui on propose le menu association d'une opération de remboursement positif
                                // si non on propose le menu pour saisir un montant (négatif) à rembourser
                                var remboursementsEnAttenteDe = Operation.Remboursements ().EnAttenteDe (p);
                                if (remboursementsEnAttenteDe.Any ())
                                {
                                        // si le remboursement n'est pas encore associé à une opération de remboursement c'est le moment de le faire
                                        tsi = new ToolStripMenuItem ("qui me rembourse avec");
                                        mnuPersonne.DropDownItems.Add (tsi);
                                        ToolStripMenuItem mnuQuiMeRembourseAvec = mnuPersonne.DropDownItems[mnuPersonne.DropDownItems.Count - 1] as ToolStripMenuItem;

                                        // liste de toutes les opérations avec remboursement positif de cette personne
                                        foreach (var op in p.OperationAvecRemboursementsPositifNonAssocieARemboursementNegatif ())
                                        {
                                                tsi = new ToolStripMenuItemWith2Values<Personne, Operation> (op.nom + RESX.Space + op.type, p, op, ctrl);
                                                mnuQuiMeRembourseAvec.DropDownItemClicked += ctxMnu_QuiMaRembourseAvec_ItemClicked;
                                                mnuQuiMeRembourseAvec.DropDownItems.Add (tsi);
                                        }
                                }
                                else
                                {
                                        // si pas encore de remboursement sur cette opération par cette personne
                                        tsi = new ToolStripMenuItemWithValue<Personne> ("qui vous doit ?", p, ctrl);
                                        mnuPersonne.DropDownItemClicked += ctxMnu_Personne_vousDoit_ItemClicked;
                                        mnuPersonne.DropDownItems.Add (tsi);

                                        // si pas encore de remboursement sur cette opération par cette personne
                                        tsi = new ToolStripMenuItemWithValue<Personne> ("qui vous donne ?", p, ctrl);
                                        mnuPersonne.DropDownItemClicked += ctxMnu_Personne_vousDonne_ItemClicked;
                                        mnuPersonne.DropDownItems.Add (tsi);
                                }

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

                void ctxMnu_Beneficiare_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
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
                        }
                }

                void ctxMnu_QuiMaRembourseAvec_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
                {
                        ToolStripItem clickedMenuItem = e.ClickedItem;

                        ToolStripMenuItemWith2Values<Personne, Operation> tsmi = clickedMenuItem as ToolStripMenuItemWith2Values<Personne, Operation>;

                        //var rbs = Operation.Remboursements ();
                        //var rWait = rbs.PositifDe (tsmi.Value1);

                        // ouvrir la fenêtre qui va bien
                        var rembRealiseDe = tsmi.Value2.Remboursements ().RealiseDe (tsmi.Value1);
                        var rembNegatif = Operation.Remboursements ().EnAttenteDe (tsmi.Value1);
                        if (rembRealiseDe.Count () > 1)
                        {
                                throw new InvalidProgramException ("Database is corrupt because in normal use you can't have 2 remboursements positif from the same personne on one operation");
                        }
                        if (rembNegatif.Count () > 1)
                        {
                                throw new InvalidProgramException ("Database is corrupt because in normal use you can't have 2 remboursements negatif from the same personne on one operation");
                        }
                        if (rembRealiseDe.Count () == 1 && rembNegatif.Count () == 1)
                        {
                                // on cloture les 2 opérations de remboursement
                                BaseMng<Remboursement>.Instance.Update (rembRealiseDe.First (), r => r.idOperationDeRemboursement = Operation.id);
                                BaseMng<Remboursement>.Instance.Update (rembNegatif.First(), r => r.idOperationDeRemboursement = tsmi.Value2.id);
                        }

                }

                void ctxMnu_Personne_vousDoit_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
                {
                        ToolStripItem clickedMenuItem = e.ClickedItem;

                        ToolStripMenuItemWithValue<Personne> tsmi = clickedMenuItem as ToolStripMenuItemWithValue<Personne>;

                        // ouvrir la fenêtre pour saisir un montant à rembourser
                        using (var frm = new FrmBaseCRUD<Remboursement> (new Remboursement { idPersonne = tsmi.Value.id, mt = 0 }))
                        {
                                frm.ShowDialog ();
                                if (frm.o.id > 0)
                                {
                                        BaseHasMng<OperationHasRemboursement>.Instance.Insert (new OperationHasRemboursement { id1 = Operation.id, id2 = frm.o.id });
                                }
                        }
                }

                void ctxMnu_Personne_vousDonne_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
                {
                        ToolStripItem clickedMenuItem = e.ClickedItem;

                        ToolStripMenuItemWithValue<Personne> tsmi = clickedMenuItem as ToolStripMenuItemWithValue<Personne>;

                        // ouvrir la fenêtre pour saisir un montant à rembourser
                        using (var frm = new FrmBaseCRUD<Remboursement> (new Remboursement { idPersonne = tsmi.Value.id, mt = 0 }))
                        {
                                frm.ShowDialog ();
                                if (frm.o.id > 0)
                                {
                                        BaseHasMng<OperationHasRemboursement>.Instance.Insert (new OperationHasRemboursement { id1 = Operation.id, id2 = frm.o.id });
                                }
                        }
                }
        }
}
