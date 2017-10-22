using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        /// <summary>
        /// seul l'affichage en lecture seul est codé pour l'instant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class crudOperation<T>: IpropertyCRUD<T>
                where T: IBase, IOperationDeRemboursement
        {
                public T o { get; set; }

                public crudOperation (T mdl)
                {
                        o = mdl;
                }
                public CRUDmode CRUDmode { get; set; }
                public crudOperation (T mdl, CRUDmode CRUDmode)
                {
                        o = mdl;
                        this.CRUDmode = CRUDmode;
                }
                public T Object
                {
                        get
                        {
                                o = BaseMng<T>.Instance.Get (o.id);
                                return o;
                        }
                }
                public Label    /**/ lblNom = new Label ();
                public TextBox  /**/ txtNom = new TextBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lblNom.Text = RESX.operation.ToLabel ();
                        lblNom.Left = Constantes.CTRL_MARGE;
                        lblNom.Width = 74;
                        lblNom.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblNom);

                        if (o.idOperationDeRemboursement > 0)
                        {
                                txtNom.Text = BaseMng<Operation>.Instance.Get (o.idOperationDeRemboursement).ToString();
                        }
                        txtNom.Left = lblNom.Width + Constantes.CTRL_MARGE;
                        txtNom.Width = parentPanel.Width - txtNom.Left - Constantes.CTRL_MARGE;
                        txtNom.Height = Constantes.CTRL_HEIGHT;
                        txtNom.Enabled = CRUDmode.write == CRUDmode;
                        pnl.Controls.Add (txtNom);



                        try
                        {
                                parentPanel.Controls.Add (pnl);
                        }
                        catch (ObjectDisposedException odex)
                        {
                                parentPanel.Controls.Add (pnl);
                        }
                        return pnl;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                public Exception Validation ()
                {
                        txtNom.Text = txtNom.Text.Trim ();

                        if (CRUDmode == Libod.Model.CRUDmode.read)
                        {
                                return null;
                        }

                        if (txtNom.Text.Length == 0)
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.un, RESX.nom)).ToSentence ());
                                txtNom.Focus ();
                                return ex;
                        }

                        return null;
                }

                public void Insert ()
                {
                        //o.idPersonne = txtNom.Text;
                        //BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        //BaseMng<T>.Instance.Update (o, x => x.nom = txtNom.Text);
                }

                public void Delete ()
                {
                        throw new NotImplementedException ();
                }
        }
}
