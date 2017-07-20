using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmReportViewer: Form
        {
                public ReportViewer reportViewer
                {
                        get { return reportViewer1; }
                }

                public FrmReportViewer (string titre = "")
                {
                        InitializeComponent ();
                        if (titre == "")
                        {
                                titre = RESX.FrmReportViewerTitle;
                        }
                        Text = titre;
                }

                private void FrmReportViewer_Load (object sender, EventArgs e)
                {

                        reportViewer1.RefreshReport ();
                }

                private void FrmReportViewer_FormClosing (object sender, FormClosingEventArgs e)
                {
                        try
                        {
                                if (reportViewer1 != null)
                                {
                                        if (reportViewer1.LocalReport != null)
                                        {
                                                reportViewer1.LocalReport.ReleaseSandboxAppDomain ();
                                        }
                                }
                        }
                        catch (Exception ex)
                        {
                                Console.WriteLine (ex);
                        }
                }
        }
}
