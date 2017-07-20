using System.Reflection;
using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using System;
using System.Linq;
using System.Windows.Forms;
using Libod.Model;
using Libod.ReflectionEx;
using RESX = Libod.ResourceText;

namespace Bodget.Windows
{
        public partial class FrmBaseCRUD<T>: Form
                where T: IBase, IBaseCRUD<T>, INom, new ()
        {

                private T _o;
                public T o
                {
                        get
                        {
                                return _o;
                        }
                        set
                        {
                                _o = value;
                                if (_o == null || _o.id == 0)
                                {
                                        btnAdd.Text = RESX.Add;
                                }
                                else
                                {
                                        btnAdd.Text = RESX.Save;
                                }
                                if (_o != null)
                                {
                                        _o.CRUD ().CreateObject (pnlCreateObject);      // Create IHM object from interface
                                }
                        }
                }

                public FrmBaseCRUD (T o)
                {
                        InitializeComponent ();

                        if (o == null)
                        {
                                this.o = new T ();
                        }
                        else
                        {
                                this.o = o;
                        }


                        Text = this.o.CRUD ().frmTitle;

                        btnAdd.Text = RESX.Add;
                        btnCancel.Text = RESX.Cancel;
                        btnDelete.Text = RESX.Delete;
                        btnDelete.Enabled = false;
                        lblLstObjet.Text = this.o.CRUD ().lblLstObjet;

                        // init
                        foreach (var r in BaseMng<T>.Instance.All)
                        {
                                lstObjet.Items.Add (new ctrlItem { Text = r.ToString (), Value = r });
                        }
                }


                private void lstObjet_SelectedIndexChanged (object sender, EventArgs e)
                {
                        if (lstObjet.SelectedItem == null)
                        {
                                return;
                        }

                        var item = lstObjet.SelectedItem as ctrlItem;
                        /* 
                         * Suite à un correctif dans insert et update qui mets directement à jour o 
                         * il n'est plus utile de faire le code pas beau suivant et j'en suis bien content
                         * 
                        o = ((T)item.Value).CRUD ().Object; // oui c'est un peu long 
                        // mais que ça "(T)item.Value" ça ne suffit pas 
                        // et y'a un bog de type ObjectDisposedException
                        // donc il faut regénérer l'objet depuis le début et ne pas se servir 
                        // d'un qui serait déja en mémoire (suite à un une demande d'affichage précédente de l'utilisateur)
                         */
                        o = (T)item.Value;
                }

                private bool Validation ()
                {
                        Exception ex = o.CRUD ().propertiesCRUD.Validation ();
                        if (ex != null)
                        {
                                txtMsgInfo.Text = ex.Message;
                                return false;
                        }
                        return true;
                }

                private void btnAdd_Click (object sender, EventArgs e)
                {
                        if (!Validation ())
                        {
                                return;
                        }

                        if (btnAdd.Text == RESX.Add)
                        {
                                Insert ();
                        }
                        else
                        {
                                // "Enregistrer"
                                Update2 ();
                        }
                }



                private void Insert ()
                {
                        try
                        {
                                o.CRUD ().Insert ();
                                lstObjet.Items.Add (new ctrlItem { Text = o.ToString (), Value = o });
                                o = new T ();
                        }
                        catch (OperationCanceledException ex)
                        {
                                txtMsgInfo.Text = String.Format ("{0} {1}", RESX.cette, String.Format (RESX.AlreadyExist, o.CRUD ().ObjectName)).ToSentence ();
                        }
                }

                private void Update2 ()
                {
                        try
                        {
                                o.CRUD ().Update ();
                                o = o.CRUD ().Object; // MAJ de l'objet local
                                int itemIndex = 0;
                                foreach (ctrlItem i in lstObjet.Items)
                                {
                                        if (((T)i.Value).id == o.id)
                                        {
                                                i.Value = o;
                                                i.Text = o.ToString ();
                                                lstObjet.Items[itemIndex] = lstObjet.Items[itemIndex];        // refresh
                                                break;
                                        }
                                        itemIndex++;
                                }
                        }
                        catch (OperationCanceledException ex)
                        {
                                txtMsgInfo.Text = String.Format ("{0} {1}", RESX.cette, String.Format (RESX.AlreadyExist, o.CRUD ().ObjectName)).ToSentence ();
                        }
                }

                private void btnCancel_Click (object sender, EventArgs e)
                {
                        Close ();
                }

                private void btnDelete_Click (object sender, EventArgs e)
                {

                }

                private void FrmBaseCRUD_FormClosed (object sender, FormClosedEventArgs e)
                {

                }



                //private void SetValue ()
                //{
                //        foreach (IpropertyCRUD p in o.CRUD ().propertiesCRUD)
                //        {
                //                foreach (Type tinterface in p.GetType ().GetInterfaces ())
                //                {
                //                        Console.WriteLine (tinterface.ToString ());
                //                        foreach (MethodInfo mi in tinterface.GetAllMethods ())
                //                        {
                //                                Console.WriteLine (mi.Name);
                //                                if (mi.Name == "CreateObject")
                //                                {
                //                                        Panel result = mi.Invoke (this.o, null) as Panel;
                //                                        if (result == null)
                //                                        {
                //                                                throw new ArgumentNullException (mi.Name + " failed to return a valid control");
                //                                        }
                //                                        pnlCreateObject.Controls.Add (result);
                //                                }
                //                        }
                //                }
                //        }
                //}




        }
}
