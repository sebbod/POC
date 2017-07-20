using System;
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

                ///// <summary>
                ///// idCompte
                ///// </summary>
                //public long id1
                //{
                //        get
                //        {
                //                return idCompte;
                //        }
                //        set
                //        {
                //                idCompte = value;
                //        }
                //}

                ///// <summary>
                ///// idBeneficiare
                ///// </summary>
                //public long id2
                //{
                //        get
                //        {
                //                return idBeneficiare;
                //        }
                //        set
                //        {
                //                idBeneficiare = value;
                //        }
                //}
                ///// <summary>
                ///// id1
                ///// </summary>
                //public long     /**/ idCompte           /**/{ get; set; }
                ///// <summary>
                ///// id2
                ///// </summary>
                //public long     /**/ idBeneficiare      /**/{ get; set; }

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
