using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libod.DataType;
using Microsoft.Reporting.WinForms;

namespace Bodget.RDLC
{
        public interface ISubReportDataByParam
        {
                String Param { get; }
        }

        partial class ReportMng
        {
                private readonly Dictionary<string, ISubReportDataByParam> _subreportDataByParam = new Dictionary<string, ISubReportDataByParam> ();

                /// <summary>
                /// Handler exécuté pour chaque subreport pour positionner les datasources.
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void LocalReport_SubreportProcessing (object sender, SubreportProcessingEventArgs e)
                {
                        //Dictionary<string, object> subreportDataSourcesByLC = new Dictionary<string, object> ();

                        //ReportListEnum subReport = (ReportListEnum)Enum.Parse (typeof (ReportListEnum), e.ReportPath);
                        //switch (subReport)
                        //{
                        //        case ReportListEnum.Logo:
                        //                //String reseau = e.Parameters["reseau"].Values[0];

                        //                break;
                        //        case ReportListEnum.CP_APCCOLL_ReportSuivi:
                        //        case ReportListEnum.CP_APCCOLL_2015_ReportSuivi:
                        //                String idLigneContratCollectif = e.Parameters["ligneContrat"].Values[0];
                        //                if (idLigneContratCollectif != null)
                        //                {
                        //                        MdlSuiviContratPartenariatAPCCollectif modelCollectif = (MdlSuiviContratPartenariatAPCCollectif)_subreportDataByParam[idLigneContratCollectif];
                        //                        if (modelCollectif != null)
                        //                        {
                        //                                SetDataSrc_Subreport (ref e, modelCollectif.Datasource);
                        //                        }
                        //                }
                        //                break;
                        //        case ReportListEnum.ReportEditionAnnuelleLigneContrat:
                        //                String idLigneContratEditionAnnuelle = e.Parameters["ligneContrat"].Values[0];
                        //                String idDestinatairePaiement = e.Parameters["destinatairePaiement"].Values[0];
                        //                if (!String.IsNullOrEmpty (idDestinatairePaiement))
                        //                {
                        //                        MdlReportEditionAnnuelleLigneContratDestinatairePaiementFille modelEditionDestinataire;

                        //                        ISubreportDataByParam modelEditionLigneContratISubreport;
                        //                        if (_subreportDataByParam.TryGetValue (idLigneContratEditionAnnuelle, out modelEditionLigneContratISubreport))
                        //                        {
                        //                                // essai en passant d'abord par la ligne de contrat
                        //                                MdlReportEditionAnnuelleContratLigneFille modelEditionLigneContrat = modelEditionLigneContratISubreport as MdlReportEditionAnnuelleContratLigneFille;
                        //                                List<MdlReportEditionAnnuelleLigneContratDestinatairePaiementFille> datasources =
                        //                                  (List<MdlReportEditionAnnuelleLigneContratDestinatairePaiementFille>)modelEditionLigneContrat.Datasource[MdlReportEditionAnnuelleLigneContratDatasources.lignesReportEditionAnnuelleDestinatairePaiement];
                        //                                modelEditionDestinataire = datasources.FirstOrDefault (x => x.Param == idDestinatairePaiement);
                        //                        }
                        //                        else
                        //                        {
                        //                                // Edition pour le destinataire de paiement indiqué
                        //                                modelEditionDestinataire = (MdlReportEditionAnnuelleLigneContratDestinatairePaiementFille)_subreportDataByParam[idDestinatairePaiement];
                        //                        }
                        //                        SetDataSrc_Subreport (ref e, modelEditionDestinataire.Datasource);
                        //                }
                        //                else if (!String.IsNullOrEmpty (idLigneContratEditionAnnuelle))
                        //                {
                        //                        // Edition globale de la ligne de contrat
                        //                        MdlReportEditionAnnuelleContratLigneFille modelEditionAnnuelle = (MdlReportEditionAnnuelleContratLigneFille)_subreportDataByParam[idLigneContratEditionAnnuelle];
                        //                        SetDataSrc_Subreport (ref e, modelEditionAnnuelle.Datasource);
                        //                }
                        //                break;
                        //}
                }

