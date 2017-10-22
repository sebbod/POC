using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudInitiales<T>: IpropertyCRUD<T>
                where T: IBase, IInitiales
        {
                public T o { get; set; }

                public crudInitiales (T mdl)
                {
                        o = mdl;
                }
                public CRUDmode CRUDmode { get; set; }
                public crudInitiales (T mdl, CRUDmode CRUDmode)
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
                public Label    /**/ lbl = new Label ();
                public TextBox  /**/ txt = new TextBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lbl.Text = RESX.initiales.ToLabel ();
                        lbl.Left = Constantes.CTRL_MARGE;
                        lbl.Width = 74;
                        lbl.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lbl);

                        txt.Text = o.initiales;
                        txt.Left = lbl.Width + Constantes.CTRL_MARGE;
                        txt.Width = Constantes.CTRL_HEIGHT * 2;
                        txt.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (txt);

                        parentPanel.Controls.Add (pnl);
                        return pnl;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                public Exception Validation ()
                {
                        txt.Text = txt.Text.Trim ();

                        if (txt.Text.Length == 0)
                        {
                                var ex = new Exception (String.Format (RESX.YouMustEnter, String.Format ("{0} {1}", RESX.vos, RESX.initiales)).ToSentence ());
                                txt.Focus ();
                                return ex;
                        }

                        return null;
                }

                public void Insert ()
                {
                        o.initiales = txt.Text;
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.initiales = txt.Text);
                }

                public void Delete ()
                {
                        throw new NotImplementedException ();
                }
        }
}
