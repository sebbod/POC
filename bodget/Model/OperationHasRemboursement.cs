using System;
using System.Linq;
using Bodget.Data;
using Db4objects.Db4o;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        /// <summary>
        /// une opération peut avoir plusieurs remboursements d'associés à elle mais elles auront dans ce cas une personne différente pour chaque remboursement
        /// et un remboursement ne peut être lié qu'a une seul opération
        /// </summary>
        public class OperationHasRemboursement: IBaseHas
        {
                /// <summary>
                /// to could use object IBaseHas like an IBase
                /// <para>o.id = container.Ext ().GetObjectInfo (o).GetInternalID ();</para>
                /// </summary>
                public long id { get; set; }

                /// <summary>
                /// Operation
                /// </summary>
                public long id1 { get; set; }

                /// <summary>
                /// Remboursement
                /// </summary>
                public long id2 { get; set; }


                public void UpdateLstId2InObj1<T1> (IBaseHas has)
                        where T1: IBase
                {
                        throw new NotImplementedException ();
                }

                public void DeleteLstId2InObj1<T1> (IBaseHas has)
                        where T1: IBase
                {
                        throw new NotImplementedException ();
                }

                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id1.ToString () + RESX.CrochetFermant + RESX.Space +
                               RESX.CrochetOuvrant + id2.ToString () + RESX.CrochetFermant;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        OperationHasRemboursement obj = value as OperationHasRemboursement;
                        return obj != null
                                && id1 == obj.id1
                                && id2 == obj.id2;
                }

                public override int GetHashCode ()
                {
                        return id1.GetHashCode ()
                                + id2.GetHashCode ();
                }

        }
}
