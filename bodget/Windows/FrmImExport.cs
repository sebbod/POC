using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodget.Data;
using Db4objects.Db4o.Reflect.Generic;
using Libod;
using Libod.Ctrl;
using Libod.Model;
using LibodUserCtrl;
using LibodUserCtrl.Extension.WinDialog;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmImExport: Form
        {
                private ucSelectListInCombo<dbObjectInfo> ucLst;
                private ucSelectOneInCombo<dbObjectInfo> ucOne;

                public ImExport.ActionType actionType { get; set; }

                public FrmImExport (ImExport.ActionType actionType)
                {
                        this.actionType = actionType;

                        InitializeComponent ();



                        switch (actionType)
                        {
                                case ImExport.ActionType.Import:
                                        ucOne = new ucSelectOneInCombo<dbObjectInfo> (ImExport.GetTypeExportable (), null);
                                        ucOne.Text = string.Format (RESX._duFichierA_, RESX.nom, RESX.import).ToTitle ();
                                        pnl.Controls.Add (ucOne);

                                        btnAction.Text = RESX.import;
                                        btnAction.Click += btnAction_Click;

                                        Height = ucOne.Height + btnAction.Height + txtMsgInfo.Height + 60;
                                        break;
                                case ImExport.ActionType.Export:
                                        ucLst = new ucSelectListInCombo<dbObjectInfo> (ImExport.GetTypeExportable (), null);

                                        ucLst.Text = string.Format (RESX.ListDes_a_, RESX.file + RESX.s, RESX.export);
                                        pnl.Controls.Add (ucLst);

                                        btnAction.Text = RESX.export;
                                        btnAction.Click += btnAction_Click;
                                        break;
                        }
                }

                private void btnAction_Click (object sender, EventArgs e)
                {
                        using (var ffd = new FileFolderDialog ())
                        {
                                if (DialogResult.OK == ffd.ShowDialog (this))
                                {
                                        try
                                        {
                                                IEnumerable<dbObjectInfo> lst = null;
                                                switch (actionType)
                                                {
                                                        case ImExport.ActionType.Import:
                                                                lst = ucOne.SelectedValue;
                                                                break;
                                                        case ImExport.ActionType.Export:
                                                                lst = ucLst.SelectedValue;
                                                                break;
                                                }

                                                foreach (var i in lst)
                                                {
                                                        switch (actionType)
                                                        {
                                                                case ImExport.ActionType.Import:
                                                                        ImExport.FromFile (ffd.SelectedPath, i.type);
                                                                        break;
                                                                case ImExport.ActionType.Export:
                                                                        string filePath = Path.Combine (ffd.SelectedPath, i.nom);
                                                                        ImExport.ToFile (filePath, i.type);
                                                                        break;
                                                        }
                                                }
                                        }
                                        catch (Exception ex)
                                        {
                                                MessageBox.Show (ex.Message, RESX.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                }
                        }
                }


        }

}
