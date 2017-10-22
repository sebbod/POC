using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.Logic
{
        public static class RemboursementEx
        {
                /// <summary>
                /// FK to the Personne
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Personne Personne (this Remboursement o)
                {
                        return BaseMng<Personne>.Instance.All.FirstOrDefault (x => x.id == o.idPersonne);
                }

                /// <summary>
                /// FK to the Operation qui est associé au remboursement comme ayant servie à remboursé le montant à rembourser
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Operation OperationDeRemboursement (this Remboursement o)
                {
                        return BaseMng<Operation>.Instance.All.FirstOrDefault (x => x.id == o.idOperationDeRemboursement);
                }

                /// <summary>
                /// FK to the OperationHasRemboursement => Operation
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Operation> Operations (this Remboursement o)
                {
                        var has = BaseHasMng<OperationHasRemboursement>.Instance.All.Where (x => x.id2 == o.id);
                        foreach (var oHr in has)
                        {
                                foreach (var i in oHr.Operations ())
                                {
                                        yield return i;
                                }
                        }
                }


                /// <summary>
                /// FK to the OperationHasRemboursement => Remboursement d'une personne
                /// </summary>
                /// <param name="o"></param>
                /// <param name="p"></param>
                /// <returns></returns>
                public static IEnumerable<Remboursement> De (this IEnumerable<Remboursement> o, Personne p)
                {
                        foreach (var i in o)
                        {
                                if (i.idPersonne == p.id)
                                {
                                        yield return i;
                                }
                        }
                }

                public static IEnumerable<Remboursement> PositifDe (this IEnumerable<Remboursement> o, Personne p)
                {
                        return o.De (p).Where (r => r.mt > 0);
                }

                /// <summary>
                /// Liste des remboursements positifs non associé
                /// </summary>
                /// <param name="o"></param>
                /// <param name="p"></param>
                /// <returns></returns>
                public static IEnumerable<Remboursement> RealiseDe (this IEnumerable<Remboursement> o, Personne p)
                {
                        return o.PositifDe (p).Where (r => r.idOperationDeRemboursement == 0);
                }

                /// <summary>
                /// Liste des remboursements positifs associée à un remboursement négatif
                /// </summary>
                /// <param name="o"></param>
                /// <param name="p"></param>
                /// <returns></returns>
                public static IEnumerable<Remboursement> TermineDe (this IEnumerable<Remboursement> o, Personne p)
                {
                        return o.PositifDe (p).Where (r => r.idOperationDeRemboursement > 0);
                }

                public static IEnumerable<Remboursement> NegatifDe (this IEnumerable<Remboursement> o, Personne p)
                {
                        return o.De (p).Where (r => r.mt < 0);
                }

                /// <summary>
                /// Liste des remboursements négatif pas encore associé à une opération de remboursement positive pour une personne
                /// </summary>
                /// <param name="o"></param>
                /// <param name="p"></param>
                /// <returns></returns>
                public static IEnumerable<Remboursement> EnAttenteDe (this IEnumerable<Remboursement> o, Personne p)
                {
                        return o.NegatifDe (p).Where (r => r.idOperationDeRemboursement == 0);
                }
        }
}
