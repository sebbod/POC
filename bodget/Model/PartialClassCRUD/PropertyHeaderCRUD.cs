
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
        partial class PropertyHeader: IBaseCRUD<PropertyHeader>, IWidth, IVisible, ICtrlItem, IComboItems<ICtrlItem>
        {
                public ICRUD<PropertyHeader> CRUD ()
                {
                        return _PropertyHeader4CRUD ?? (_PropertyHeader4CRUD = new PropertyHeader4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (PropertyHeader i in BaseMng<PropertyHeader>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems ().ToList ();
                }


        }

        public class PropertyHeader4CRUD: ICRUD<PropertyHeader>, ITransientClass
        {
                private readonly List<IpropertyCRUD<PropertyHeader>> _propertiesCRUD = new List<IpropertyCRUD<PropertyHeader>> ();

                public PropertyHeader4CRUD (PropertyHeader o)
                {
                        _propertiesCRUD.Add (new crudNom<PropertyHeader> (o));
                        _propertiesCRUD.Add (new crudWidth<PropertyHeader> (o));
                        _propertiesCRUD.Add (new crudVisible<PropertyHeader> (o));
                }
                public List<IpropertyCRUD<PropertyHeader>> propertiesCRUD { get { return _propertiesCRUD; } }

                public PropertyHeader Object
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
                                return RESX.propriete + RESX.Space + RESX.d_+RESX.header;
                        }
                }

                public string ObjectNamePluriels
                {
                        get
                        {
                                return RESX.propriete + RESX.s + RESX.Space + RESX.d_ + RESX.header;
                        }
                }
        }
}
