using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Libod.Model
{
        public static class IpropertyCRUDex
        {
                public static void CreateObject<T> (this IEnumerable<IpropertyCRUD<T>> prtyCol, Panel parentPanel)
                {
                        //foreach (Panel pnl in parentPanel.Controls.GetEnumerator ().ToList<Panel> ().Where (p => p.Visible))
                        //{
                        //        pnl.Visible = false;
                        //}
                        parentPanel.Controls.Clear ();
                        int heightUsed = 0;
                        foreach (IpropertyCRUD<T> p in prtyCol)
                        {
                                heightUsed += p.CreateObject (parentPanel).Height;
                        }
                        // ajoute un panel de fin pour compléter la place restante (s'il en reste bien sur)
                        var pnl = new Panel ();
                        pnl.Height = parentPanel.Height - heightUsed;
                        pnl.Dock = DockStyle.Bottom;
                        parentPanel.Controls.Add (pnl);
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="prtyCol"></param>
                /// <returns>Exception or null</returns>
                public static Exception Validation<T> (this IEnumerable<IpropertyCRUD<T>> prtyCol)
                {
                        foreach (IpropertyCRUD<T> p in prtyCol)
                        {
                                Exception ex = p.Validation ();
                                if (ex != null)
                                {
                                        return ex;
                                }
                        }
                        return null;
                }

                //public static void Insert (this IEnumerable<IpropertyCRUD> prtyCol)
                //{
                //        foreach (IpropertyCRUD p in prtyCol)
                //        {
                //                p.Insert ();
                //        }
                //}

                public static void Update<T> (this IEnumerable<IpropertyCRUD<T>> prtyCol)
                {
                        foreach (IpropertyCRUD<T> p in prtyCol)
                        {
                                p.Update ();
                        }
                }


        }
}
