using Db4objects.Db4o;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Banque: IBase
        {
                [Transient]
                private Banque4CRUD _Banque4CRUD;

                public long     /**/ id                 /**/{ get; set; }
                public string   /**/ code               /**/{ get; set; }
                public string   /**/ nom                /**/{ get; set; }
                public string   /**/ type               /**/{ get; set; }

                new public string ToString ()
                {
                        return RESX.CrochetOuvrant + id.ToString () + RESX.CrochetFermant + RESX.Space
                                + code + RESX.Space +
                                RESX.parentheseOuvrante + nom + RESX.parentheseFermante + RESX.Space +
                                type;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Banque obj = value as Banque;
                        return obj != null && code == obj.code;
                }

                public override int GetHashCode ()
                {
                        return code.GetHashCode ();
                }

        }
}
