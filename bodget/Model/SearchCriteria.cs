using Bodget.Logic;
using Libod;
using Libod.DataType;
using Libod.Model;
using Libod.ReflectionEx;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public class SearchCriteria//: IBase
        {
                //public long     /**/ id                 /**/{ get; set; }

                public DateSelectorInfo /**/ dateInfo   /**/{ get; set; }

                /// <summary>
                /// valeur rechercher
                /// </summary>
                public string   /**/ value              /**/{ get; set; }

                /// <summary>
                /// idOperationHeader pour recherche dans une colonne
                /// </summary>
                //public long?   /**/ idOperationHeader    /**/{ get; set; }

                /// <summary>
                /// pour recherche dans une colonne
                /// </summary>
                public PropertyTypeName propTypName     /**/{ get; set; }
                                
                /// <summary>
                /// idCategory pour recherche dans une catégorie
                /// </summary>
                public long?     /**/ idCategory         /**/{ get; set; }

                new public string ToString ()
                {
                        string str = RESX.research + value.AddSpaceBefore();
                        //if (idOperationHeader > 0)
                        if (propTypName != null)
                        {
                                str += RESX.dans.UnTrim () + propTypName.Name;
                        }
                        if (idCategory > 0)
                        {
                                str += RESX.de.UnTrim () + this.Category ().nom;
                        }
                        str += dateInfo.ToString ().AddSpaceBefore();
                        return str.ToSentence ();
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        SearchCriteria obj = value as SearchCriteria;
                        return obj != null
                                && this.value == obj.value
                                //&& idOperationHeader == obj.idOperationHeader
                                && propTypName == obj.propTypName
                                && idCategory == obj.idCategory;
                }

                public override int GetHashCode ()
                {
                        return value.GetHashCode ()
                                //+ idOperationHeader.GetHashCode ()
                                + propTypName.GetHashCode ()
                                + idCategory.GetHashCode ();
                }
        }
}
