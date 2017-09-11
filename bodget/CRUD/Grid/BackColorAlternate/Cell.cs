using System;
using System.Drawing;

namespace Bodget.CRUD.GridBackColorAlternate
{
        public class Cell: SourceGrid.Cells.Views.Cell
        {
                public Cell (Color firstColor, Color secondColor)
                {
                        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid (firstColor);
                        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid (secondColor);
                }

                public DevAge.Drawing.VisualElements.IVisualElement FirstBackground { get; set; }
                public DevAge.Drawing.VisualElements.IVisualElement SecondBackground { get; set; }


                protected override void PrepareView (SourceGrid.CellContext context)
                {
                        base.PrepareView (context);

                        if (Math.IEEERemainder (context.Position.Row, 2) == 0)
                        {
                                Background = FirstBackground;
                        }
                        else
                        {
                                Background = SecondBackground;
                        }
                }
        }

}
