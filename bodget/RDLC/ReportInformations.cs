using Libod.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bodget.RDLC
{
        /// <summary>
        /// Conteneur des informations nécessaires pour générer un report.
        /// </summary>
        public class ReportInformations
        {
                private Dictionary<string, object> _datasource;
                private ReportListEnum? _typeReport;
                private List<String> _messagesErreurs;
                private MultiKeyDictionary<ReportListEnum, string, List<String>> _tablixColumnWidth;

                public Dictionary<string, object> Datasource
                {
                        get { return _datasource; }
                        set { _datasource = value; }
                }

                public ReportListEnum? TypeReport
                {
                        get { return _typeReport; }
                        set { _typeReport = value; }
                }

                public List<string> MessagesErreurs
                {
                        get { return _messagesErreurs; }
                        set { _messagesErreurs = value; }
                }

                public String GetMessageErreur ()
                {
                        if (_messagesErreurs == null || !_messagesErreurs.Any ())
                        {
                                return null;
                        }
                        StringBuilder sb = new StringBuilder ();
                        bool estPremier = true;
                        foreach (String msg in _messagesErreurs)
                        {
                                if (!estPremier)
                                {
                                        sb.AppendLine ();
                                }
                                else
                                {
                                        estPremier = false;
                                }
                                sb.Append (msg);
                        }
                        return sb.ToString ();
                }

                public MultiKeyDictionary<ReportListEnum, string, List<String>> tablixColumnWidth
                {
                        get { return _tablixColumnWidth; }
                        set { _tablixColumnWidth = value; }
                }
        }

}
