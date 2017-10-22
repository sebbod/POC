using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.RDLC
{
        public class PersonnesRemboursementsDataSrc
        {
                public string personne { get; set; }
                public string opeNegative { get; set; }
                public decimal mtNegatif { get; set; }
                public string opePositive { get; set; }
                public decimal mtPositif { get; set; }

                public static List<PersonnesRemboursementsDataSrc> Get ()
                {
                        var retLst = new List<PersonnesRemboursementsDataSrc> ();
                        foreach (var R in BaseMng<Remboursement>.Instance.All.Where (r => r.mt < 0))
                        {
                                // retrouve l'opération lié
                                var opeNeg = R.Operations ().Where (o => o.id != R.idOperationDeRemboursement);
                                if (opeNeg.Count () != 1)
                                {
                                        throw new InvalidProgramException ("un remboursement ne peut être lié qu'a une seul opération or là ce n'est pas le cas pour le remboursement d'id " + R.id + ". Veuillez corriger la base de donnée car elle est corps rompu ;-)");
                                }
                                // autre moyen de récupérer l'opeNeg
                                //var opeNeg = BaseHasMng<OperationHasRemboursement>.Instance.All.First (r => r.id2 == R.id).Operations().First();


                                var line = new PersonnesRemboursementsDataSrc ();

                                line.personne = R.Personne ().nom;
                                line.opeNegative = opeNeg.First ().ToString ();
                                line.mtNegatif = R.mt;

                                if (R.OperationDeRemboursement () != null)
                                {
                                        line.opePositive = R.OperationDeRemboursement ().ToString ();

                                        var lst = BaseHasMng<OperationHasRemboursement>.Instance.All.Where (ohr => ohr.id1 == R.idOperationDeRemboursement);
                                        var RembPositif = BaseMng<Remboursement>.Instance.All.First (o => o.id == lst.First().id2);
                                        line.mtPositif = RembPositif.mt;
                                }

                                retLst.Add (line);
                        }

                        return retLst;
                }

        }
}
