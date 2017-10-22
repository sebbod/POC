using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.CRUD.Properties;
using Bodget.Data;
using Bodget.Logic;
using Db4objects.Db4o.Types;
using Libod;
using System.Collections.Generic;
using Libod.Ctrl;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        //partial class Compte: IBaseCRUD<Compte>, IBaseCtrlItem, IColor, ISelectListInCombo<Compte>, ISelectListInCombo
        partial class Compte: IBaseCRUD<Compte>, ICtrlItem, IColor, ISelectListInCombo, IComboItems<ICtrlItem>
        {
                public ICRUD<Compte> CRUD ()
                {
                        return _Compte4CRUD ?? (_Compte4CRUD = new Compte4CRUD (this));
                }

                public IEnumerable<ctrlItem<ICtrlItem>> ComboItems ()
                {
                        foreach (Compte i in BaseMng<Compte>.Instance.All)
                        {
                                yield return new ctrlItem<ICtrlItem> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public ICollection<ctrlItem<ICtrlItem>> ComboItems4Cell ()
                {
                        return ComboItems ().ToList ();
                }

                public IEnumerable<ctrlItem<T>> ComboItems<T> () where T : ICtrlItem
                {
                        foreach (T i in BaseMng<T>.Instance.All)
                        {
                                yield return new ctrlItem<T> { id = i.id, Text = i.nom, Value = i };
                        }
                }

                public IEnumerable<ctrlItem<T>> SelectedItems<T> () where T: ICtrlItem
                {
                        var has = BaseHasMng<CompteHasBeneficiare>.Instance.All.Where (x => x.id1 == this.id);
                        foreach (var h in has)
                        {
                                foreach (T i in h.Beneficiares<T> ())
                                {
                                        yield return new ctrlItem<T> { id = i.id, Text = i.nom, Value = i };
                                }
                        }
                }
        }

        public class Compte4CRUD: ICRUD<Compte>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Compte>> _propertiesCRUD = new List<IpropertyCRUD<Compte>> ();

                public Compte4CRUD (Compte o)
                {
                        _propertiesCRUD.Add (new crudNom<Compte> (o));
                        _propertiesCRUD.Add (new crudColor<Compte> (o));
                        _propertiesCRUD.Add (new crudSelectListInCombo<Compte, CompteHasBeneficiare, Beneficiare> (o));
                }

                public List<IpropertyCRUD<Compte>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Compte Object
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

                private string ObjectNamePluriels
                {
                        get
                        {
                                return ObjectName + RESX.s;
                        }
                }


        }
}
