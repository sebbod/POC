using System;
using Db4objects.Db4o;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class PropertyHeader: IBase
        {
                [Transient]
                private PropertyHeader4CRUD _PropertyHeader4CRUD;

                public long     /**/ id                 /**/{ get; set; }
                /// <summary>
                /// c'est le nom de la propriété dans l'objet
                /// ex avec objet Operation : dt 4 Operation.dt; mt 4 Operation.mt
                /// </summary>
                public string   /**/ propertyName       /**/{ get; set; }
                public Type     /**/ propertyType       /**/{ get; set; }
                /// <summary>
                /// ex avec objet Operation : dt 4 Operation.dt; mt 4 Operation.mt dans ce cas typeParent doit être typeof(Operation)
                /// </summary>
                public Type     /**/ typeParent         /**/{ get; set; }
                /// <summary>
                /// ex dt => date; mt => montant
                /// </summary>
                public string   /**/ nom               /**/{ get; set; }
                /// <summary>
                /// column visible ?
                /// </summary>
                public bool     /**/ visible            /**/{ get; set; }
                /// <summary>
                /// column size
                /// </summary>
                public int      /**/ width              /**/{ get; set; }

                new public string ToString ()
                {
                        if (visible)
                        {
                                return "[" + id.ToString () + "] " + nom + " (" + width + ") " + RESX.visible;
                        }
                        return "[" + id.ToString () + "] " + nom + " (" + width + ")";
                }
        }
}
