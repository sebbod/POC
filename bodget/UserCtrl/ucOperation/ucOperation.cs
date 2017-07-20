using System.Collections.Generic;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using Libod;
using Libod.ClassExtension.ControlEx;
using Libod.Ctrl;
using Libod.Culture;
using Libod.ReflectionEx;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibodUserCtrl.Extension.WinMenu;

namespace Bodget.UserCtrl
{
        public partial class ucOperation: UserControl
        {
                private Operation _op;
                public Operation Operation
                {
                        get
                        {
                                return _op;
                        }
                        set
                        {
                                _op = value;
                        }
                }
                private Point MouseDownStartPoint { get; set; }

                public long id
                {
                        get
                        {
                                return _op.id;
                        }
                }

                private Category _Category;
                public Category Category
                {
                        get
                        {
                                return _Category;
                        }
                        set
                        {
                                _Category = value;
                                if (_Category != null)
                                {
                                        _op.idCategory = _Category.id;
                                }
                                else
                                {
                                        _op.idCategory = 0;
                                }
                                BaseMng<Operation>.Instance.Update (_op, x => x.idCategory = _op.idCategory);
                        }
                }


                public ucOperation ()
                {
                        InitializeComponent ();
                }

                public ucOperation (Operation op)
                {
                        InitializeComponent ();

                        tlp.SuspendLayout ();
                        SuspendLayout ();

                        tlp.Dock = DockStyle.Fill;

                        Name = "ucOperation" + op.id;

                        _op = op;

                        CreateCtxMnu ();

                        int ColIndex = 0;
                        var opLstProp = op.GetPropertyTypeNameValue ();
                        foreach (PropertyHeader oh in BaseMng<PropertyHeader>.Instance.All.Where (x => x.visible && x.typeParent == typeof(Operation)))
                        {
                                var prop = opLstProp.FirstOrDefault (x => x.Name == oh.propertyName);
                                //Console.WriteLine (prop.Name + " = " + prop.Value);
                                if (prop != null)
                                {
                                        // variable intermédiare pour géré les cas des valeurs
                                        // provenant de FK
                                        PropertyTypeNameValue ptnv = prop;

                                        if (prop.Name == "idBeneficiare")
                                        {
                                                // cas spécial où il faut aller lire dans une autre table que Opération l'information à afficher
                                                ptnv = new PropertyTypeNameValue ();
                                                ptnv.Name = prop.Name;
                                                if (op.Beneficiare () != null && op.Beneficiare ().initiales != null)
                                                {
                                                        ptnv.Type = op.Beneficiare ().initiales.GetType ();
                                                        ptnv.Value = op.Beneficiare ().initiales;
                                                }
                                                else
                                                {
                                                        ptnv.Type = typeof(string);
                                                        ptnv.Value = string.Empty;
                                                }
                                        }
                                        Label lbl = AddLabel (ptnv, oh, ColIndex++);

                                        // Gestion couleur des operations en focntion du compte
                                        if (op.Compte () != null && op.Compte ().color != null)
                                        {
                                                lbl.BackColor = op.Compte ().color;
                                        }
                                }
                        }

                        tlp.ResumeLayout (false);
                        ResumeLayout (false);
                }

                private Label AddLabel (PropertyTypeNameValue prop, PropertyHeader hdr, int ColIndex = 0)
                {
                        //Console.WriteLine (" AddLabel " + prop.Name);

                        Label lbl = new Label ();
                        lbl.Name = prop.Name;    // use with context menu 4 refresh selected label text by Tag

                        //lbl.BackColor = Color.Aqua;
                        lbl.Dock = DockStyle.Fill;

                        if (prop.Type == typeof (string))
                        {
                                lbl.TextAlign = ContentAlignment.MiddleLeft;
                                lbl.Text = prop.Value.ToString ();
                        }
                        else if (prop.Type == typeof (DateTime))
                        {
                                lbl.TextAlign = ContentAlignment.MiddleCenter;
                                lbl.Text = String.Format (Formats.DATE, prop.Value);
                        }
                        else if (prop.Type == typeof (decimal))
                        {
                                lbl.TextAlign = ContentAlignment.MiddleRight;
                                lbl.Text = String.Format (Formats.MONEY, prop.Value);
                        }
                        else
                        {
                                lbl.TextAlign = ContentAlignment.MiddleRight;
                                lbl.Text = prop.Value.ToString ();
                        }
                        lbl.MouseDown += lbl_MouseDown;
                        lbl.MouseMove += lbl_MouseMove;
                        lbl.MouseUp += lbl_MouseUp;
                        tlp.AddCol (hdr.width, ColIndex, lbl);
                        return lbl;
                }

