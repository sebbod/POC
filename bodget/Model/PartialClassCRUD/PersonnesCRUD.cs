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
        partial class Personne: IBaseCRUD<Personne>, IInitiales, ICtrlItem, IComboItems<ICtrlItem>
        {
                public ICRUD<Personne> CRUD ()
                {
                        return _Personne4CRUD ?? (_Personne4CRUD = new Personne4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (Personne i in BaseMng<Personne>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems ().ToList ();
                }

        }

        public class Personne4CRUD: ICRUD<Personne>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Personne>> _propertiesCRUD = new List<IpropertyCRUD<Personne>> ();

                public Personne4CRUD (Personne o)
                {
                        _propertiesCRUD.Add (new crudNom<Personne> (o));
                        _propertiesCRUD.Add (new crudInitiales<Personne> (o));
                }
                public List<IpropertyCRUD<Personne>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Personne Object
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
                                return RESX.Personne;
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
