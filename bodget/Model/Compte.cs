using Bodget.Logic;
using Db4objects.Db4o;
using Libod.Model;
using System.Drawing;
using System.Linq;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Compte: IBase
        {
                [Transient]
                private Compte4CRUD _Compte4CRUD;

                public long     /**/ id                 /**/{ get; set; }
                public string   /**/ code               /**/{ get; set; }
                public string   /**/ nom                /**/{ get; set; }
                public string   /**/ type               /**/{ get; set; }
                public Color    /**/ color              /**/{ get; set; }

                /// <summary>
                /// FK -> Banque.id
                /// </summary>
                public long     /**/ idBanque           /**/{ get; set; }

                /// <summary>
                /// [id] code (nom) type - Banque - 
                /// </summary>
                /// <returns></returns>
                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id.ToString () + RESX.CrochetFermant + RESX.Space +
                                code + RESX.Space +
                                RESX.parentheseOuvrante + nom + RESX.parentheseFermante + RESX.Space +
                                type + RESX.Space + RESX.tiret + RESX.Space +
                                this.Banque ().ToString () + RESX.Space +
                                this.Beneficiares ().Count() + RESX.Space + RESX.Beneficiare;
                }
                
                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Compte obj = value as Compte;
                        return obj != null && code == obj.code;
                }

                public override int GetHashCode ()
                {
                        return code.GetHashCode ();
                }

        }

}
