using Libod;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;

namespace LibodUserCtrl.Extension.SourceGridEx
{
        static partial class CellEx
        {
                public static void AddValueChangingController4decimal (this ICell c)
                {
                        c.AddController (new CellValueChanging4decimal ());
                }

                public class CellValueChanging4decimal: ControllerBase
                {
                        public override void OnValueChanging (CellContext sender, ValueChangeEventArgs e)
                        {
                                base.OnValueChanging (sender, e);
                                
                                if (e.NewValue.isTypeOf<decimal> ())
                                { 
                                
                                }


                        }
                }
        }
}
