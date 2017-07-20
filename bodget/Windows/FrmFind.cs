using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using Bodget.UserCtrl;
using Libod;
using Libod.Ctrl;
using System;
using System.Linq;
using System.Windows.Forms;
using Libod.ReflectionEx;
using LibodUserCtrl;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmFind: Form
        {
                private SearchCriteria _searchCriteria;
                public SearchCriteria searchCriteria
                {
                        get
                        {
                                return _searchCriteria;
                        }
                        set
                        {
                                _searchCriteria = value;
                        }
                }

                private FrmMain parent { get; set; }

                private void InitCmb ()
                {
                        foreach (var oh in BaseMng<PropertyHeader>.Instance.All)
                        {
                                cmbPropertyName.Items.Add (new ctrlItem { Text = oh.nom, Value = oh });
                        }

                        foreach (var c in BaseMng<Category>.Instance.All)
                        {
                                cmbCategories.Items.Add (new ctrlItem { Text = c.nom, Value = c.id });
                        }
                }

                public FrmFind (IWin32Window owner, SearchCriteria searchCriteria)
                {
                        InitializeComponent ();

                        parent = owner as FrmMain;

                        if (parent == null)
                        {
                                throw new ArgumentOutOfRangeException ("parent = owner as FrmMain; => FAIL");
                        }

                        // pour initialiser avec la liste des années possible
                        ucDateSelector ucDateSelector1 = new ucDateSelector (new Operation ().GetYears ().ToList ());
                        ucDateSelector1.ValueChange += ucDateSelector1_ValueChange;
                        pnlDateSelector.Controls.Add (ucDateSelector1);
                        //ucDateSelector1.Dock = DockStyle.Fill;

                        Text = RESX.FrmFindTitle;

                        btnRechercher.Text = RESX.Find;
                        btnCancel.Text = RESX.Cancel;
                        btnClear.Text = RESX.clear;

                        lblValeurCherche.Text = lblPropertyName.Text = string.Format ("{0} {1}", RESX.valeur, RESX.recherchee).ToLabel ();
                        lblPropertyName.Text = string.Format ("{0} {1} {2}", RESX.dans, RESX.la, RESX.column).ToLabel ();
                        lblCategDest.Text = string.Format ("{0} {1} {2}", RESX.dans, RESX.la, RESX.Category).ToLabel ();


                        if (searchCriteria == null)
                        {
                                this.searchCriteria = new SearchCriteria ();
                        }
                        else
                        {
                                this.searchCriteria = searchCriteria;
                        }

                        InitCmb ();
                }


                private void ucDateSelector1_ValueChange (object source, Libod.DataType.DateSelectorInfo e)
                {
                        searchCriteria.dateInfo = e;
                }

                private void cmbPropertyName_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbPropertyName.SelectedItem == null)
                        {
                                searchCriteria.propTypName = null;
                        }
                        else
                        {
                                var PropertyNameSelected = cmbPropertyName.SelectedItem as ctrlItem;
                                var lstPropertyTypeName = new Operation ().GetPropertyTypeName ();
                                searchCriteria.propTypName = lstPropertyTypeName.First (p => p.Name == ((PropertyHeader)PropertyNameSelected.Value).propertyName);
                        }
                }

                private void cmbCategories_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbCategories.SelectedItem == null)
                        {
                                searchCriteria.idCategory = null;
                        }
                        else
                        {
                                searchCriteria.idCategory = (long)(cmbCategories.SelectedItem as ctrlItem).Value;
                        }
                }

                private bool Validation ()
                {

                        txtValue.Text = txtValue.Text.Trim ();
                        if (txtValue.Text.Length == 0)
                        {
                                txtMsgInfo.Text = String.Format ("{0} {1} {2} {3} {4} {5} {6}"
                                        , RESX.vous, RESX.devez, RESX.saisir, RESX.une, RESX.valeur, RESX.aAccentue, RESX.recherchee)
                                        .ToSentence ();
                                txtValue.Focus ();
                                return false;
                        }

                        return true;
                }


                private void btnFind_Click (object sender, EventArgs e)
                {
                        if (!Validation ())
                        {
                                return;
                        }

                        searchCriteria.value = txtValue.Text;

                        FindValue ();
                }

                private void FindValue ()
                {
                        txtMsgInfo.Text = searchCriteria.ToString ();
                        //throw new NotImplementedException ();
                        //ucCategoryContainer resultat = new ucCategoryContainer (searchCriteria);
                        //pnlResultat.Controls.Add (resultat);
                        //resultat.Dock = DockStyle.Fill;
                        //resultat.RefreshCategories ();
                        parent.ucCategContainer.SearchCriteria = searchCriteria;
                        parent.ucCategContainer.RefreshCategories ();
                }




                private void btnCancel_Click (object sender, EventArgs e)
                {
                        Close ();
                }

                private void btnClear_Click (object sender, EventArgs e)
                {
                        throw new NotImplementedException ();
                }







        }
}
