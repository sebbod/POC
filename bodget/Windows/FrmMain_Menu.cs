using System;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;
using System.Linq;
using Bodget.UserCtrl;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        partial class FrmMain
        {
                private ToolStrip tsFilter;
                private tsDateSelector tsDateSelector1;
                private tsComboCompte tsComboCompte1;

                private ToolStrip tsAction;

                private void CreateMenu ()
                {
                        tsFilter = new ToolStrip ();
                        tsComboCompte1 = new tsComboCompte ();
                        tsComboCompte1.ucCombo.ValueChange += ucCombo_ValueChange;
                        // Add items to the ToolStrip.
                        tsFilter.Items.Add (tsComboCompte1);
                        tsFilter.Width = toolStripContainer2.Width;
                        // Add the ToolStrip to the top panel of the ToolStripContainer.
                        toolStripContainer2.TopToolStripPanel.Controls.Add (tsFilter);

                        tsFilter = new ToolStrip ();
                        tsDateSelector1 = new tsDateSelector ();
                        tsDateSelector1.ucDateSelector.ValueChange += ucDateSelector_ValueChange;
                        // Add items to the ToolStrip.
                        tsFilter.Items.Add (tsDateSelector1);
                        tsFilter.Width = toolStripContainer2.Width;
                        // Add the ToolStrip to the top panel of the ToolStripContainer.
                        toolStripContainer2.TopToolStripPanel.Controls.Add (tsFilter);

                        tsAction = new ToolStrip ();
                        var tsBtnPrint = new ToolStripButton (RESX.Print);
                        tsBtnPrint.Click += tsmPrint_Click;
                        tsAction.Items.Add (tsBtnPrint);
                        toolStripContainer2.TopToolStripPanel.Controls.Add (tsAction);

                        tsAction = new ToolStrip ();
                        var tsBtnFind = new ToolStripButton (RESX.Find);
                        tsBtnFind.Click += tsmRechercher_Click;
                        tsAction.Items.Add (tsBtnFind);
                        toolStripContainer2.TopToolStripPanel.Controls.Add (tsAction);
                }
        }
}
