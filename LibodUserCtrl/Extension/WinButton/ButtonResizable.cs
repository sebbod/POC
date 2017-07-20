using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibodUserCtrl.Extension.WinButton
{
        public class ButtonResizable: Button
        {
                /// <summary>
                /// épaisseur de la bordure de détection de la souris
                /// </summary>
                internal const int EDGE_THICKNESS = 2;

                internal static bool MouseIsInLeftEdge { get; set; }
                internal static bool MouseIsInRightEdge { get; set; }
                internal static bool MouseIsInTopEdge { get; set; }
                internal static bool MouseIsInBottomEdge { get; set; }

                internal static Size OnMouseDownControlSize { get; set; }
                internal static Point OnMouseDownMouseLocation { get; set; }
                internal static bool OnResizing { get; set; }

                public enum Position
                {
                        None = 0,
                        Top = 1,
                        Bottom = 2,
                        Left = 4,
                        Right = 8,
                        Any = 16,
                }

                /// <summary>
                /// on peut vouloir redimentionner que sur la bordure droite du control par exemple
                /// </summary>
                public Position ResizePosition { get; set; }

                public int WidthMin { get; set; }
                public int HeightMin { get; set; }
                public int WidthMax { get; set; }
                public int HeightMax { get; set; }

                public ButtonResizable ()
                {
                        ResizePosition = Position.Any;

                        WidthMin = 10;
                        HeightMin = 10;
                        if (Parent != null)
                        {
                                WidthMax = Parent.Width - Left;
                                HeightMax = Parent.Height - Top;
                        }
                        else
                        {
                                WidthMax = 800;
                                HeightMax = 600;
                        }

                        MouseIsInLeftEdge = false;
                        MouseIsInRightEdge = false;
                        MouseIsInTopEdge = false;
                        MouseIsInBottomEdge = false;
                }


                protected override void OnMouseDown (MouseEventArgs e)
                {
                        if (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge)
                        {
                                OnResizing = true;
                                OnMouseDownMouseLocation = e.Location;
                                OnMouseDownControlSize = Size;
                                Capture = true;
                        }
                        base.OnMouseDown (e);
                }

                protected override void OnMouseUp (MouseEventArgs e)
                {
                        if (OnResizing)
                        {
                                OnResizing = false;
                                Capture = false;
                                OnMouseDownControlSize = Size;
                                OnMouseDownMouseLocation = e.Location;
                                UpdateCursor ();
                                base.OnSizeChanged (e);
                        }
                        base.OnMouseUp (e);
                }

                protected override void OnMouseMove (MouseEventArgs e)
                {
                        if (ResizePosition == Position.None)
                        {
                                base.OnMouseMove (e);
                                return;
                        }
                        if (!OnResizing)
                        {
                                UpdateEdge (e.Location);
                                UpdateCursor ();
                        }
                        if (e.Button == MouseButtons.Left && OnResizing)
                        {
                                // compute new value
                                int w = Width;
                                int h = Height;
                                int t = Top;
                                int l = Left;
                                if (MouseIsInLeftEdge)
                                {
                                        if (MouseIsInTopEdge)
                                        {
                                                w -= (e.X - OnMouseDownMouseLocation.X);
                                                l += (e.X - OnMouseDownMouseLocation.X);
                                                h -= (e.Y - OnMouseDownMouseLocation.Y);
                                                t += (e.Y - OnMouseDownMouseLocation.Y);
                                        }
                                        else if (MouseIsInBottomEdge)
                                        {
                                                w -= (e.X - OnMouseDownMouseLocation.X);
                                                l += (e.X - OnMouseDownMouseLocation.X);
                                                h = (e.Y - OnMouseDownMouseLocation.Y) + OnMouseDownControlSize.Height;
                                        }
                                        else
                                        {
                                                w -= (e.X - OnMouseDownMouseLocation.X);
                                                l += (e.X - OnMouseDownMouseLocation.X);
                                        }
                                }
                                else if (MouseIsInRightEdge)
                                {
                                        if (MouseIsInTopEdge)
                                        {
                                                w = (e.X - OnMouseDownMouseLocation.X) + OnMouseDownControlSize.Width;
                                                h -= (e.Y - OnMouseDownMouseLocation.Y);
                                                t += (e.Y - OnMouseDownMouseLocation.Y);

                                        }
                                        else if (MouseIsInBottomEdge)
                                        {
                                                w = (e.X - OnMouseDownMouseLocation.X) + OnMouseDownControlSize.Width;
                                                h = (e.Y - OnMouseDownMouseLocation.Y) + OnMouseDownControlSize.Height;
                                        }
                                        else
                                        {
                                                w = (e.X - OnMouseDownMouseLocation.X) + OnMouseDownControlSize.Width;
                                        }
                                }
                                else if (MouseIsInTopEdge)
                                {
                                        h -= (e.Y - OnMouseDownMouseLocation.Y);
                                        t += (e.Y - OnMouseDownMouseLocation.Y);
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        h = (e.Y - OnMouseDownMouseLocation.Y) + OnMouseDownControlSize.Height;
                                }
                                else
                                {
                                        OnMouseUp (e);
                                }

                                // affect new value
                                if (w <= WidthMax && w >= WidthMin)
                                {
                                        Width = w;
                                }
                                else if (w > WidthMax)
                                {
                                        Width = WidthMax;
                                }
                                else if (w < WidthMin)
                                {
                                        Width = WidthMin;
                                }

                                if (h <= HeightMax && h >= HeightMin)
                                {
                                        Height = h;
                                }
                                else if (h > HeightMax)
                                {
                                        Height = HeightMax;
                                }
                                else if (h < HeightMin)
                                {
                                        Height = HeightMin;
                                }

                                Top = t;
                                Left = l;

                        }

                        base.OnMouseMove (e);
                }

                private void UpdateEdge (Point mousePt)
                {
                        if (ResizePosition == Position.None)
                        {
                                MouseIsInTopEdge = false;
                                MouseIsInRightEdge = false;
                                MouseIsInBottomEdge = false;
                                MouseIsInLeftEdge = false;
                        }
                        if (ResizePosition == Position.Any || ResizePosition == Position.Top)
                        {
                                MouseIsInTopEdge = Math.Abs (mousePt.Y) <= EDGE_THICKNESS;
                        }
                        if (ResizePosition == Position.Any || ResizePosition == Position.Right)
                        {
                                MouseIsInRightEdge = Math.Abs (mousePt.X - Width) <= EDGE_THICKNESS;
                        }
                        if (ResizePosition == Position.Any || ResizePosition == Position.Bottom)
                        {
                                MouseIsInBottomEdge = Math.Abs (mousePt.Y - Height) <= EDGE_THICKNESS;
                        }
                        if (ResizePosition == Position.Any || ResizePosition == Position.Left)
                        {
                                MouseIsInLeftEdge = Math.Abs (mousePt.X) <= EDGE_THICKNESS;
                        }
                }

                private void UpdateCursor ()
                {
                        if (ResizePosition == Position.None)
                        {
                                return;
                        }
                        if (MouseIsInLeftEdge)
                        {
                                if (MouseIsInTopEdge)
                                {
                                        Cursor = Cursors.SizeNWSE;
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        Cursor = Cursors.SizeNESW;
                                }
                                else
                                {
                                        Cursor = Cursors.SizeWE;
                                }
                        }
                        else if (MouseIsInRightEdge)
                        {
                                if (MouseIsInTopEdge)
                                {
                                        Cursor = Cursors.SizeNESW;
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        Cursor = Cursors.SizeNWSE;
                                }
                                else
                                {
                                        Cursor = Cursors.SizeWE;
                                }
                        }
                        else if (MouseIsInTopEdge || MouseIsInBottomEdge)
                        {
                                Cursor = Cursors.SizeNS;
                        }
                        else
                        {
                                Cursor = Cursors.Default;
                        }
                }

        }
}
