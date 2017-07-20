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
        partial class Cheque: IBaseCRUD<Cheque>, ICode, INom
        {
                public ICRUD<Cheque> CRUD ()
                {
                        return _Cheque4CRUD ?? (_Cheque4CRUD = new Cheque4CRUD (this));
                }
        }

        public class Cheque4CRUD: ICRUD<Cheque>, ITransientClass
        {
                private readonly List<IpropertyCRUD<Cheque>> _propertiesCRUD = new List<IpropertyCRUD<Cheque>> ();

                public Cheque4CRUD (Cheque o)
                {
                        _propertiesCRUD.Add (new crudCode<Cheque> (o));
                        _propertiesCRUD.Add (new crudNom<Cheque> (o));
                        //_propertiesCRUD.Add (new crudGrid<Cheque> (o));
                }
                public List<IpropertyCRUD<Cheque>> propertiesCRUD { get { return _propertiesCRUD; } }

                public Cheque Object
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
                                return RESX.cheque;
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
