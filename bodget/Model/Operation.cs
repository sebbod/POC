using System;
using Db4objects.Db4o;
using Libod.Attribute;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Operation: IBase
        {
                [Transient]
                private Operation4CRUD _Operation4CRUD;

                [Libod.Attribute.PropertyHeader ("id", 100, false)]
                public long     /**/ id                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("date", 100)]
                public DateTime /**/ dt                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("montant", 80)]
                public decimal  /**/ mt                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("nom")]
                public string   /**/ nom                /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("type", 240)]
                public string   /**/ type               /**/{ get; set; }
                /// <summary>
                /// FK -> Compte.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Compte", 20, false)]
                [ForeignKey(typeof(Compte))]
                public long     /**/ idCompte           /**/{ get; set; }
                /// <summary>
                /// FK -> Beneficiare.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Bénéficiaire", 30)]
                [ForeignKey (typeof (Beneficiare))]
                public long     /**/ idBeneficiare      /**/{ get; set; }
                /// <summary>
                /// FK -> Category.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Catégorie", 20, false)]
                [ForeignKey (typeof (Category))]
                public long     /**/ idCategory         /**/{ get; set; }
                /// <summary>
                /// FK -> Cheque.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Chéque", 20, false)]
                [ForeignKey (typeof (Cheque))]
                public long     /**/ idCheque           /**/{ get; set; }

                new public string ToString ()
                {
                        return "[" + id.ToString () + "] " + nom + RESX.Space + type;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Operation obj = value as Operation;
                        return obj != null
                                && id == obj.id
                                && dt == obj.dt
                                && mt == obj.mt
                                && nom == obj.nom
                                && type == obj.type;
                }

                public override int GetHashCode ()
                {
                        return id.GetHashCode ()
                                + dt.GetHashCode ()
                                + mt.GetHashCode ()
                                + nom.GetHashCode ()
                                + type.GetHashCode ();
                }
        }
}
