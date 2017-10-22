using System;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudVisible<T>: IpropertyCRUD<T>
                where T: IBase, IVisible
        {
                public T o { get; set; }

                public crudVisible (T mdl)
                {
                        o = mdl;
                }
                public CRUDmode CRUDmode { get; set; }
                public crudVisible (T mdl, CRUDmode CRUDmode)
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
                public Label    /**/ lblVisible = new Label ();
                public CheckBox  /**/ chkVisible = new CheckBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lblVisible.Text = RESX.visible.ToLabel ();
                        lblVisible.Left = Constantes.CTRL_MARGE;
                        lblVisible.Width = 74;
                        lblVisible.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblVisible);

                        chkVisible.Checked = o.visible;
                        chkVisible.Left = lblVisible.Width + Constantes.CTRL_MARGE;
                        chkVisible.Width = parentPanel.Width - chkVisible.Left - Constantes.CTRL_MARGE;
                        chkVisible.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (chkVisible);

                        parentPanel.Controls.Add (pnl);
                        return pnl;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                public Exception Validation ()
                {
                        return null;
                }

                public void Insert ()
                {
                        o.visible = chkVisible.Checked;
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.visible = chkVisible.Checked);
                }

                public void Delete ()
                {
                        throw new NotImplementedException ();
                }
        }
}
