using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;
using Libod.Model;

namespace Bodget.Logic
{
        public static class OperationHasRemboursementEx
        {
                /// <summary>
                /// FK to the Operation
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Operation> Operations (this OperationHasRemboursement o)
                {
                        return BaseMng<Operation>.Instance.All.Where (x => x.id == o.id1);  // id1 => idOperation
                }

                /// <summary>
                /// FK to the Remboursement
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Remboursement> Remboursements (this OperationHasRemboursement o)
                {
                        return BaseMng<Remboursement>.Instance.All.Where (x => x.id == o.id2);    // id2 => idRemboursement
                }

                /// <summary>
                /// FK to the Remboursement
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<T> Remboursements<T> (this OperationHasRemboursement o)
                        where T: IBase, INom
                {
                        return BaseMng<T>.Instance.All.Where (x => x.id == o.id2);      // id2 => idRemboursement
                }
        }
}
