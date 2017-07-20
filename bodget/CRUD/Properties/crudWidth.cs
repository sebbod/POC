using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudWidth<T>: IpropertyCRUD<T>
                where T: IBase, IWidth
        {
                public T o { get; set; }

                public crudWidth (T mdl)
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
                public Label    /**/ lblWidth = new Label ();
                public TextBox  /**/ txtWidth = new TextBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lblWidth.Text = RESX.width.ToLabel ();
                        lblWidth.Left = Constantes.CTRL_MARGE;
                        lblWidth.Width = 74;
                        lblWidth.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblWidth);

                        txtWidth.Text = o.width.ToString();
                        txtWidth.Left = lblWidth.Width + Constantes.CTRL_MARGE;
                        txtWidth.Width = parentPanel.Width - txtWidth.Left - Constantes.CTRL_MARGE;
                        txtWidth.TextAlign = HorizontalAlignment.Left;
                        txtWidth.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (txtWidth);

                        parentPanel.Controls.Add (pnl);
                        return pnl;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                public Exception Validation ()
                {
                        txtWidth.Text = txtWidth.Text.Trim ();

                        if (txtWidth.Text.Length == 0)
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.une, RESX.width)).ToSentence ());
                                txtWidth.Focus ();
                                return ex;
                        }

                        if (txtWidth.Text.IsInt32 ())
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.un, RESX.nombre)).ToSentence ());
                                txtWidth.Focus ();
                                return ex;
                        }

                        return null;
                }

                public void Insert ()
                {
                        o.width = txtWidth.Text.ToInt32();
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.width = txtWidth.Text.ToInt32());
                }
        }
}
