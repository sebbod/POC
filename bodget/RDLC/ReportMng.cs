using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Bodget.Windows;
using Libod.DataType;
using Microsoft.Reporting.WinForms;

namespace Bodget.RDLC
{
        /// <summary>
        /// Manager de lancement des raports de l'application
        /// </summary>
        public partial class ReportMng
        {
                private ReportListEnum _report;

                public ReportMng (ReportListEnum report)
                {
                        this._report = report;
                }

                private void SetParameter (ref LocalReport lr, Dictionary<string, object> ReportParameters)
                {
                        var reportParamterCollect = lr.GetParameters ();

                        if (reportParamterCollect.Count > 0)
                        {
                                foreach (ReportParameterInfo rps in reportParamterCollect)
                                {
                                        if (ReportParameters.ContainsKey (rps.Name))
                                        {
                                                ReportParameter rp = new ReportParameter (rps.Name, ReportParameters[rps.Name].ToString ());
                                                lr.SetParameters (rp);
                                        }
                                        else
                                        {
                                                throw new ArgumentException (String.Format (ResourceRDLC.ReportMng_Invalid_DataSrc4Parameter, rps.Name));
                                        }
                                }
                        }
                }

                private void SetDataSrc (ref LocalReport lr, Dictionary<string, object> reportDataSources)
                {
                        lr.DataSources.Clear ();
                        if (lr.DataSources.Count <= 0)
                        {
                                foreach (string dataSourceName in lr.GetDataSourceNames ())
                                {
                                        if (reportDataSources.ContainsKey (dataSourceName))
                                        {
                                                BindingSource bs = new BindingSource ();
                                                bs.DataSource = reportDataSources[dataSourceName];
                                                lr.DataSources.Add (new ReportDataSource (dataSourceName, bs));
                                        }
                                        else
                                        {
                                                throw new ArgumentException (String.Format (ResourceRDLC.ReportMng_Invalid_DataSrc, dataSourceName));
                                        }
                                }
                        }
                        else
                        {
                                foreach (ReportDataSource rds in lr.DataSources)
                                {
                                        if (reportDataSources.ContainsKey (rds.Name))
                                        {
                                                BindingSource bs = new BindingSource ();
                                                bs.DataSource = reportDataSources[rds.Name];
                                                rds.Value = bs;
                                        }
                                        else
                                        {
                                                throw new ArgumentException (String.Format (ResourceRDLC.ReportMng_Invalid_DataSrc, rds.Name));
                                        }
                                }
                        }
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="streamreport"></param>
                /// <param name="tablicColumWidth">Pour définir la taille des colonnes d'un tablix dynamiquement</param>
                /// <returns></returns> 
                private static StringReader LocalizeReport (Stream streamreport, Dictionary<string, List<String>> tablixColumnWidth = null)
                {
                        // Load RDLC file. 
                        XmlDocument doc = new XmlDocument ();
                        try
                        {
                                doc.Load (streamreport);
                        }
                        catch (XmlException)
                        {

                        }
                        // Create an XmlNamespaceManager to resolve the default namespace.
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager (doc.NameTable);
                        nsmgr.AddNamespace ("nm", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition");
                        nsmgr.AddNamespace ("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");

                        //Go through the nodes of XML document and localize
                        //the text of nodes Value, ToolTip, Label. 
                        foreach (string nodeName in new String[] { "Value", "ToolTip", "Label" })
                        {
                                //<Value rd:LocID="IDS_DCreat" 
                                foreach (XmlNode node in doc.DocumentElement.SelectNodes (String.Format ("//nm:{0}[@rd:LocID]", nodeName), nsmgr))
                                {
                                        String nodeValue = node.InnerText;
                                        if (String.IsNullOrEmpty (nodeValue) || !nodeValue.StartsWith ("="))
                                        {
                                                try
                                                {
                                                        String localizedValue = ResourceRDLC.ResourceManager.GetString (node.Attributes["rd:LocID"].Value);
                                                        if (!String.IsNullOrEmpty (localizedValue))
                                                        {
                                                                node.InnerText = localizedValue;
                                                        }
                                                        else
                                                        {
                                                                MessageBox.Show (node.Attributes["rd:LocID"].Value + " : " + ResourceRDLC.RessourceNonTrouvee);
                                                        }
                                                }
                                                catch (InvalidCastException)
                                                {

                                                }
                                        }
                                }
                        }


                        if (tablixColumnWidth != null)
                        {
                                foreach (KeyValuePair<string, List<String>> kvp in tablixColumnWidth)
                                {
                                        string tablixName = kvp.Key;
                                        List<String> colomnWidth = kvp.Value;

                                        foreach (XmlNode tablixNode in doc.DocumentElement.SelectNodes ("//nm:Tablix", nsmgr))
                                        {
                                                //String nodeValue = tablixNode.InnerText;

                                                if (tablixNode.Attributes["Name"].Value != tablixName)
                                                        continue;
                                                foreach (XmlNode Node in tablixNode.ChildNodes) // TablixBody
                                                {
                                                        foreach (XmlNode tablixColumns in Node.ChildNodes) // TablixColumns
                                                        {
                                                                int i = 0;
                                                                foreach (XmlNode tablixColumn in tablixColumns.ChildNodes) // TablixColumn
                                                                {
                                                                        if (i == colomnWidth.Count)
                                                                                break;
                                                                        XmlNode width = tablixColumn.LastChild;
                                                                        if (tablixColumn.Name != "TablixColumn" && width.Name != "Width")
                                                                                break;
                                                                        width.InnerText = colomnWidth[i++];
                                                                }
                                                        }
                                                        break;
                                                }
                                                break;
                                        }
                                }
                        }

                        return new StringReader (doc.DocumentElement.OuterXml);
                }

                private void createLocalizeReport (ref LocalReport lr, ReportListEnum report, Dictionary<string, object> ReportDataSources)
                {
                        createLocalizeReport (ref lr, report, ReportDataSources, null);
                }
                private void createLocalizeReport (ref LocalReport lr, ReportListEnum report, Dictionary<string, object> ReportDataSources, Dictionary<string, object> ReportParameters, MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth = null)
                {
                        using (Stream stream = Assembly.GetAssembly (typeof (ReportMng)).GetManifestResourceStream ("Bodget.RDLC." + report.ToString () + ".rdlc"))
                        {
                                Dictionary<string, List<String>> dicTablixColumnWidth = null;
                                if (tablixColumnWidth != null && tablixColumnWidth.Count (x => x.Key == report) > 0)
                                {
                                        dicTablixColumnWidth = tablixColumnWidth.First (x => x.Key == report).Value;
                                }

                                StringReader sr = LocalizeReport (stream, dicTablixColumnWidth);
                                lr.LoadReportDefinition (sr);
                                lr.EnableExternalImages = true;

                                // chargement des données à afficher
                                SetDataSrc (ref lr, ReportDataSources);

                                // chargement des paramètres
                                if (ReportParameters != null)
                                {
                                        SetParameter (ref lr, ReportParameters);
                                }

                                SubreportProcessingMng (ref lr, report, ReportDataSources, tablixColumnWidth);

                                lr.Refresh ();
                        }
                }

                public static void createLocalize2FormReportViewer (ReportInformations reportInformations)
                {
                        createLocalize2FormReportViewer (reportInformations, null);
                }
                public static void createLocalize2FormReportViewer (ReportInformations reportInformations, Dictionary<string, object> ReportParameters)
                {
                        ReportMng reportMng = new ReportMng (reportInformations.TypeReport.Value);
                        string frmTitle;
                        try
                        {
                                // il faut créer une ligne de ressource pour chaque rapport dans Bodget.RDLC.Ressources.reportConstantes
                                // pour que ça fonctionne et le nom de la ressource doit être IDS_FRM_TITLE_LeNomDeMonFichierRDLC
                                frmTitle = ResourceRDLC.ResourceManager.GetString (reportInformations.TypeReport.Value.ToString () + "Title");
                        }
                        catch
                        {
                                // titre non défini dans le fichier de ressources
                                frmTitle = "";
                        }

                        FrmReportViewer frm = new FrmReportViewer (frmTitle);
                        frm.reportViewer.SetDisplayMode (DisplayMode.PrintLayout);
                        LocalReport lr = frm.reportViewer.LocalReport;


                        reportMng.createLocalizeReport (ref lr, reportInformations.TypeReport.Value, reportInformations.Datasource, ReportParameters, reportInformations.tablixColumnWidth);
                        //frm.reportViewer.LocalReport = lr;
                        //frm.reportViewer.LocalReport.Refresh();
                        frm.reportViewer.RefreshReport ();
                        frm.ShowDialog ();
                }

                public static void createLocalize2EXCEL (ReportListEnum report, Dictionary<string, object> ReportDataSources, string excelFilePath)
                {
                        ReportMng reportMng = new ReportMng (report);
                        LocalReport lr = new LocalReport ();

                        reportMng.createLocalizeReport (ref lr, report, ReportDataSources);

                        // export
                        string format = string.Empty;
                        string mimeType = "";
                        string encoding = "";
                        string extension = "";
                        string[] streams = null;
                        Warning[] warnings = null;

                        byte[] bytes = lr.Render ("Excel", null, out mimeType, out encoding, out extension, out streams, out warnings);
                        using (FileStream fs = new FileStream (excelFilePath, FileMode.Create))
                        {
                                fs.Write (bytes, 0, bytes.Length);
                                fs.Close ();
                                //fs.Dispose();
                        }
                }

                public static void createLocalize2PDF (ReportListEnum report, Dictionary<string, object> ReportDataSources, string pdfFilePath, MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth = null)
                {
                        createLocalize2PDF (report, ReportDataSources, null, pdfFilePath, tablixColumnWidth);
                }

                public static void createLocalize2PDF (ReportListEnum report, Dictionary<string, object> ReportDataSources, Dictionary<string, object> ReportParameters, string pdfFilePath, MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth = null)
                {
                        ReportMng reportMng = new ReportMng (report);
                        LocalReport lr = new LocalReport ();

                        reportMng.createLocalizeReport (ref lr, report, ReportDataSources, ReportParameters, tablixColumnWidth);

                        // export
                        string format = string.Empty;
                        string mimeType = "";
                        string encoding = "";
                        string extension = "";
                        string[] streams = null;
                        Warning[] warnings = null;

                        byte[] bytes = lr.Render ("PDF", null, out mimeType, out encoding, out extension, out streams, out warnings);
                        using (FileStream fs = new FileStream (pdfFilePath, FileMode.Create))
                        {
                                fs.Write (bytes, 0, bytes.Length);
                                fs.Close ();
                                fs.Dispose ();
                        }
                }

        }

}
