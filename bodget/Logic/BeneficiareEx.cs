using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.Logic
{
        public static class BeneficiareEx
        {
                /// <summary>
                /// FK to the CompteHasBeneficiare => Compte
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Compte> Comptes (this Beneficiare o)
                {
                        var has = BaseHasMng<CompteHasBeneficiare>.Instance.All.Where (x => x.id2 == o.id);
                        foreach (var h in has)
                        {
                                foreach (var i in h.Comptes ())
                                {
                                        yield return i;
                                }
                        }
                }
        }
}
