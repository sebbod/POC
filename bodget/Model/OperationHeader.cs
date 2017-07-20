using System;
using Db4objects.Db4o;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        [Obsolete("use PropertyHeader",true)]
        public class OperationHeader: IBase
        {
                public long     /**/ id                 /**/{ get; set; }
                /// <summary>
                /// c'est le nom de la propriété dans l'objet Operation
                /// ex : dt 4 Operation.dt; mt 4 Operation.mt
                /// </summary>
                public string   /**/ propertyName       /**/{ get; set; }
                public Type     /**/ propertyType       /**/{ get; set; }
                /// <summary>
                /// ex dt => date; mt => montant
                /// </summary>
                public string   /**/ text               /**/{ get; set; }
                public bool     /**/ visible            /**/{ get; set; }
                public int      /**/ width              /**/{ get; set; }

                new public string ToString ()
                {
                        if (visible)
                        {
                                return "[" + id.ToString () + "] " + text + " (" + width + ") " + RESX.visible;
                        }
                        return "[" + id.ToString () + "] " + text + " (" + width + ")";
                }
        }
}
