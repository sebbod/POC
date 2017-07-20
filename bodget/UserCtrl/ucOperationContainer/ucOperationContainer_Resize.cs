using System;
using System.Drawing;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;

namespace Bodget.UserCtrl
{
        public partial class ucOperationContainer
        {

                /// <summary>
                /// épaisseur de la bordure de détection de la souris
                /// </summary>
                internal const int EDGE_THICKNESS = 3;

                internal bool MouseIsInBottomEdge { get; set; }

                internal Size OnMouseDownControlSize { get; set; }
                internal Point OnMouseDownMouseLocation { get; set; }
                internal bool OnResizing { get; set; }

                public int HeightMin { get; set; }
                public int HeightMax { get; set; }


                private void tlp_MouseDown (object sender, MouseEventArgs e)
                {
                        if (MouseIsInBottomEdge)
                        {
                                OnResizing = true;
                                OnMouseDownMouseLocation = e.Location;
                                OnMouseDownControlSize = Size;
                                tlp.Capture = true;
                        }
                        base.OnMouseDown (e);
                }

                private void tlp_MouseUp (object sender, MouseEventArgs e)
                {
                        if (OnResizing)
                        {
                                OnResizing = false;
                                tlp.Capture = false;
                                OnMouseDownControlSize = Size;
                                OnMouseDownMouseLocation = e.Location;
                                // gestion du flag height4ucOperationContainer
                                // dans la base
                                BaseMng<Category>.Instance.Update (Category, c => c.height4ucOperationContainer = Height);
                                Cursor = Cursors.Default;
                                base.OnSizeChanged (e);
                        }
                        base.OnMouseUp (e);
                }

                private void tlp_MouseMove (object sender, MouseEventArgs e)
                {
                        if (!OnResizing)
                        {
                                UpdateEdge (e.Location);
                                UpdateCursor ();
                        }
                        //Console.WriteLine (e.Button);
                        if (e.Button == MouseButtons.Left && OnResizing)
                        {
                                //Console.WriteLine ("Height=" + Height);
                                // compute new value
                                int h = Height;
                                if (MouseIsInBottomEdge)
                                {
                                        h = (e.Y - OnMouseDownMouseLocation.Y) + OnMouseDownControlSize.Height;
                                }
                                else
                                {
                                        OnMouseUp (e);
                                }

                                // affect new value
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
                        }

                        base.OnMouseMove (e);
                }


                private void UpdateEdge (Point mousePt)
                {
                        //Console.WriteLine (Height + " - " + mousePt.Y + " - " + Math.Abs (mousePt.Y - Height));
                        MouseIsInBottomEdge = Math.Abs (mousePt.Y - Height) <= EDGE_THICKNESS;
                }

                private void UpdateCursor ()
                {
                        if (MouseIsInBottomEdge)
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