                /// <summary>
                /// Opérations nécessaires pour charger un subreport.
                /// </summary>
                /// <param name="lr"></param>
                /// <param name="report"></param>
                /// <param name="reportDataSources"></param>
                private void SubreportProcessingMng (ref LocalReport lr, ReportListEnum report, Dictionary<string, object> reportDataSources, MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth)
                {
                        //switch (report)
                        //{
                        //        case ReportListEnum.ListeEditionsModePaysage:
                        //                LoadSubreport (ref lr, ReportListEnum.CP_APCCOLL_2015_ReportSuivi);
                        //                ChargerSubreportDataByParams (reportDataSources, MdlSuiviContratDePartenariatDatasource.lignesCollectif);
                        //                break;
                        //        case ReportListEnum.ReportEditionAnnuelleContrat:
                        //                LoadSubreport (ref lr, ReportListEnum.Logo);
                        //                LoadSubreport (ref lr, ReportListEnum.ReportEditionAnnuelleLigneContrat);
                        //                ChargerSubreportDataByParams (reportDataSources, MdlReportEditionAnnuelleContratDatasources.lignesReportEditionAnnuelleLigneContrat);

                        //                LoadSubreport (ref lr, ReportListEnum.CP_PoleElec_ReportSuivi);
                        //                LoadSubreport (ref lr, ReportListEnum.CP_PoleElec_2015_ReportSuivi, tablixColumnWidth);
                        //                ChargerSubreportDataByParams (reportDataSources, MdlReportEditionAnnuelleContratDatasources.lignesPoleElec);
                        //                break;
                        //        default:
                        //                break;
                        //}
                        lr.SubreportProcessing += new SubreportProcessingEventHandler (LocalReport_SubreportProcessing);
                }

                #region Privé

                /// <summary>
                /// Charge un subReport à partir de son type.
                /// </summary>
                /// <param name="lr"></param>
                /// <param name="subreport"></param>
                private void LoadSubreport (ref LocalReport lr, ReportListEnum subreport, MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth = null)
                {
                        using (Stream stream = Assembly.GetAssembly (typeof (ReportMng)).GetManifestResourceStream ("Bodget.RDLC." + subreport.ToString () + ".rdlc"))
                        {
                                Dictionary<string, List<String>> dicTablixColumnWidth = null;
                                if (tablixColumnWidth != null && tablixColumnWidth.Count (x => x.Key == subreport) > 0)
                                {
                                        dicTablixColumnWidth = tablixColumnWidth.First (x => x.Key == subreport).Value;
                                }
                                StringReader sr = LocalizeReport (stream, dicTablixColumnWidth);
                                lr.LoadSubreportDefinition (subreport.ToString (), sr);
                        }
                }

                /// <summary>
                /// Chargement des objets (de type ISubreportDataByParam) par param pour mettre en datasource de chaque subReport.
                /// </summary>
                /// <param name="reportDataSources"></param>
                /// <param name="key"></param>
                private void ChargerSubreportDataByParams (Dictionary<string, object> reportDataSources, String key)
                {
                        IEnumerable<ISubReportDataByParam> mdlSuivi = reportDataSources[key] as IEnumerable<ISubReportDataByParam>;
                        if (mdlSuivi != null)
                        {
                                foreach (ISubReportDataByParam mdl in mdlSuivi)
                                {
                                        _subreportDataByParam[mdl.Param] = mdl;
                                }
                        }
                }

                /// <summary>
                /// Positionne les datasources pour les subReport.
                /// </summary>
                /// <param name="e"></param>
                /// <param name="ReportDataSources"></param>
                private void SetDataSrc_Subreport (ref SubreportProcessingEventArgs e, Dictionary<string, object> ReportDataSources)
                {
                        e.DataSources.Clear ();
                        if (e.DataSources.Count <= 0)
                        {
                                foreach (string dataSourceName in e.DataSourceNames)
                                {
                                        if (ReportDataSources.ContainsKey (dataSourceName))
                                        {
                                                BindingSource bs = new BindingSource ();
                                                bs.DataSource = ReportDataSources[dataSourceName];
                                                e.DataSources.Add (new ReportDataSource (dataSourceName, bs));
                                        }
                                        else
                                        {
                                                throw new ArgumentException (String.Format (ResourceRDLC.ReportMng_Invalid_DataSrc, dataSourceName));
                                        }
                                }
                        }
                        else
                        {
                                foreach (ReportDataSource rds in e.DataSources)
                                {
                                        if (ReportDataSources.ContainsKey (rds.Name))
                                        {
                                                BindingSource bs = new BindingSource ();
                                                bs.DataSource = ReportDataSources[rds.Name];
                                                rds.Value = bs;
                                        }
                                        else
                                        {
                                                throw new ArgumentException (String.Format (ResourceRDLC.ReportMng_Invalid_DataSrc, rds.Name));
                                        }
                                }
                        }
                }

                #endregion

        }
}
