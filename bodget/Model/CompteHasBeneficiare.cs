using System;
using System.Collections.Generic;
using System.Linq;
using Bodget.Data;
using Db4objects.Db4o;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public class CompteHasBeneficiare: IBaseHas
        {
                /// <summary>
                /// to could use object IBaseHas like an IBase
                /// <para>o.id = container.Ext ().GetObjectInfo (o).GetInternalID ();</para>
                /// </summary>
                public long id { get; set; }

                /// <summary>
                /// Compte
                /// </summary>
                public long id1 { get; set; }

                /// <summary>
                /// Beneficiare
                /// </summary>
                public long id2 { get; set; }

                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id1.ToString () + RESX.CrochetFermant + RESX.Space +
                               RESX.CrochetOuvrant + id2.ToString () + RESX.CrochetFermant;
                }

                //public IEnumerable<T1> lstObj1<T1> (IBaseHas has)
                //        where T1: IBase
                //{
                //        return BaseMng<T1>.Instance.All.Where (x => x.id == has.id1);  // id1 => idCompte
                //}

                //public IEnumerable<T2> lstObj2<T2> (IBaseHas has)
                //        where T2: IBase
                //{
                //        return BaseMng<T2>.Instance.All.Where (x => x.id == has.id2);  // id1 => idBeneficiare
                //}

                public void UpdateLstId2InObj1<T1> (IBaseHas has)
                        where T1: IBase
                {
                        foreach (T1 o1 in BaseMng<T1>.Instance.All.Where (x => x.id == has.id1))
                        {
                                Compte oCpt = o1 as Compte;
                                foreach (Operation op in BaseMng<Operation>.Instance.All.Where (o => o.idCompte == oCpt.id))
                                {
                                        BaseMng<Operation>.Instance.Update (op, o => o.idBeneficiare = has.id2);
                                }
                        }
                }

                public void DeleteLstId2InObj1<T1> (IBaseHas has)
                        where T1: IBase
                {
                        foreach (T1 o1 in BaseMng<T1>.Instance.All.Where (x => x.id == has.id1))
                        {
                                Compte oCpt = o1 as Compte;
                                foreach (Operation op in BaseMng<Operation>.Instance.All.Where (o => o.idCompte == oCpt.id))
                                {
                                        BaseMng<Operation>.Instance.Update (op, o => o.idBeneficiare = 0);
                                }
                        }
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        CompteHasBeneficiare obj = value as CompteHasBeneficiare;
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
