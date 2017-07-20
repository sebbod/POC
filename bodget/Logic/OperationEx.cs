using System;
using System.Reflection;
using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;
using Libod.ReflectionEx;

namespace Bodget.Logic
{
        public static class OperationEx
        {
                /// <summary>
                /// FK to the compte
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Compte Compte (this Operation o)
                {
                        return BaseMng<Compte>.Instance.All.FirstOrDefault (x => x.id == o.idCompte);
                }

                /// <summary>
                /// FK to the Beneficiare
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Beneficiare Beneficiare (this Operation o)
                {
                        return BaseMng<Beneficiare>.Instance.All.FirstOrDefault (x => x.id == o.idBeneficiare);
                }

                /// <summary>
                /// FK to the category
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Category Category (this Operation o)
                {
                        return BaseMng<Category>.Instance.All.FirstOrDefault (x => x.id == o.idCategory);
                }

                /// <summary>
                /// FK to the cheque
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Cheque Cheque (this Operation o)
                {
                        return BaseMng<Cheque>.Instance.All.FirstOrDefault (x => x.id == o.idCheque);
                }

                /// <summary>
                /// Format le nom de l'opération en un code chéque valide
                /// <para>testé uniquement pour le CA</para>
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static String ChequeCode (this Operation o)
                {
                        return o.nom.FirstChar(7);
                }

                /// <summary>
                /// Nombre de jour entre la date du chéque et la date de l'opération d'encaissement du chèque
                /// </summary>
                /// <param name="o"></param>
                /// <param name="cq"></param>
                /// <returns></returns>
                public static int ChequeEncaisseApres (this Operation o, Cheque cq)
                {
                        if (o.idCheque == 0)
                        {
                                BaseMng<Operation>.Instance.Update (o, x => x.idCheque = cq.id);
                        }
                        else
                        {
                                if (o.idCheque != cq.id)
                                {
                                        throw new Exception ("there is a problème o.idCheque != cq.id");
                                }
                        }
                        if (cq.dt == default(DateTime))
                        {
                                return 0;
                        }
                        return (int)(o.dt - cq.dt).TotalDays;

                }

                public static IEnumerable<ctrlItem> GetYears (this Operation o)
                {
                        yield return new ctrlItem { Text = ResourceText.BlankValue, Value = 0 };

                        foreach (int y in BaseMng<Operation>.Instance.All.Select (x => x.dt.Year).Distinct ())
                        {
                                yield return new ctrlItem { Text = y.ToString (), Value = y };
                        }
                }

                public static void CreatePropertiesHeaders (this Operation o)
                {
                        var typeParent = typeof (Operation);
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
