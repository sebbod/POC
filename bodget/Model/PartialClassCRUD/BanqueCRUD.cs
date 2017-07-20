using Bodget.CRUD.Properties;
using Db4objects.Db4o.Types;
using Libod;
using Libod.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RESX = Libod.ResourceText;

namespace Bodget.Model
{
        partial class Banque: IBaseCRUD<Banque>, INom
        {
                public ICRUD<Banque> CRUD ()
                {
                        return _Banque4CRUD ?? (_Banque4CRUD = new Banque4CRUD (this));
                }
        }

        public class Banque4CRUD: ICRUD<Banque>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Banque>> _propertiesCRUD = new List<IpropertyCRUD<Banque>> ();

                public Banque4CRUD (Banque o)
                {
                        _propertiesCRUD.Add (new crudNom<Banque> (o));
                }
                public List<IpropertyCRUD<Banque>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Banque Object
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
                                return RESX.Banque;
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
