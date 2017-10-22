using Bodget.Logic;
using Db4objects.Db4o;
using Libod.Model;
using System.Drawing;
using System.Linq;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        public partial class Remboursement: IBase
        {
                [Transient]
                private Remboursement4CRUD _Remboursement4CRUD;

                public long     /**/ id                 /**/{ get; set; }
                public decimal  /**/ mt                 /**/{ get; set; }

                /// <summary>
                /// FK -> Operation.id
                /// Quand il vaut 0 c'est que la personne n'a pas encore remboursé (ou que l'utilisateur ne l'a pas marqué comme tel;-)
                /// </summary>
                public long     /**/ idOperationDeRemboursement           /**/{ get; set; }

                /// <summary>
                /// FK -> Personne.id
                /// Personne qui doit rembourser un montant sur une opération
                /// </summary>
                public long     /**/ idPersonne           /**/{ get; set; }

                /// <summary>
                /// [id] code (nom) type - Operation - 
                /// </summary>
                /// <returns></returns>
                new public string ToString ()
                {
                        var str = RESX.CrochetOuvrant + id.ToString () + RESX.CrochetFermant + RESX.Space +
                                this.Personne ().nom + RESX.Space;
                        if (mt > 0)
                        {
                                str +=  RESX.a + RESX.Space + RESX.remboursé + RESX.Space + mt;
                        }
                        else
                        {
                                str += RESX.doit + RESX.Space + RESX.rembourser + RESX.Space + mt;
                        }
                        if (idOperationDeRemboursement > 0)
                        {
                                str += RESX.Space + this.OperationDeRemboursement ().ToString ();
                        }
                        return str;
                }

                public override bool Equals (object value)
                {
                        if (value == null)
                        {
                                return false;
                        }
                        Remboursement obj = value as Remboursement;
                        return obj != null && id == obj.id;
                }

                public override int GetHashCode ()
                {
                        return id.GetHashCode ();
                }

        }

}
