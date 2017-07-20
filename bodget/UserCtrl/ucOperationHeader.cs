using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bodget.Data;
using Bodget.Model;
using Libod.ClassExtension.ControlEx;
using Libod.ReflectionEx;
using LibodUserCtrl.Extension.WinButton;

namespace Bodget.UserCtrl
{
        public partial class ucOperationHeader: UserControl
        {

                //private Point MouseDownStartPoint { get; set; }


                public ucOperationHeader ()
                {
                        InitializeComponent ();

                        tlp.SuspendLayout ();
                        SuspendLayout ();

                        tlp.Dock = DockStyle.Fill;

                        Name = "ucOperationHeader";

                        int ColIndex = 0;
                        foreach (PropertyHeader hdr in BaseMng<PropertyHeader>.Instance.All
                                .Where (x => x.visible && x.typeParent == typeof(Operation)))
                        {
                                AddButton (hdr, ColIndex++);
                        }

                        //Console.WriteLine (tlp.Parent.Name + tlp.Parent.Width);
                        tlp.ResumeLayout (false);
                        ResumeLayout (false);
                }

                private Button AddButton (PropertyHeader hdr, int ColIndex = 0)
                {
                        Button lbl = new Button ();
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Text = hdr.nom;
                        //lbl.ResizePosition = ButtonResizable.Position.None;
                        //lbl.WidthMin = lbl.Width;
                        //lbl.SizeChanged += lbl_SizeChanged;
                        //lbl.MouseDown += lbl_MouseDown;
                        //lbl.MouseMove += lbl_MouseMove;
                        //lbl.MouseUp += lbl_MouseUp;
                        tlp.AddCol (hdr.width, ColIndex, lbl);
                        return lbl;
                }

                void lbl_SizeChanged (object sender, System.EventArgs e)
                {
                        //ButtonResizable o = sender as ButtonResizable;
                        //Console.WriteLine (o.Name + " - " + o.Size);
                        base.OnSizeChanged (e);
                }

                //private Point MousePointOnParent (object sender, MouseEventArgs e)
                //{
                //        Point mouseLoc = new Point ();
                //        Control childCtrl = sender as Control;
                //        if (childCtrl == null)
                //        {
                //                throw new Exception ();
                //        }
                //        mouseLoc.X = e.X + childCtrl.Left;
                //        mouseLoc.Y = e.Y + childCtrl.Top;
                //        return mouseLoc;
                //}

                //private void lbl_MouseDown (object sender, MouseEventArgs e)
                //{
                //        Point mouseLoc = MousePointOnParent (sender, e);
                //        OnMouseDown (new MouseEventArgs (MouseButtons.Left, 1, mouseLoc.X, mouseLoc.Y, 0));
                //}

                //private void lbl_MouseMove (object sender, MouseEventArgs e)
                //{
                //        Point mouseLoc = MousePointOnParent (sender, e);
                //        OnMouseMove (new MouseEventArgs (MouseButtons.Left, 1, mouseLoc.X, mouseLoc.Y, 0));
                //}

                //private void lbl_MouseUp (object sender, MouseEventArgs e)
                //{
                //        Point mouseLoc = MousePointOnParent (sender, e);
                //        OnMouseUp (new MouseEventArgs (MouseButtons.Left, 1, mouseLoc.X, mouseLoc.Y, 0));
                //}


                //// Is the cursor outside of the parent container?
                //private bool IsCursorOutside (Point location)
                //{
                //        //Debug.WriteLine (Parent.Name + " - " + Parent.Width);
                //        //Rectangle rectangle = new Rectangle (0, 0, Parent.Width, Parent.Height);
                //        Rectangle rectangle = new Rectangle (0, 0, Parent.Width, Parent.Height);
                //        //Debug.WriteLine (Parent.PointToClient (location));
                //        return !rectangle.Contains (Parent.PointToClient (location));
                //}

                //private void ucOperation_MouseDown (object sender, MouseEventArgs e)
                //{
                //        if (e.Button == MouseButtons.Left)
                //        {
                //                // Save coordinates for later use in mouse up
                //                //if(sender
                //                MouseDownStartPoint = new Point (e.X, e.Y);
                //                Debug.WriteLine ("MouseDownStartPoint=" + MouseDownStartPoint + " - " + e.Location);

                //                // Show the outline object
                //                Shadow.Show (this.PointToScreen (new Point (e.X - MouseDownStartPoint.X - 1, e.Y - MouseDownStartPoint.Y - 1)), Size);

                //                // Register the mouse move handler
                //                MouseMove -= ucOperation_MouseMove;
                //                MouseMove += ucOperation_MouseMove;
                //        }
                //}

                //private void ucOperation_MouseMove (object sender, MouseEventArgs e)
                //{
                //        // Have we left the parent container?
                //        if (IsCursorOutside (PointToScreen (new Point (e.X, e.Y))))
                //        {
                //                // Unregister this event
                //                MouseMove -= (ucOperation_MouseMove);

                //                // Hide the outline object
                //                Shadow.Hide ();

                //                // Do start the drag-drop action
                //                DoDragDrop (this, DragDropEffects.Move);
                //        }
                //        else
                //        {
                //                // Move the outline object
                //                Shadow.Move (PointToScreen (new Point (e.X - MouseDownStartPoint.X - 1, e.Y - MouseDownStartPoint.Y - 1)));
                //        }
                //}



                //private void ucOperation_MouseUp (object sender, MouseEventArgs e)
                //{
                //        // Continue?
                //        if (e.Button == MouseButtons.Left)
                //        {
                //                // Unregister the mouse move event
                //                MouseMove -= (ucOperation_MouseMove);

                //                // Hide the outline object
                //                Shadow.Hide ();
                //        }
                //}
        }
}
