using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.RDLC
{
        public class MoisCategoriesBeneficiairesDataSrc
        {
                public int Annee { get; set; }
                public int Mois { get; set; }
                public string Category { get; set; }
                public string Beneficiare { get; set; }
                public decimal mt { get; set; }

                public static List<MoisCategoriesBeneficiairesDataSrc> Get (DateTime start, DateTime end)
                {
                        return BaseMng<Operation>.Instance.All.Where (o => o.dt >= start && o.dt <= end)
                                .Select (o => new MoisCategoriesBeneficiairesDataSrc
                                {
                                        Annee = o.dt.Year,
                                        Category = o.Category ().nom,
                                        Beneficiare = o.Beneficiare().nom,
                                        Mois = o.dt.Month,
                                        mt = o.mt
                                })
                                .ToList ();
                }

        }
}
