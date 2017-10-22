using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.Logic
{
        public static class PersonneEx
        {


                /// <summary>
                /// FK to the OperationHasRemboursement => Operation avec remboursement positif d'une personne
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Operation> OperationAvecRemboursementsPositif (this Personne o)
                {
                        List<Operation> retLst = new List<Operation> ();
                        foreach (var oHr in BaseHasMng<OperationHasRemboursement>.Instance.All)
                        {
                                foreach (var i in oHr.Remboursements ().Where (r => r.idPersonne == o.id && r.mt > 0))
                                {
                                        retLst.AddRange (i.Operations ());
                                }
                        }
                        return retLst;
                }

                /// <summary>
                /// FK to the OperationHasRemboursement => Operation avec remboursement négatif d'une personne
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Operation> OperationAvecRemboursementsNegatif (this Personne o)
                {
                        List<Operation> retLst = new List<Operation> ();
                        foreach (var oHr in BaseHasMng<OperationHasRemboursement>.Instance.All)
                        {
                                foreach (var i in oHr.Remboursements ().Where (r => r.idPersonne == o.id && r.mt < 0))
                                {
                                        retLst.AddRange (i.Operations ());
                                }
                        }
                        return retLst;
                }

                /// <summary>
                /// FK to the OperationHasRemboursement => Operation avec remboursement positif d'une personne
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Operation> OperationAvecRemboursementsPositifNonAssocieARemboursementNegatif (this Personne o)
                {
                        List<Operation> retLst = new List<Operation> ();
                        foreach (var oHr in BaseHasMng<OperationHasRemboursement>.Instance.All)
                        {
                                foreach (var r in oHr.Remboursements ().Where (r => r.idPersonne == o.id && r.mt > 0 && r.idOperationDeRemboursement == 0))
                                {
                                        retLst.AddRange (r.Operations ());
                                }
                        }
                        return retLst;
                }
        }
}
