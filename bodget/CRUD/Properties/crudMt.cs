using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        /// <summary>
        /// Montant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class crudMontant<T>: IpropertyCRUD<T>
                where T: IBase, IMontant
        {
                public T o { get; set; }

                public crudMontant (T mdl)
                {
                        o = mdl;
                }

                public CRUDmode CRUDmode { get; set; }
                public crudMontant (T mdl, CRUDmode CRUDmode)
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
                public Label    /**/ lblMontant = new Label ();
                public TextBox  /**/ txtMontant = new TextBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lblMontant.Text = RESX.montant.ToLabel ();
                        lblMontant.Left = Constantes.CTRL_MARGE;
                        lblMontant.Width = 74;
                        lblMontant.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblMontant);

                        txtMontant.Text = o.mt.ToString();
                        txtMontant.Left = lblMontant.Width + Constantes.CTRL_MARGE;
                        txtMontant.Width = parentPanel.Width - txtMontant.Left - Constantes.CTRL_MARGE;
                        txtMontant.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (txtMontant);
                        if(txtMontant.Text.StartsWith("-"))
                        {
                                txtMontant.SelectionStart = 1;
                                txtMontant.SelectionLength = txtMontant.Text.Length - 1;
                        }
                        txtMontant.Focus ();

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
                        txtMontant.Text = txtMontant.Text.Trim ();

                        if (txtMontant.Text.Length == 0)
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.un, RESX.nom)).ToSentence ());
                                txtMontant.Focus ();
                                return ex;
                        }

                        if (!txtMontant.Text.IsDecimal ())
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.un, RESX.nombreDecimal)).ToSentence ());
                                txtMontant.Focus ();
                                return ex;
                        }

                        return null;
                }

                public void Insert ()
                {
                        o.mt = txtMontant.Text.ToDecimal();
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.mt = txtMontant.Text.ToDecimal());
                }

                public void Delete ()
                {
                        throw new NotImplementedException ();
                }
        }
}
