using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;
using Libod.Model;

namespace Bodget.Logic
{
        public static class CompteHasBeneficiareEx
        {
                /// <summary>
                /// FK to the compte
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Compte> Comptes (this CompteHasBeneficiare o)
                {
                        return BaseMng<Compte>.Instance.All.Where (x => x.id == o.id1);  // id1 => idCompte
                }

                /// <summary>
                /// FK to the Beneficiare
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Beneficiare> Beneficiares (this CompteHasBeneficiare o)
                {
                        return BaseMng<Beneficiare>.Instance.All.Where (x => x.id == o.id2);    // id2 => idBeneficiare
                }

                /// <summary>
                /// FK to the Beneficiare
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<T> Beneficiares<T> (this CompteHasBeneficiare o)
                        where T: IBase, INom
                {
                        return BaseMng<T>.Instance.All.Where (x => x.id == o.id2);      // id2 => idBeneficiare
                }
        }
}
