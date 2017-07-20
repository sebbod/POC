using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Libod;
using Libod.Model;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudColor<T>: IpropertyCRUD<T>
                where T: IBase, IColor
        {
                private T o { get; set; }

                public crudColor (T mdl)
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
                public Label    /**/ lblColor = new Label ();
                public TextBox  /**/ txtColor = new TextBox ();
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT;
                        pnl.Dock = DockStyle.Bottom;

                        lblColor.Text = RESX.couleur.ToLabel ();
                        lblColor.Left = Constantes.CTRL_MARGE;
                        lblColor.Width = 74;
                        lblColor.Height = Constantes.CTRL_HEIGHT;
                        pnl.Controls.Add (lblColor);

                        txtColor.BackColor = o.color;
                        txtColor.Left = lblColor.Width + Constantes.CTRL_MARGE;
                        txtColor.Width = Constantes.CTRL_HEIGHT;
                        txtColor.Height = Constantes.CTRL_HEIGHT;
                        txtColor.Click += (object sender, EventArgs e) =>
                        {
                                ColorDialog clrDlg = new ColorDialog ();
                                clrDlg.Color = txtColor.BackColor;
                                if (clrDlg.ShowDialog () == DialogResult.OK)
                                {
                                        txtColor.BackColor = clrDlg.Color;
                                }
                        };
                        pnl.Controls.Add (txtColor);

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
                        o.color = txtColor.BackColor;
                        BaseMng<T>.Instance.Insert (o);
                }

                public void Update ()
                {
                        BaseMng<T>.Instance.Update (o, x => x.color = txtColor.BackColor);
                }
        }
}
