using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using Libod.ReflectionEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmCategorizationAuto: Form
        {
                private RulesOperation2Category _rule;
                public RulesOperation2Category rule
                {
                        get
                        {
                                return _rule;
                        }
                        set
                        {
                                _rule = value;
                                if (_rule == null || _rule.id == 0)
                                {
                                        btnAdd.Text = RESX.Add;
                                }
                                else
                                {
                                        btnAdd.Text = RESX.Save;
                                }
                        }
                }

                private void InitCmb ()
                {
                        foreach (var r in BaseMng<RulesOperation2Category>.Instance.All)
                        {
                                lstRules.Items.Add (new ctrlItem { Text = r.ToString (), Value = r.id });
                        }

                        foreach (var oh in BaseMng<PropertyHeader>.Instance.All.Where (h => h.propertyType == typeof (string) && h.typeParent == typeof(Operation)))
                        {
                                cmbPropertyName.Items.Add (new ctrlItem { Text = oh.nom, Value = oh.propertyName });
                        }

                        foreach (var c in BaseMng<Category>.Instance.All)
                        {
                                cmbCategories.Items.Add (new ctrlItem { Text = c.nom, Value = c.id });
                        }
                }

                public FrmCategorizationAuto (RulesOperation2Category rule)
                {
                        InitializeComponent ();

                        Text = RESX.FrmCategorizationAutoTitle;

                        btnAdd.Text = RESX.Add;
                        btnCancel.Text = RESX.Cancel;
                        btnDelete.Text = RESX.Delete;
                        lblRules.Text = string.Format (RESX.ListDes_Existantes, RESX.column).ToLabel ();
                        lblTexteExistantPourColonne.Text = string.Format (RESX.ListDes_Existantes, RESX.column).ToLabel ();
                        string modele = string.Format ("{0} {1}", RESX.une, RESX.operation);
                        string property = string.Format ("{0} {1}", RESX.la, RESX.column);
                        lblPropertyName.Text = string.Format (RESX.IfInModeleTheProperty, modele, property).ToLabel ();
                        lblNomContient.Text = RESX.ContainThisText.ToLabel ();
                        lblCategDest.Text = RESX.ThenAddOperationInCategory.ToLabel ();


                        if (rule == null)
                        {
                                this.rule = new RulesOperation2Category ();
                        }
                        else
                        {
                                this.rule = rule;
                        }

                        InitCmb ();
                }

                private bool Validation ()
                {
                        if (cmbPropertyName.SelectedItem == null)
                        {
                                txtMsgInfo.Text = String.Format (RESX.YouMustToChooseInList, String.Format ("{0} {1}", RESX.une, RESX.column)).ToSentence ();
                                cmbPropertyName.Focus ();
                                return false;
                        }

                        txtContient.Text = txtContient.Text.Trim ();
                        if (txtContient.Text.Length == 0)
                        {
                                string data = String.Format ("{0} {1}", RESX.un, RESX.text);
                                string property = String.Format ("{0} {1} {2}", RESX.la, RESX.column, cmbPropertyName.SelectedText);
                                txtMsgInfo.Text = String.Format (RESX.YouMustEnterContainIn, data, property).ToSentence ();
                                txtContient.Focus ();
                                return false;
                        }

                        if (cmbCategories.SelectedItem == null)
                        {
                                txtMsgInfo.Text = String.Format (RESX.YouMustToChooseInList, String.Format ("{0} {1}", RESX.une, RESX.Category)).ToSentence ();
                                cmbCategories.Focus ();
                                return false;
                        }

                        return true;
                }

                private void btnAdd_Click (object sender, EventArgs e)
                {
                        if (!Validation ())
                        {
                                return;
                        }

                        rule.propertyName = (string)(cmbPropertyName.SelectedItem as ctrlItem).Value;
                        rule.value = txtContient.Text;
                        rule.idCategory = (long)(cmbCategories.SelectedItem as ctrlItem).Value;

                        if (btnAdd.Text == RESX.Add)
                        {
                                // ajouter la règle
                                Insert ();
                        }
                        else
                        {
                                // "Enregistrer"
                                Update ();
                        }

                }

                private void Insert ()
                {
                        try
                        {
                                BaseMng<RulesOperation2Category>.Instance.Insert (rule);
                                lstRules.Items.Add (new ctrlItem { Text = rule.ToString (), Value = rule.id });
                                rule = new RulesOperation2Category ();
                        }
                        catch (OperationCanceledException ex)
                        {
                                txtMsgInfo.Text = String.Format ("{0} {1}", RESX.cette, String.Format (RESX.AlreadyExist, RESX.rule)).ToSentence ();
                        }
                }

                private void Update ()
                {
                        try
                        {
                                BaseMng<RulesOperation2Category>.Instance.Update (rule, r => r.idCategory = rule.idCategory);
                                BaseMng<RulesOperation2Category>.Instance.Update (rule, r => r.propertyName = rule.propertyName);
                                BaseMng<RulesOperation2Category>.Instance.Update (rule, r => r.value = rule.value);
                                foreach (ctrlItem i in lstRules.Items)
                                {
                                        if ((long)i.Value == rule.id)
                                        {
                                                i.Text = rule.ToString ();
                                                lstRules.Refresh ();
                                                break;
                                        }
                                }
                        }
                        catch (OperationCanceledException ex)
                        {
                                txtMsgInfo.Text = String.Format ("{0} {1}", RESX.cette, String.Format (RESX.AlreadyExist, RESX.rule)).ToSentence ();
                        }
                }

                private void lstTextExistant_Click (object sender, EventArgs e)
                {
                        if (lstTextExistant.SelectedItem != null)
                        {
                                txtContient.Text = (lstTextExistant.SelectedItem as ctrlItem).Text;
                        }
                }

                private void cmbPropertyName_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (cmbPropertyName.SelectedItem == null)
                        {
                                return;
                        }

                        var PropertyNameSelected = cmbPropertyName.SelectedItem as ctrlItem;
                        lstTextExistant.Items.Clear ();

                        var op = new Operation ();
                        PropertyTypeName propTypName = op.GetPropertyTypeName ().First (p => p.Name == (string)PropertyNameSelected.Value);

                        var distinctOp4PropertyNameSelected = BaseMng<Operation>.Instance.All.ToList ()
                                                                                .SelectByPropertyName<Operation, string> (propTypName.Name)
                                                                                .Distinct ();
                        // Fill lstTextExistant
                        foreach (var c in distinctOp4PropertyNameSelected)
                        {
                                lstTextExistant.Items.Add (new ctrlItem { Text = c, Value = c });
                        }

                }

                private void lstRules_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (lstRules.SelectedItem == null)
                        {
                                return;
                        }

                        var item = lstRules.SelectedItem as ctrlItem;
                        rule = BaseMng<RulesOperation2Category>.Instance.All.FirstOrDefault (o => o.id == (long)item.Value);
                        foreach (ctrlItem i in cmbPropertyName.Items)
                        {
                                if (i.Text == rule.propertyName)
                                {
                                        cmbPropertyName.SelectedItem = i;
                                }
                        }
                        txtContient.Text = rule.value;
                        foreach (ctrlItem i in cmbCategories.Items)
                        {
                                if ((long)i.Value == rule.idCategory)
                                {
                                        cmbCategories.SelectedItem = i;
                                }
                        }
                }

                private void btnCancel_Click (object sender, EventArgs e)
                {
                        Close ();
                }

                private void btnDelete_Click (object sender, EventArgs e)
                {
                        BaseMng<RulesOperation2Category>.Instance.Delete (rule);
                        rule = new RulesOperation2Category ();
                }

                private void cmbCategories_SelectedIndexChanged (object sender, EventArgs e)
                {
                        var item = cmbCategories.SelectedItem as ctrlItem;
                        lstRules.Items.Clear ();
                        foreach (var r in BaseMng<RulesOperation2Category>.Instance.All.Where (c => c.idCategory == (long)item.Value))
                        {
                                lstRules.Items.Add (new ctrlItem { Text = r.ToString (), Value = r.id });
                        }
                }

        }
}
