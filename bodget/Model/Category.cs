
using Db4objects.Db4o;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Category: IBase
        {
                [Transient]
                private Category4CRUD _Category4CRUD;

                public long     /**/ id                                 /**/{ get; set; }
                public string   /**/ nom                                /**/{ get; set; }

                new public string ToString ()
                {
                        return "[" + id.ToString () + "] " + nom;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Category obj = value as Category;
                        return obj != null && nom == obj.nom;
                }

                public override int GetHashCode ()
                {
                        return nom.GetHashCode ();
                }

                /*
                 * user preference
                 */
                public int      /**/ height4ucOperationContainer        /**/{ get; set; }
                public bool     /**/ isOpen4ucOperationContainer        /**/{ get; set; }

        }

}
