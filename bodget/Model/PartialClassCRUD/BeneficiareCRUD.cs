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
        partial class Beneficiare: IBaseCRUD<Beneficiare>, IInitiales, ICtrlItem, IComboItems<ICtrlItem>
        {
                public ICRUD<Beneficiare> CRUD ()
                {
                        return _Beneficiare4CRUD ?? (_Beneficiare4CRUD = new Beneficiare4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (Beneficiare i in BaseMng<Beneficiare>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems ().ToList ();
                }

        }

        public class Beneficiare4CRUD: ICRUD<Beneficiare>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Beneficiare>> _propertiesCRUD = new List<IpropertyCRUD<Beneficiare>> ();

                public Beneficiare4CRUD (Beneficiare o)
                {
                        _propertiesCRUD.Add (new crudNom<Beneficiare> (o));
                        _propertiesCRUD.Add (new crudInitiales<Beneficiare> (o));
                }
                public List<IpropertyCRUD<Beneficiare>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Beneficiare Object
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
                                return RESX.Beneficiare;
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
