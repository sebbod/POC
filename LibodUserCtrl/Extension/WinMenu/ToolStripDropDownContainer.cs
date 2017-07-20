using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LibodUserCtrl.Extension.WinMenu
{
        public partial class ToolStripDropDownContainer: ToolStripDropDown
        {
                private Control _toolStripItemConrolContainer;
                private bool _fade = true;

                public ToolStripDropDownContainer (Control toolStripItemContainer)
                {
                        InitializeComponent ();

                        if (toolStripItemContainer == null)
                        {
                                throw new ArgumentNullException ("content");
                        }

                        _toolStripItemConrolContainer = toolStripItemContainer;

                        _fade = SystemInformation.IsMenuAnimationEnabled && SystemInformation.IsMenuFadeEnabled;

                        ToolStripControlHost tsCtrlHost = new ToolStripControlHost (toolStripItemContainer);
                        tsCtrlHost.AutoSize = false;//make it take the same room as the poped control

                        Padding = Margin = tsCtrlHost.Padding = tsCtrlHost.Margin = Padding.Empty;

                        toolStripItemContainer.Location = Point.Empty;

                        // ToolStripDropDown.Items
                        Items.Add (tsCtrlHost);

                        toolStripItemContainer.Disposed += delegate (object sender, EventArgs e)
                        {
                                toolStripItemContainer = null;
                                Dispose (true);// this popup container will be disposed immediately after disposion of the contained control
                        };
                }




                protected override bool ProcessDialogKey (Keys keyData)
                {
                        //prevent alt from closing it and allow alt+menumonic to work
                        if ((keyData & Keys.Alt) == Keys.Alt)
                        {
                                return false;
                        }

                        return base.ProcessDialogKey (keyData);
                }






                public void Show (Control control)
                {
                        if (control == null)
                        {
                                throw new ArgumentNullException ("control");
                        }

                        Show (control, control.ClientRectangle);
                }

                public void Show (Form f, Point p)
                {
                        this.Show (f, new Rectangle (p, new Size (0, 0)));

                }

                private void Show (Control control, Rectangle area)
                {
                        if (control == null)
                        {
                                throw new ArgumentNullException ("control");
                        }


                        Point location = control.PointToScreen (new Point (area.Left, area.Top + area.Height));

                        Rectangle screen = Screen.FromControl (control).WorkingArea;

                        if (location.X + Size.Width > (screen.Left + screen.Width))
                        {
                                location.X = (screen.Left + screen.Width) - Size.Width;
                        }

                        if (location.Y + Size.Height > (screen.Top + screen.Height))
                        {
                                location.Y -= Size.Height + area.Height;
                        }

                        location = control.PointToClient (location);

                        Show (control, location, ToolStripDropDownDirection.BelowRight);
                }




                private const int frames = 5;
                private const int totalduration = 100;
                private const int frameduration = totalduration / frames;

                protected override void SetVisibleCore (bool visible)
                {
                        double opacity = Opacity;
                        if (visible && _fade)
                        {
                                Opacity = 0;
                        }
                        base.SetVisibleCore (visible);

                        if (!visible || !_fade)
                        {
                                return;
                        }
                        for (int i = 1; i <= frames; i++)
                        {
                                if (i > 1)
                                {
                                        System.Threading.Thread.Sleep (frameduration);
                                }
                                Opacity = opacity * (double)i / (double)frames;
                        }
                        Opacity = opacity;
                }




                protected override void OnOpening (CancelEventArgs e)
                {
                        if (_toolStripItemConrolContainer.IsDisposed || _toolStripItemConrolContainer.Disposing)
                        {
                                e.Cancel = true;
                                return;
                        }
                        base.OnOpening (e);
                }

                protected override void OnOpened (EventArgs e)
                {
                        _toolStripItemConrolContainer.Focus ();

                        base.OnOpened (e);
                }

        }
}
