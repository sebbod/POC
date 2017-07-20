using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;
using System.Linq;
using Bodget.Windows;
using Libod.ClassExtension.ControlEx;
using Libod.ReflectionEx;

namespace Bodget.UserCtrl
{
        partial class ucCategoryContainer
        {
                public SearchCriteria SearchCriteria { get; set; }

                public void RefreshCategories ()
                {
                        //this.tlp.SuspendLayout ();
                        //this.SuspendLayout ();

                        tlp.ClearRow ();

                        IList<Category> categoties = BaseMng<Category>.Instance.All;
                        if (SearchCriteria != null && SearchCriteria.idCategory != null)
                        {
                                categoties = categoties.Where (c => c.id == SearchCriteria.idCategory).ToList ();
                        }

                        int RowIndex = 0;
                        foreach (Category cat in categoties)
                        {
                                ucOperationContainer ucc = AddUC4Categorie (cat);

                                // pour une nouvelle catégorie qui n'aurait jamais été affiché
                                if (cat.height4ucOperationContainer == 0)
                                {
                                        BaseMng<Category>.Instance.Update (cat, c => c.height4ucOperationContainer = HEIGHT);
                                }

                                tlp.AddRow (cat.height4ucOperationContainer, RowIndex++, ucc);

                        }

                        //this.tlp.ResumeLayout (false);
                        //this.ResumeLayout (false);
                        //tlp.Refresh ();
                }

                private ucOperationContainer AddUC4Categorie (Category categ)
                {
                        ucOperationContainer ucc = new ucOperationContainer ();
                        ucc.Dock = DockStyle.Fill;
                        ucc.Height = categ.height4ucOperationContainer;
                        ucc.Name = categ.nom.Replace (" ", "_");

                        ucc.Category = categ;
                        ucc.DetailVisibilityChange += AccordionClick;
                        //ucc.Height = categ.height4ucOperationContainer;
                        ucc.DetailVisible = categ.isOpen4ucOperationContainer;
                        //ucc.MouseDown += ucc_MouseDown;
                        //ucc.MouseMove += ucc_MouseMove;
                        //ucc.MouseUp += ucc_MouseUp;
                        //Console.WriteLine ("AddUC4Categorie ([" + categ.id + "]-" + categ.nom + ");tlp.RowCount=" + tlp.RowCount);

                        /*
                         * Header pour les opérations
                         */
                        ucOperationHeader ucOpHdr = new ucOperationHeader ();
                        //ucOpHdr.SizeChanged += ucOpHdr_SizeChanged;
                        ucc.AddHeader (ucOpHdr);

                        /*
                         * liste des opérations
                         */
                        IList<Operation> operations = BaseMng<Operation>.Instance.All.Where (x => x.idCategory == categ.id).ToList ();
                        if (SearchCriteria != null)
                        {
                                if (SearchCriteria.propTypName != null)
                                {
                                        try
                                        {
                                                operations = operations.ToList ()
                                                                .Where (SearchCriteria.propTypName.Name, SearchCriteria.value)
                                                                .ToList ();
                                        }
                                        catch(Exception ex)
                                        {
                                                Debug.WriteLine (ex.Message);
                                                operations = operations.ToList ();
                                        }
                                }
                                else
                                {
                                        // TODO
                                        // ne gère actuellement que la recherche sur le montant si on a saisie
                                        // comme critère qu'une valeur
                                        decimal val;
                                        if (decimal.TryParse (SearchCriteria.value, out val))
                                        {
                                                operations = operations.Where (x => x.mt == val).ToList ();
                                        }
                                }
                                if (SearchCriteria.dateInfo != null)
                                {
                                        operations = operations.Where (x => x.dt >= SearchCriteria.dateInfo.dtStart
                                                                        && x.dt <= SearchCriteria.dateInfo.dtStop).ToList ();
                                }

                        }
                        else
                        {
                                // FilterByDateInfo
                                operations = operations.Where (x => x.dt >= FilterByDateInfo.dtStart
                                                                && x.dt <= FilterByDateInfo.dtStop).ToList ();
                                // FilterByCompte
                                if (FilterByCompte != null)
                                {
                                        operations = operations.Where (x => x.idCompte == FilterByCompte.id).ToList ();
                                }
                        }
                        foreach (var o in operations)
                        {
                                ucc.Add (new ucOperation (o));
                        }
                        return ucc;
                }

        }
}
