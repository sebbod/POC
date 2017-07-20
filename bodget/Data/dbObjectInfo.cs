using Libod.Model;
using System;

namespace Bodget.Data
{
        public class dbObjectInfo: ICtrlItem
        {
                public dbObjectInfo (Type type)
                {
                        id = type.GetHashCode ();
                        nom = type.Name;
                        this.type = type;
                }

                public long     /**/ id                                 /**/{ get; set; }
                public string   /**/ nom                                /**/{ get; set; }
                public Type     /**/ type                               /**/{ get; set; }

        }
}
