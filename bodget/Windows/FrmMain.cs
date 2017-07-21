using System.Collections;
using System.Linq;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using Bodget.RDLC;
using Bodget.UserCtrl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libod.Ctrl;
using Libod.DataType;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmMain: Form
        {
                public FrmMain ()
                {
                        InitializeComponent ();

                        SetText ();

                        CreateMenu ();


                        // /*
                        // * supprime les doublons de nom dans Category
                        // */
                        //Dictionary<string, Category> tmpDic = new Dictionary<string, Category> ();
                        //IList<Category> allCat = BaseMng<Category>.Instance.All;
                        //foreach (Category c in allCat)
                        //{
                        //        if (tmpDic.ContainsKey (c.nom))
                        //        {
                        //                BaseMng<Category>.Instance.Delete (c.id);
                        //        }
                        //        else
                        //        {
                        //              tmpDic.Add (c.nom, c);
                        //        }
                        //}

                }


                public ucCategoryContainer ucCategContainer { get; private set; }

                void ucDateSelector_ValueChange (object source, DateSelectorInfo e)
                {
                        ucCategContainer = ucCategoryContainer;
                        ucCategoryContainer.FilterByDateInfo = e;
                }

                void ucCombo_ValueChange (object source, ctrlItem e)
                {
                        ucCategContainer = ucCategoryContainer;
                        ucCategoryContainer.FilterByCompte = e.Value as Compte;
                }



                private void tsmPrint_Click (object sender, EventArgs e)
                {
                        //ReportMng rm = new ReportMng (ReportListEnum.MoisCategories).;
                        
                        ReportInformations ri = new ReportInformations ();

                        //ri.Datasource = new Dictionary<string, object> ();
                        //ri.Datasource.Add ("DataSet1", MoisCategoriesDataSrc.Get (ucCategoryContainer.FilterByDateInfo.dtStart, ucCategoryContainer.FilterByDateInfo.dtStop));
                        //ri.TypeReport = ReportListEnum.MoisCategories;
                        //ReportMng.createLocalize2FormReportViewer (ri);

                        //ReportInformations ri = new ReportInformations ();
                        ri.Datasource = new Dictionary<string, object> ();
                        ri.Datasource.Add ("DataSet1", MoisCategoriesBeneficiairesDataSrc.Get (ucCategoryContainer.FilterByDateInfo.dtStart, ucCategoryContainer.FilterByDateInfo.dtStop));
                        ri.TypeReport = ReportListEnum.MoisCategoriesBeneficiaires;
                        ReportMng.createLocalize2FormReportViewer (ri);
                }

                private void tsmRechercher_Click (object sender, EventArgs e)
                {
                        var frm = new FrmFind (this, null);
                        frm.Show (this);
                }

                private void tsmImportOperation_Click (object sender, EventArgs e)
                {
                        OpenFileDialog ofp = new OpenFileDialog ();
                        if (DialogResult.OK == ofp.ShowDialog (this))
                        {
                                string filePath = ofp.FileName;
                                try
                                {
                                        ImExport.FromBankFileOFX (filePath);
                                }
                                catch (Exception ex)
                                {
                                        MessageBox.Show (ex.Message, RESX.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                        }
                }

                private void tsmImportDataFiles_Click (object sender, EventArgs e)
                {
                        try
                        {
                                var frm = new FrmImExport (ImExport.ActionType.Import);
                                frm.Show ();
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show (ex.Message, RESX.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }

                private void tsmExport_Click (object sender, EventArgs e)
                {
                        try
                        {
                                var frm = new FrmImExport (ImExport.ActionType.Export);
                                frm.Show ();
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show (ex.Message, RESX.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }



                private void tsmAffichages_Click (object sender, EventArgs e)
                {
                        //var frm = new FrmColumn (null);
                        //frm.ShowDialog (this);
                        using (var frm = new FrmBaseCRUD<PropertyHeader> (null))
                        {
                                frm.ShowDialog ();
                        }
                }



                private void tsmBanque_Click (object sender, EventArgs e)
                {
                        using (var frm = new FrmBaseCRUD<Banque> (null))
                        {
                                frm.ShowDialog ();
                        }
                }

                private void tsmCompte_Click (object sender, EventArgs e)
                {
                        using (var frm = new FrmBaseCRUD<Compte> (null))
                        {
                                frm.ShowDialog ();
                        }
                }

                private void tsmBeneficiare_Click (object sender, EventArgs e)
                {
                        using (var frm = new FrmBaseCRUD<Beneficiare> (null))
                        {
                                frm.ShowDialog ();
                        }
                }

                private void tsmCategotyCRUD_Click (object sender, EventArgs e)
                {
                        using (var frm = new FrmBaseCRUD<Category> (null))
                        {
                                frm.ShowDialog ();
                        }
                }

                private void tsmCategoryRules_Click (object sender, EventArgs e)
                {
                        var frm = new FrmCategorizationAuto (null);
                        frm.Show ();
                }

                private void tsmAppliquerLesRegles_Click (object sender, EventArgs e)
                {
                        foreach (Operation op in BaseMng<Operation>.Instance.All.Where (o => o.idCategory == 0 || o.idCategory == 1))
                        {
                                long idCategory = op.CategoryIdFromRules ();
                                if (op.idCategory != idCategory)
                                {
                                        BaseMng<Operation>.Instance.Update (op, o => o.idCategory = idCategory);
                                }
                        }
                }

                private void tsmiCheques_Click (object sender, EventArgs e)
                {
                        var frm = new FrmBaseGrid<Cheque> ();
                        frm.Show ();
                }










        }
}
