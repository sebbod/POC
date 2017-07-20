using System;
using Db4objects.Db4o;
using Libod;
using Libod.Attribute;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Cheque: IBase
        {
                [Transient]
                private Cheque4CRUD _Cheque4CRUD;

                [Libod.Attribute.PropertyHeader ("id", 100, false)]
                public long     /**/ id                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("code", 80, true)]
                public string   /**/ code               /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("date", 100)]
                public DateTime /**/ dt                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("montant", 80)]
                public decimal  /**/ mt                 /**/{ get; set; }
                [Libod.Attribute.PropertyHeader ("nom")]
                public string   /**/ nom                /**/{ get; set; }
                /// <summary>
                /// FK -> Compte.id => source du chèque
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Compte", 20, false)]
                [ForeignKey (typeof (Compte))]
                public long     /**/ idCompte           /**/{ get; set; }
                /// <summary>
                /// FK -> Beneficiare.id => émetteur du chèque / permet de renseigner automatiquement idBeneficiare d'une operation
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Bénéficiaire", 200)]
                [ForeignKey (typeof (Beneficiare))]
                public long     /**/ idBeneficiare      /**/{ get; set; }
                /// <summary>
                /// FK -> Category.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Catégorie", 200)]
                [ForeignKey (typeof (Category))]
                public long     /**/ idCategory         /**/{ get; set; }
                /// <summary>
                /// FK -> Operation.id
                /// </summary>
                [Libod.Attribute.PropertyHeader ("Operation", 200)]
                [ForeignKey (typeof (Operation))]
                public long     /**/ idOperation        /**/{ get; set; }

                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id.ToString () + RESX.CrochetFermant + RESX.Space
                                + code + RESX.Space +
                                RESX.parentheseOuvrante + nom + RESX.parentheseFermante + RESX.Space +
                                mt;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Cheque obj = value as Cheque;
                        return obj != null 
                                && code == obj.code
                                && idCompte == obj.idCompte;
                }

                public override int GetHashCode ()
                {
                        return code.GetHashCode ();
                }

        }
}