                public IEnumerable<Label> GetLabels ()
                {
                        return tlp.Controls.GetEnumerator ().ToList<Label> ();
                }

                private Point MousePointOnParent (object sender, MouseEventArgs e)
                {
                        Point mouseLoc = new Point ();
                        Control childCtrl = sender as Control;
                        if (childCtrl == null)
                        {
                                throw new Exception ();
                        }
                        mouseLoc.X = e.X + childCtrl.Left;
                        mouseLoc.Y = e.Y + childCtrl.Top;
                        return mouseLoc;
                }

                private void lbl_MouseDown (object sender, MouseEventArgs e)
                {
                        Point mouseLoc = MousePointOnParent (sender, e);
                        OnMouseDown (new MouseEventArgs (e.Button, 1, mouseLoc.X, mouseLoc.Y, 0));
                }

                private void lbl_MouseMove (object sender, MouseEventArgs e)
                {
                        Point mouseLoc = MousePointOnParent (sender, e);
                        OnMouseMove (new MouseEventArgs (e.Button, 1, mouseLoc.X, mouseLoc.Y, 0));
                }

                private void lbl_MouseUp (object sender, MouseEventArgs e)
                {
                        Point mouseLoc = MousePointOnParent (sender, e);
                        OnMouseUp (new MouseEventArgs (e.Button, 1, mouseLoc.X, mouseLoc.Y, 0));
                }


                // Is the cursor outside of the parent container?
                private bool IsCursorOutside (Point location)
                {
                        //Debug.WriteLine (Parent.Name + " - " + Parent.Width);
                        //Rectangle rectangle = new Rectangle (0, 0, Parent.Width, Parent.Height);
                        Rectangle rectangle = new Rectangle (0, 0, Parent.Width, Parent.Height);
                        //Debug.WriteLine (Parent.PointToClient (location));
                        return !rectangle.Contains (Parent.PointToClient (location));
                }

                private void ucOperation_MouseDown (object sender, MouseEventArgs e)
                {
                        if (e.Button == MouseButtons.Left)
                        {
                                // Save coordinates for later use in mouse up
                                //if(sender
                                MouseDownStartPoint = new Point (e.X, e.Y);
                                //Debug.WriteLine ("MouseDownStartPoint=" + MouseDownStartPoint + " - " + e.Location);

                                // Show the outline object
                                Shadow.Show (this.PointToScreen (new Point (e.X - MouseDownStartPoint.X - 1, e.Y - MouseDownStartPoint.Y - 1)), Size);

                                // Register the mouse move handler
                                MouseMove -= ucOperation_MouseMove;
                                MouseMove += ucOperation_MouseMove;
                        }
                        else
                        {
                                ShowCtxMnu (sender as Control, new Point (e.X, e.Y));
                        }
                }

                private void ucOperation_MouseMove (object sender, MouseEventArgs e)
                {
                        if (e.Button == MouseButtons.Left)
                        {
                                // Have we left the parent container?
                                if (IsCursorOutside (PointToScreen (new Point (e.X, e.Y))))
                                {
                                        // Unregister this event
                                        MouseMove -= (ucOperation_MouseMove);

                                        // Hide the outline object
                                        Shadow.Hide ();

                                        // Do start the drag-drop action
                                        DoDragDrop (this, DragDropEffects.Move);
                                }
                                else
                                {
                                        // Move the outline object
                                        Shadow.Move (PointToScreen (new Point (e.X - MouseDownStartPoint.X - 1, e.Y - MouseDownStartPoint.Y - 1)));
                                }
                        }
                }



                private void ucOperation_MouseUp (object sender, MouseEventArgs e)
                {
                        // Continue?
                        if (e.Button == MouseButtons.Left)
                        {
                                // Unregister the mouse move event
                                MouseMove -= (ucOperation_MouseMove);

                                // Hide the outline object
                                Shadow.Hide ();
                        }
                }
        }
}
