using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.RDLC
{
        public class MoisCategoriesDataSrc
        {
                public int Annee { get; set; }
                public int Mois { get; set; }
                public string Category { get; set; }
                public decimal mt { get; set; }

                public static List<MoisCategoriesDataSrc> Get (DateTime start, DateTime end)
                {
                        return BaseMng<Operation>.Instance.All.Where (o => o.dt >= start && o.dt <= end)
                                .Select ( o => new MoisCategoriesDataSrc
                                {
                                        Annee = o.dt.Year,
                                        Category = o.Category ().nom,
                                        Mois = o.dt.Month,
                                        mt = o.mt
                                })
                                .ToList ();
                }

        }
}
