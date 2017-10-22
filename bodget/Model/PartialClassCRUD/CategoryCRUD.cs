
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
        partial class Category: IBaseCRUD<Category>, ICtrlItem, IComboItems<ICtrlItem>
        {
                public ICRUD<Category> CRUD ()
                {
                        return _Category4CRUD ?? (_Category4CRUD = new Category4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (Category i in BaseMng<Category>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems().ToList();
                }
        }

        public class Category4CRUD: ICRUD<Category>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Category>> _propertiesCRUD = new List<IpropertyCRUD<Category>> ();

                public Category4CRUD (Category o)
                {
                        _propertiesCRUD.Add (new crudNom<Category> (o));
                }
                public List<IpropertyCRUD<Category>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Category Object
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
                                return RESX.Category;
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
