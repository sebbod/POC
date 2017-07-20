using Bodget.Data;
using Bodget.Model;
using System.Linq;

namespace Bodget.Logic
{
        public static class SearchCriteriaEx
        {
                /*
                /// <summary>
                /// FK to the OperationHeader
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static OperationHeader OperationHeader (this SearchCriteria o)
                {
                        if (o.idOperationHeader == null)
                        {
                                return null;
                        }
                        return BaseMng<OperationHeader>.Instance.All.FirstOrDefault (x => x.id == o.idOperationHeader);
                }
                 * */
                /// <summary>
                /// FK to the category
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Category Category (this SearchCriteria o)
                {
                        if (o.idCategory == null)
                        {
                                return null;
                        }

                        return BaseMng<Category>.Instance.All.FirstOrDefault (x => x.id == o.idCategory);
                }

        }
}
