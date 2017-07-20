using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;
using Libod.ReflectionEx;

namespace Bodget.Logic
{
        public static class ChequeEx
        {

                /// <summary>
                /// FK to the compte
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Compte Compte (this Cheque o)
                {
                        return BaseMng<Compte>.Instance.All.FirstOrDefault (x => x.id == o.idCompte);
                }

                /// <summary>
                /// FK to the Beneficiare
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Beneficiare Beneficiare (this Cheque o)
                {
                        return BaseMng<Beneficiare>.Instance.All.FirstOrDefault (x => x.id == o.idBeneficiare);
                }

                /// <summary>
                /// FK to the category
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Category Category (this Cheque o)
                {
                        return BaseMng<Category>.Instance.All.FirstOrDefault (x => x.id == o.idCategory);
                }

                /// <summary>
                /// FK to the category
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Operation Operation (this Cheque o)
                {
                        return BaseMng<Operation>.Instance.All.FirstOrDefault (x => x.id == o.idOperation);
                }

                public static IEnumerable<ctrlItem> ComboLst (this Cheque o)
                {
                        yield return new ctrlItem { Text = ResourceText.BlankValue, Value = 0 };

                        foreach (Cheque y in BaseMng<Cheque>.Instance.All.Distinct ())
                        {
                                yield return new ctrlItem { Text = y.code, Value = y };
                        }
                }

                public static void CreatePropertiesHeaders (this Cheque o)
                {
                        var typeParent = typeof (Cheque);
                        if (BaseMng<PropertyHeader>.Instance.All.Count (x => x.typeParent == typeParent) != 0)
                        {
                                return; // OK elles sont déjà créés
                        }
                        foreach (var prop in o.GetPropertyTypeNameAttribute ())
                        {
                                BaseMng<PropertyHeader>.Instance.Insert (prop.CreatePropertyHeader (typeParent));
                        }
                }

        }
}
