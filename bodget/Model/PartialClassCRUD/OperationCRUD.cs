
using Bodget.CRUD.Properties;
using Bodget.Data;
using Db4objects.Db4o.Types;
using Libod;
using Libod.Ctrl;
using Libod.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        partial class Operation: IBaseCRUD<Operation>, ICtrlItem, IComboItems<ICtrlItem>
        {
                public ICRUD<Operation> CRUD ()
                {
                        return _Operation4CRUD ?? (_Operation4CRUD = new Operation4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (Operation i in BaseMng<Operation>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems ().ToList ();
                }


        }

        public class Operation4CRUD: ICRUD<Operation>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Operation>> _propertiesCRUD = new List<IpropertyCRUD<Operation>> ();

                public Operation4CRUD (Operation o)
                {
                        _propertiesCRUD.Add (new crudNom<Operation> (o));
                }
                public List<IpropertyCRUD<Operation>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Operation Object
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
                                return RESX.operation;
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
