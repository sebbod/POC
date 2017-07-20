using System;
using Bodget.Data;
using Bodget.Model;
using System.Linq;
using RESX = Libod.ResourceText;
using Libod;

namespace Bodget.Windows
{
        partial class FrmMain
        {
                private void SetText ()
                {
                        Text = RESX.FrmMainTitle;

                        // MENU TEXT

                        //File
                        tsmFichier.Text = RESX.file.ToTitleCase ();
                        //      \
                        tsmPrint.Text = RESX.Print;
                        tsmRechercher.Text = RESX.Find;
                        tsmImport.Text = RESX.import.ToTitle();
                        //      \       \
                        tsmImportOperation.Text = (RESX.liste.ToTitle () + RESX.Space + RESX.d_ + RESX.operation + RESX.s + RESX.Space + RESX.banquaire + RESX.s).ToTitle ();
                        tsmImportDataFiles.Text = (RESX.file.ToTitle () + RESX.s + RESX.Space + RESX.de + RESX.Space + RESX.donne_ + RESX.e + RESX.s).ToTitle ();
                        tsmExport.Text = (RESX.export.ToTitle () + RESX.Space + RESX.des + RESX.Space + RESX.file + RESX.s).ToTitle ();

                        //Données
                        tsmData.Text = (RESX.donne_ + RESX.e + RESX.s).ToTitle ();
                        //      \
                        tsmBanque.Text = RESX.Banque + RESX.s;
                        tsmCompte.Text = RESX.Compte + RESX.s;
                        tsmBeneficiare.Text = RESX.Beneficiare + RESX.s;
                        tsmCategories.Text = RESX.Category + RESX.s;
                        //      \       \
                        tsmCategotyCRUD.Text = RESX.Manage;
                        tsmCategoryRules.Text = RESX.Rules;

                        //Options
                        tsmOptions.Text = RESX.Options;
                        //      \
                        tsmAffichages.Text = RESX.Display;

                }
        }
}
