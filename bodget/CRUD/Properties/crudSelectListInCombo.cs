using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;
using Libod;
using Libod.Model;
using LibodUserCtrl;
using RESX = Libod.ResourceText;

namespace Bodget.CRUD.Properties
{
        public class crudSelectListInCombo<T1, Has, T2>: IpropertyCRUD<T1>
                where T1: ICtrlItem, ISelectListInCombo
                where Has: IBaseHas, new ()
                where T2: ICtrlItem
        {
                public T1 o { get; set; }

                public crudSelectListInCombo (T1 mdl)
                {
                        o = mdl;
                }
                public CRUDmode CRUDmode { get; set; }
                public crudSelectListInCombo (T1 mdl, CRUDmode CRUDmode)
                {
                        o = mdl;
                        this.CRUDmode = CRUDmode;
                }
                public T1 Object
                {
                        get
                        {
                                o = BaseMng<T1>.Instance.Get (o.id);
                                return o;
                        }
                }
                public ucSelectListInCombo<T2> ucSelectList;
                public Panel    /**/ pnl = new Panel ();

                public Panel CreateObject (Panel parentPanel)
                {
                        pnl.Height = Constantes.LINE_HEIGHT * 8;
                        pnl.Dock = DockStyle.Bottom;

                        ucSelectList = new ucSelectListInCombo<T2> (o.ComboItems<T2> (), o.SelectedItems<T2> ());
                        ucSelectList.Text = RESX.Beneficiare.ToLabel ();
                        ucSelectList.Top = 0;
                        ucSelectList.Left = Constantes.CTRL_MARGE;
                        ucSelectList.Width = parentPanel.Width - Constantes.CTRL_MARGE;
                        ucSelectList.Height = pnl.Height;
                        pnl.Controls.Add (ucSelectList);

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

                private Has CreateT1HasT2Object (T2 o2)
                {
                        return new Has { id1 = o.id, id2 = o2.id };
                }

                private IEnumerable<Has> SelectedHasListObject ()
                {
                        foreach (T2 item in ucSelectList.SelectedValue)
                        {
                                yield return CreateT1HasT2Object (item);
                        }
                }

                public void Insert ()
                {
                        foreach (Has item in SelectedHasListObject ())
                        {
                                BaseHasMng<Has>.Instance.Insert (item);
                        }
                }

                public void Update ()
                {
                        var allExistingHasObject = BaseHasMng<Has>.Instance.All.Where (x => x.id1 == o.id);
                        var deletedItem = allExistingHasObject.Except (SelectedHasListObject ());
                        foreach (Has item in deletedItem)
                        {
                                item.DeleteLstId2InObj1<T1> (item);
                                BaseHasMng<Has>.Instance.Delete (item);
                        }
                        foreach (Has item in SelectedHasListObject ())
                        {
                                var existem = allExistingHasObject.FirstOrDefault (x => x.id1 == o.id && x.id2 == item.id2);
                                if (existem == null)
                                {
                                        BaseHasMng<Has>.Instance.Insert (item);
                                }
                                else
                                {
                                        BaseHasMng<Has>.Instance.Update (item, x => x.id2 = item.id2);
                                }
                                item.UpdateLstId2InObj1<T1> (item);
                        }
                }

                public void Delete ()
                {
                        foreach (Has item in SelectedHasListObject ())
                        {
                                BaseHasMng<Has>.Instance.Delete (item);
                        }
                }
        }
}
