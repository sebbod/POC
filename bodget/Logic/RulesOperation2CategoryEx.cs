using Bodget.Data;
using Bodget.Model;
using System.Linq;

namespace Bodget.Logic
{
        public static class RulesOperation2CategoryEx
        {
                /// <summary>
                /// FK to the category
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Category Category (this RulesOperation2Category o)
                {
                        return BaseMng<Category>.Instance.All.FirstOrDefault (x=> x.id == o.idCategory);
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="op"></param>
                /// <returns>idCategory or default value (1)</returns>
                public static long CategoryIdFromRules (this Operation op)
                {
                        var rules = BaseMng<RulesOperation2Category>.Instance.All;

                        foreach (var r in rules.Where (o => o.propertyName == "nom"))
                        {
                                if (op.nom.Contains (r.value))
                                {
                                        return r.idCategory;
                                }
                        }
                        foreach (var r in rules.Where (o => o.propertyName == "type"))
                        {
                                if (op.type.Contains (r.value))
                                {
                                        return r.idCategory;
                                }
                        }

                        return 1;
                }
        }
}
