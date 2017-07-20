using Db4objects.Db4o;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Beneficiare: IBase
        {
                [Transient]
                private Beneficiare4CRUD _Beneficiare4CRUD;

                public long     /**/ id                 /**/{ get; set; }
                public string   /**/ nom                /**/{ get; set; }
                public string   /**/ initiales          /**/{ get; set; }

                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id.ToString () + RESX.CrochetFermant + RESX.Space + nom + RESX.Space + 
                                RESX.CrochetOuvrant + initiales + RESX.CrochetFermant;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Beneficiare obj = value as Beneficiare;
                        return obj != null
                                && id == obj.id
                                && nom == obj.nom;
                }

                public override int GetHashCode ()
                {
                        return id.GetHashCode ()
                                + nom.GetHashCode ();
                }
        }

}
