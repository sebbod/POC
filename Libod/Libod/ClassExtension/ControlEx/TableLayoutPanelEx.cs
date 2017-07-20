using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libod.ClassExtension.ControlEx
{
        public static class TableLayoutPanelEx
        {
                /// <summary>
                /// ajoute un control dans une nouvelle ligne d'un TableLayoutPanel
                /// </summary>
                /// <param name="tlp"></param>
                /// <param name="height"></param>
                /// <param name="index"></param>
                /// <param name="ctrl"></param>
                public static void AddRow (this TableLayoutPanel tlp, int height, int index, Control ctrl)
                {
                        tlp.RowStyles.Insert (0, new RowStyle (SizeType.AutoSize, height));
                        //tlp.Controls.Add (ucc, 0, RowIndex++);
                        // les 2 lignes suivante ne font pas la même chose qu el aligne ci-dessus^^
                        tlp.Controls.Add (ctrl, 0, tlp.RowCount++);
                        tlp.SetRow (ctrl, index);
                }

                /// <summary>
                /// Supprimer tous les RowStyles et les Controls
                /// </summary>
                /// <param name="tlp"></param>
                public static void ClearRow (this TableLayoutPanel tlp)
                {
                        tlp.RowStyles.Clear();
                        tlp.Controls.Clear ();
                }

                /// <summary>
                /// ajoute un control dans une nouvelle collone d'un TableLayoutPanel
                /// </summary>
                /// <param name="tlp"></param>
                /// <param name="width">si =0 alors ColumnStyle (SizeType.Percent, 100)</param>
                /// <param name="index"></param>
                /// <param name="ctrl"></param>
                public static void AddCol (this TableLayoutPanel tlp, int width, int index, Control ctrl)
                {
                        ColumnStyle cs;
                        if (width == 0)
                        {
                                //Console.WriteLine (ctrl.Name);
                                cs = new ColumnStyle (SizeType.Percent, 100);
                        }
                        else
                        {
                                cs = new ColumnStyle (SizeType.Absolute, width);
                        }
                        
                        //tlp.ColumnStyles.Insert (0, cs);
                        ////tlp.Controls.Add (ucc, 0, RowIndex++);
                        //// les 2 lignes suivante ne font pas la même chose qu el aligne ci-dessus^^
                        //tlp.Controls.Add (ctrl, tlp.ColumnCount++, 0);
                        //tlp.SetColumn (ctrl, index);

                        tlp.ColumnStyles.Add (cs);
                        tlp.Controls.Add (ctrl,tlp.ColumnCount++,0);
                }
        }
}
