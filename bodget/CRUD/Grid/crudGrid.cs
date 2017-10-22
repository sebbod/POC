using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using Libod;
using Libod.Ctrl;
using Libod.Culture;
using Libod.Model;
using Libod.ReflectionEx;
using LibodUserCtrl.Extension.SourceGridEx;
using LibodUserCtrl.Extension.WinMenu;
using SourceGrid;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Views;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD
{
        public partial class crudGrid<T>: IpropertyCRUD<T>
                where T: IBase, new ()
        {
                public T o { get; set; }

                public crudGrid (T mdl)
                {
                        o = mdl;
                }
                public CRUDmode CRUDmode { get; set; }
                public crudGrid (T mdl, CRUDmode CRUDmode)
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

                public Grid     /**/ g = new Grid ();
                public Panel    /**/ pnl = new Panel ();
                public System.Windows.Forms.Button   /**/ btnRapprochement = new System.Windows.Forms.Button ();
                //Views

                GridBackColorAlternate.Cell viewNormal = new GridBackColorAlternate.Cell (Color.AliceBlue, Color.AntiqueWhite);
                GridBackColorAlternate.Cell viewDecimal = new GridBackColorAlternate.Cell (Color.AliceBlue, Color.AntiqueWhite);

                /// <summary>
                /// 
                /// </summary>
                /// <param name="parentPanel"></param>
                /// <returns>this.pnl</returns>
                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT * 18;
                        pnl.Dock = DockStyle.Bottom;
                        parentPanel.Controls.Add (pnl); // il faut le faire ici sinon on ne peut pas utiliser pnl.Width

                        CreateGrid ();
                        //g.Left = Constantes.CTRL_MARGE;
                        g.Height = pnl.Height - Constantes.LINE_HEIGHT * 2;
                        //g.Width = pnl.Width - Constantes.CTRL_MARGE * 2;
                        g.Dock = DockStyle.Top;
                        pnl.Controls.Add (g);

                        btnRapprochement.Text = RESX.rapprochement;
                        btnRapprochement.Left = Constantes.CTRL_MARGE;
                        btnRapprochement.Top = g.Height + Constantes.CTRL_MARGE * 2;
                        btnRapprochement.Width = 148;
                        btnRapprochement.Height = Constantes.CTRL_HEIGHT;
                        btnRapprochement.Click += btnRapprochement_Click;
                        pnl.Controls.Add (btnRapprochement);

                        return pnl;
                }

                void btnRapprochement_Click (object sender, EventArgs e)
                {
                        //var opsTmp = BaseMng<Operation>.Instance.All.Where (op => op.idCheque != 0);
                        //foreach (var op in opsTmp)
                        //{
                        //        BaseMng<Operation>.Instance.Update (op, c => c.nom = c.Cheque().code);
                        //}

                        //var ops = BaseMng<Operation>.Instance.All.Where (op => op.idCheque == 0); //Raméne toutes les opérations de la base
                        var ops = BaseMng<Operation>.Instance.All.Where (op => op.type.Contains (Constantes.OPERATION_TYPE_CHEQUE));

                        // liste des chèques nom rapporcher à une opération
                        var cqs = BaseMng<Cheque>.Instance.All.Where (cq => cq.idOperation == 0);

                        IEnumerable<string> cqNumLst = cqs.Select (cq => cq.code);

                        Console.WriteLine ("{0} operations de type CHEQUE EMIS", ops.Count ());
                        Console.WriteLine ("{0} chèques non liés à des opérations", cqs.Count ());
                        //foreach (var cqCode in cqNumLst.OrderBy(c=>c))
                        //        Console.WriteLine (cqCode);

                        foreach (var op in ops)
                        {
                                string opChequeCode = op.ChequeCode ();
                                Console.WriteLine ("{0} opChequeCode", opChequeCode);

                                if (cqNumLst.Contains (opChequeCode))
                                {
                                        var cq = cqs.First (c => c.code == opChequeCode);
                                        if (cq.mt == 0 || Math.Abs (cq.mt) == Math.Abs (op.mt))
                                        {
                                                string opNewName = op.nom + " - " + cq.nom + ", "
                                                        + RESX.encaisse_ + " " + RESX.le + " " + cq.dt.ToShortDateString () + " "
                                                        + RESX.emis + " " + RESX.depuis + " " + op.ChequeEncaisseApres (cq) + RESX.j;

                                                //if (cq.nom.Length > 20)
                                                //{
                                                //        BaseMng<Cheque>.Instance.Update (cq, c => c.nom = c.nom.RemoveLastChar (19));
                                                //}
                                                //string opNewName = op.nom.FirstChar (7) + " - " + cq.nom + ", "
                                                //        + RESX.encaisse_ + " " + RESX.le + " " + cq.dt.ToShortDateString () + " "
                                                //        + RESX.emis + " " + RESX.depuis + " " + op.ChequeEncaisseApres (cq) + RESX.j;
                                                //string opNewName = op.nom.FirstChar (7) + " - " + cq.nom.RemoveLastChar (19) + ", "
                                                //        + RESX.encaisse_ + " " + RESX.le + " " + cq.dt.ToShortDateString () + " "
                                                //        + RESX.emis + " " + RESX.depuis + " " + op.ChequeEncaisseApres (cq) + RESX.j;


                                                if (op.idCheque != 0)
                                                {
                                                        // TODO
                                                        if (op.idCheque != cq.id)
                                                        {
                                                                throw new Exception ();
                                                                // on pourrait envoyer un message à l'utilisateur pour le prévenir que cette opération 
                                                                // est déjà associé à un chéque
                                                        }
                                                        else
                                                        {
                                                                // on ne devrait en temps normal pas repasser ici si le chèque est déjà lié à une opération
                                                                // logguer cette information
                                                        }
                                                }

                                                BaseMng<Operation>.Instance.Update (op, o => o.idCheque = cq.id);

                                                // create liaison cheque <==> opération
                                                BaseMng<Cheque>.Instance.Update (cq, c => c.idOperation = op.id);

                                                // renomage de l'opération pour bénéficier des informations porté par le chèque
                                                BaseMng<Operation>.Instance.Update (op, o => o.nom = opNewName);

                                                // MAJ de l'idCategory
                                                if (cq.idCategory > 0)
                                                {
                                                        // si le chèque en avait un
                                                        BaseMng<Operation>.Instance.Update (op, o => o.idCategory = cq.idCategory);
                                                }
                                                else
                                                {
                                                        // si l'opération en avait un
                                                        BaseMng<Cheque>.Instance.Update (cq, c => c.idCategory = op.idCategory);
                                                }
                                        }
                                        else
                                        {
                                                // TODO
                                                // avertir l'utilisateur qu'un chéque n'a pas le même montant que l'opération correspondante
                                                // if (Math.Abs (cq.mt) != Math.Abs (op.mt))
                                        }

                                }
                        }

                }

                public Exception Validation ()
                {
                        throw new NotImplementedException ();
                }

                public void Insert ()
                {
                        throw new NotImplementedException ();
                }

                public void Update ()
                {
                        throw new NotImplementedException ();
                }

                public void Delete ()
                {
                        throw new NotImplementedException ();
                }

                private void CreateGrid ()
                {
                        //Border
                        DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine (Color.White, 1);
                        DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder (border, border);

                        viewNormal.Border = cellBorder;
                        viewDecimal.Border = cellBorder;
                        //viewCheckBox.Border = cellBorder;

                        int iC = 0;

                        var lstCol = new T ().GetPropertyTypeNameAttribute ();

                        g.ColumnsCount = lstCol.Count;
                        g.FixedRows = 1;
                        g.Rows.Insert (g.Rows.Count);


                        // header
                        foreach (PropertyTypeNameAttribute p in lstCol.Where (x => x.PropertyHeader.visible))
                        {
                                var cHdr = new SourceGrid.Cells.ColumnHeader ();
                                cHdr.Tag = p.Name;
                                cHdr.Value = p.PropertyHeader.text;
                                g[g.Rows.Count - 1, iC++] = cHdr;
                        }

                        // lignes
                        foreach (Cheque c in BaseMng<Cheque>.Instance.All)
                        {
                                PopulateRow (c);
                        }

                        CreateNewRow ();

                        g.AutoSizeCells ();
                        //g.Dock = DockStyle.Fill;

                        Func<CellContext, object> AddOnEnter = (sender) =>
                        {
                                Cheque obj = (Cheque)g.Rows[sender.Position.Row].Tag;
                                if (!BaseMng<Cheque>.Instance.Exist (obj))
                                {
                                        BaseMng<Cheque>.Instance.Insert (obj);
                                        CreateNewRow ();
                                }
                                return null;
                        };
                        g.AddKeyEventController<Cheque> (new Dictionary<Keys, Func<CellContext, object>> { { Keys.Enter, AddOnEnter } });

                }

                private void CreateNewRow ()
                {
                        int iR = 0;
                        Cheque lastC = new Cheque ();
                        Cheque pLastC = new Cheque ();

                        if (g.Rows != null)
                        {
                                iR = g.Rows.Count;
                        }
                        if (iR >= 2)
                        {
                                lastC = (Cheque)g.Rows[iR - 1].Tag;
                                pLastC = (Cheque)g.Rows[iR - 2].Tag;
                        }
                        else if (iR == 1)
                        {
                                lastC = (Cheque)g.Rows[iR - 1].Tag;
                        }
                        var nextC = lastC.Clone<Cheque, Cheque> ();
                        nextC.id++;
                        nextC.code = lastC.code.Up ();
                        nextC.mt = 0;
                        nextC.nom = pLastC.nom;
                        nextC.dt = pLastC.dt;

                        //Console.WriteLine (nextC.nom);

                        PopulateRow (nextC);
                }

                private void PopulateRow (Cheque c)
                {

                        var lstCol = c.GetPropertyTypeNameValueAttribute ().Where (x => x.PropertyHeader.visible);
                        g.Rows.Insert (g.Rows.Count);

                        g.Rows[g.Rows.Count - 1].Tag = c;

                        int iC = 0;
                        foreach (PropertyTypeNameValueAttribute prop in lstCol)
                        {
                                IView vue = viewNormal;
                                vue.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

                                if (prop.ForeignKey != null)
                                {
                                        g[g.Rows.Count - 1, iC] = CreateComboCell (prop, c);
                                        //vue = SourceGrid.Cells.Views.ComboBox.Default;
                                }
                                else
                                {
                                        g[g.Rows.Count - 1, iC] = new SourceGrid.Cells.Cell (prop.Value, prop.Type);
                                }

                                Func<ToolStripMenuItemWithValue4sourceGrid<Cheque>, object> PopupRemove = (tsmi) =>
                                {
                                        var obj = tsmi.Value;
                                        BaseMng<Cheque>.Instance.Delete (obj);
                                        g.Rows.Remove (tsmi.iRselected);
                                        if (tsmi.iRselected == g.Rows.Count)
                                        {
                                                // si on supprime la dernière ligne on en rajoute automatiquement une nouvelle
                                                // sinon l'utilisateur ne peut plus ajouter de ligne
                                                CreateNewRow ();
                                        }
                                        return null;
                                };

                                if (prop.Type == typeof (decimal))
                                {
                                        SourceGrid.Cells.Editors.TextBoxNumeric numericEditor = new SourceGrid.Cells.Editors.TextBoxNumeric (typeof (decimal));
                                        // formatage à la française 2 chiffres après la virgule et espace tous les 3 chiffres
                                        var decimalFormatCustom = new DevAge.ComponentModel.Converter.NumberTypeConverter (typeof (decimal));
                                        decimalFormatCustom.Format = Formats.MONEY4GRID;
                                        numericEditor.TypeConverter = decimalFormatCustom;

                                        // Validation de la donnée saisie
                                        numericEditor.KeyPress += delegate (object sender, KeyPressEventArgs keyArgs)
                                        {
                                                if (keyArgs.KeyChar == 46)
                                                {
                                                        // change le point [.] en virgule [,]
                                                        keyArgs.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                                                }
                                                bool isValid = char.IsNumber (keyArgs.KeyChar)
                                                        || keyArgs.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]
                                                        || keyArgs.KeyChar == 8
                                                        ;
                                                if (isValid)
                                                {
                                                        var val = ((TextBoxNumeric)sender).Control.Text;
                                                        if (keyArgs.KeyChar == 8 && val != null && val.Length == 1)
                                                        {
                                                                ((TextBoxNumeric)sender).Control.Text = "0";
                                                        }
                                                        else
                                                        {
                                                                isValid = isValid && val.IsDecimal ();
                                                        }
                                                }
                                                keyArgs.Handled = !isValid;
                                        };
                                        //numericEditor.Control.TextAlign = HorizontalAlignment.Right;
                                        vue = viewDecimal;
                                        vue.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
                                        g[g.Rows.Count - 1, iC].Editor = numericEditor;
                                }
                                g[g.Rows.Count - 1, iC].View = vue;

                                g[g.Rows.Count - 1, iC].AddPopupMenuController<Cheque> (new Dictionary<MouseButtons, Func<ToolStripMenuItemWithValue4sourceGrid<Cheque>, object>> { { MouseButtons.Right, PopupRemove } });
                                g[g.Rows.Count - 1, iC].AddValueChangedController<Cheque> (InsertOrUpdate);
                                g[g.Rows.Count - 1, iC].AddClickController ();
                                iC++;
                        }
                }

                private SourceGrid.Cells.ICell CreateComboCell (PropertyTypeNameValueAttribute prop, Cheque cq)
                {
                        // creation de l'object en fcontion du type de la FK
                        // pour récupération des données de la FK à placer dans Cell
                        object cellValue = null;
                        dynamic objFK = Activator.CreateInstance (prop.ForeignKey.type, true);
                        List<ctrlItem<ICtrlItem>> items = objFK.ComboItems4Cell ();

                        if ((long)prop.Value != 0)
                        {
                                // sélection d'un item
                                try
                                {
                                        cellValue = items.First (o => o.id == (long)prop.Value).Text;
                                }
                                catch
                                {
                                        BaseMng<Cheque>.Instance.Update (cq, o => o.idOperation = 0);
                                        //TODO a supprimer
                                        Console.WriteLine ("{0}=>(long)prop.Value={1} but ({2})items.First (o => o.id == (long)prop.Value) return NULL", prop.Name, (long)prop.Value, items.First ().GetType ().Name);
                                }
                        }

                        // création de la combo à placer dans Cell
                        Type ctrlItemOfT = typeof (ctrlItem<>).MakeGenericType (typeof (ICtrlItem));
                        SourceGrid.Cells.Editors.ComboBox cmbItem = new SourceGrid.Cells.Editors.ComboBox (ctrlItemOfT);
                        cmbItem.StandardValues = items;
                        cmbItem.EditableMode = EditableMode.Focus | EditableMode.SingleClick | EditableMode.AnyKey;

                        return new SourceGrid.Cells.Cell (cellValue, cmbItem);
                }

                private object InsertOrUpdate (CellContext sender)
                {
                        Cheque obj = (Cheque)g.Rows[sender.Position.Row].Tag;
                        if (!BaseMng<Cheque>.Instance.Exist (obj))
                        {
                                BaseMng<Cheque>.Instance.Insert (obj);
                                CreateNewRow ();
                        }

                        /*
                         * TODO
                         * j'interdit pour l'instant la possibilité de modifier un chèque 
                         * s'il est lié à une opération
                         */
                        // EN FAIT j'ai besoin de faire des modifs
                        //if (obj.idOperation > 0)
                        //{
                        //        // debug BaseMng<Cheque>.Instance.Update (obj, o => o.idOperation = 0);
                        //        return null;
                        //}

                        // il faut faire un update après l'insert sinon la donnée changé par le ValueChange ne sera pas enregistré
                        SourceGrid.Cells.ColumnHeader cHdr = (SourceGrid.Cells.ColumnHeader)g[0, sender.Position.Column];

                        //if ((string)cHdr.Tag == "id" + cHdr.Value)
                        if (sender.Value != null
                         && sender.Value.GetType () == typeof (ctrlItem<ICtrlItem>)) // PLANTE quand sender.Value == null
                        {
                                ctrlItem<ICtrlItem> item = ((ctrlItem<ICtrlItem>)sender.Value);
                                object value = item.id;
                                //string propName = item.Value.GetType ().Name;
                                BaseMng<Cheque>.Instance.Update (obj, (string)cHdr.Tag, value);
                        }
                        else
                        {
                                BaseMng<Cheque>.Instance.Update (obj, (string)cHdr.Tag, sender.Value);
                        }

                        return null;
                }

                private SourceGrid.Cells.Editors.ComboBox cmb<T> (ICollection StandardValues)
                        where T: ICtrlItem, IComboItems<T>, new ()
                {
                        SourceGrid.Cells.Editors.ComboBox cmb = new SourceGrid.Cells.Editors.ComboBox (typeof (ctrlItem<T>));
                        cmb.StandardValues = StandardValues;
                        cmb.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
                        return cmb;
                }


        }
}
