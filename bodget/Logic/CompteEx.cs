using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.Logic
{
        public static class CompteEx
        {

                /// <summary>
                /// FK to the banque
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static Banque Banque (this Compte o)
                {
                        return BaseMng<Banque>.Instance.All.FirstOrDefault (x => x.id == o.idBanque);
                }

                /// <summary>
                /// FK to the CompteHasBeneficiare => Beneficiare
                /// </summary>
                /// <param name="o"></param>
                /// <returns></returns>
                public static IEnumerable<Beneficiare> Beneficiares (this Compte o)
                {
                        var has = BaseHasMng<CompteHasBeneficiare>.Instance.All.Where (x => x.id1 == o.id);
                        foreach (var h in has)
                        {
                                foreach (var i in h.Beneficiares ())
                                {
                                        yield return i;
                                }
                        }
                }

                public static IEnumerable<ctrlItem> ComboLst (this Compte o)
                {
                        yield return new ctrlItem {Text = ResourceText.BlankValue, Value = 0 };

                        foreach (Compte y in BaseMng<Compte>.Instance.All.Distinct ())
                        {
                                yield return new ctrlItem { Text = y.code, Value = y };
                        }
                }

                public static Compte CreateWithDefaultValue (this Compte o, string code, string type, string bankCode)
                {
                        var b = BaseMng<Banque>.Instance.All.FirstOrDefault (c => c.code == bankCode);
                        if (b == null)
                        {
                                // creation d'une banque par defaut
                                b = new Banque ();
                                b.code = bankCode;
                                b.nom = ResourceText.AutoNomBanque;
                                BaseMng<Banque>.Instance.Insert (b);
                        }

                        // creation d'un compte par defaut
                        o.code = code;
                        o.nom = ResourceText.AutoNomCompte;
                        o.type = type;
                        o.idBanque = b.id;
                        BaseMng<Compte>.Instance.Insert (o);

                        // création d'un bénéficiare par defaut
                        var beneficiare = BaseMng<Beneficiare>.Instance.All.FirstOrDefault (c => c.nom == ResourceText.AutoNomBeneficiare);
                        if (beneficiare == null)
                        {
                                beneficiare = new Beneficiare ();
                                beneficiare.nom = ResourceText.AutoNomBeneficiare;
                                BaseMng<Beneficiare>.Instance.Insert (beneficiare);
                        }

                        // création d'un lien entre le compte et le bénéficiare
                        var h = new CompteHasBeneficiare ();
                        h.id1 = o.id;
                        h.id2 = beneficiare.id;
                        BaseHasMng<CompteHasBeneficiare>.Instance.Insert (h);

                        return o;
                }
        }
}
