using System;
using Bodget.Logic;
using Db4objects.Db4o;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public class RulesOperation2Category: IBase
        {
                public long     /**/ id                 /**/{ get; set; }
                /// <summary>
                /// if propertyName (d'une opération)
                /// </summary>
                public string   /**/ propertyName       /**/{ get; set; }
                /// <summary>
                /// contient la valeur dans value
                /// </summary>
                public string   /**/ value              /**/{ get; set; }
                /// <summary>
                /// alors affecter à l'opération à cet idCategory
                /// </summary>
                public long     /**/ idCategory         /**/{ get; set; }

                new public string ToString ()
                {
                        return string.Format ("{0} {1} {2} {3} {4} {5} {6} {7}"
                                , RESX.si
                                , propertyName
                                , RESX.contient
                                , value
                                , RESX.alors
                                , RESX.mettre
                                , RESX.dans
                                , this.Category ().nom
                                ).ToSentence ();
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        RulesOperation2Category obj = value as RulesOperation2Category;
                        return obj != null
                                && propertyName == obj.propertyName
                                && this.value == obj.value
                                && idCategory == obj.idCategory;
                }

                public override int GetHashCode ()
                {
                        return propertyName.GetHashCode ()
                                + value.GetHashCode ()
                                + idCategory.GetHashCode ();
                }
        }
}
