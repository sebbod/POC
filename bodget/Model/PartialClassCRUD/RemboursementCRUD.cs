using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bodget.CRUD.Properties;
using Bodget.Data;
using Db4objects.Db4o.Types;
using Libod;
using Libod.Ctrl;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        partial class Remboursement: IBaseCRUD<Remboursement>, IMontant, IPersonne, IOperationDeRemboursement
        {
                public ICRUD<Remboursement> CRUD ()
                {
                        return _Remboursement4CRUD ?? (_Remboursement4CRUD = new Remboursement4CRUD (this));
                }

                //public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                //{
                //        foreach (Remboursement i in BaseMng<Remboursement>.Instance.All)
                //        {
                //                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.ToString(), Value = i };
                //        }
                //}

                //public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                //{
                //        return ComboItems ().ToList ();
                //}

        }

        public class Remboursement4CRUD: ICRUD<Remboursement>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Remboursement>> _propertiesCRUD = new List<IpropertyCRUD<Remboursement>> ();

                public Remboursement4CRUD (Remboursement o)
                {
                        _propertiesCRUD.Add (new crudMontant<Remboursement> (o));
                        _propertiesCRUD.Add (new crudPersonne<Remboursement> (o, CRUDmode.read));
                        _propertiesCRUD.Add (new crudOperation<Remboursement> (o, CRUDmode.read));
                        
                }
                public List<IpropertyCRUD<Remboursement>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Remboursement Object
                {
                        get
                        {
                                return _propertiesCRUD.First ().Object;
                        }
                }

                public void CreateObject (Panel parentPanel)
                {
                        _propertiesCRUD.CreateObject (parentPanel);
                }

                public void Insert ()
                {
                        _propertiesCRUD.First ().Insert ();
                        if (_propertiesCRUD.Count > 1)
                        {
                                _propertiesCRUD.Skip (1).Update ();
                        }
                }

                public void Update ()
                {
                        _propertiesCRUD.Update ();
                }

                public void Delete ()
                {
                        var o = _propertiesCRUD.First ();

                        // supprimer d'abord tous les liens dans OperationHasRemboursement
                        BaseHasMng<OperationHasRemboursement>.Instance.DeleteAllLineWithId2 (o.Object.id);

                        var oD = DB4O.CreateInstanceOfBaseMng (o.Object.GetType ());
                        oD.Delete (o.Object.id);
                }

                public string frmTitle
                {
                        get
                        {
                                return string.Format (RESX.GestionDes, ObjectNamePluriels);
                        }
                }

                public string lblLstObjet
                {
                        get
                        {
                                return string.Format (RESX.ListDes_Existantes, ObjectNamePluriels).ToLabel ();
                        }
                }

                public string ObjectName
                {
                        get
                        {
                                return RESX.Remboursement;
                        }
                }

                public string ObjectNamePluriels
                {
                        get
                        {
                                return ObjectName + RESX.s;
                        }
                }
        }
}
