using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudNom<T>: IpropertyCRUD<T>
                where T: IBase, INom
        {
                public T o { get; set; }

                public crudNom (T mdl)
                {
                        o = mdl;
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

                        lblNom.Text = RESX.nom.ToLabel ();
                        lblNom.Left = Constantes.CTRL_MARGE;
                        lblNom.Width = 74;
                        lblNom.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblNom);

                        txtNom.Text = o.nom;
                        txtNom.Left = lblNom.Width + Constantes.CTRL_MARGE;
                        txtNom.Width = parentPanel.Width - txtNom.Left - Constantes.CTRL_MARGE;
                        txtNom.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (txtNom);

                        parentPanel.Controls.Add (pnl);
                        return pnl;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                public Exception Validation ()
                {
                        txtNom.Text = txtNom.Text.Trim ();

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
                        o.nom = txtNom.Text;
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.nom = txtNom.Text);
                }
        }
}
