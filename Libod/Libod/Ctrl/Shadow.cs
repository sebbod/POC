using System.Drawing;
using System.Windows.Forms;

namespace Libod.Ctrl
{
        public class Shadow: Form
        {
                private static Shadow _shadow;

                public Shadow ()
                {
                        SuspendLayout ();
                        ClientSize = new System.Drawing.Size (0, 0);
                        StartPosition = FormStartPosition.Manual;
                        BackColor = Color.Black;
                        Opacity = 0.4;
                        FormBorderStyle = FormBorderStyle.None;
                        ShowInTaskbar = false;
                        ControlBox = false;
                        TopMost = true;
                        ResumeLayout (false);
                }

                // Show
                static public void Show (Point location, Size size)
                {
                        // Create a new object?
                        if (_shadow == null)
                        {
                                _shadow = new Shadow ();
                                _shadow.Show (); // Just to get the size correct at first use (.NET bug?). Try to remove this line...
                        }
                        // Set the location and size, then show the form
                        _shadow.Location = location;
                        _shadow.Size = size;
                        _shadow.Show ();
                }

                // Hide
                new static public void Hide ()
                {
                        if (_shadow != null)
                        {
                                // Since we hide the original Hide() method we need to do this...
                                (_shadow as Control).Hide ();
                        }
                }

                // Resize
                new static public void Resize (Size size)
                {
                        if (_shadow != null)
                        {
                                (_shadow as Control).Size = size;
                        }
                }

                // Move
                new static public void Move (Point point)
                {
                        if (_shadow != null)
                        {
                                (_shadow as Control).Location = point;
                        }
                }
        }
}
