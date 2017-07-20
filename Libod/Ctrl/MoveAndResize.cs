using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Libod.Ctrl
{
        public static class MoveAndResize
        {
                private const int MIN_RESIZE_WIDTH = 10;
                private const int MIN_RESIZE_HEIGHT = 10;

                private static bool _moving;
                private static Point _cursorStartPoint;
                private static bool _moveIsInterNal;
                private static bool _resizing;
                private static Size _currentControlStartSize;
                internal static bool MouseIsInLeftEdge { get; set; }
                internal static bool MouseIsInRightEdge { get; set; }
                internal static bool MouseIsInTopEdge { get; set; }
                internal static bool MouseIsInBottomEdge { get; set; }

                public enum WayOfWork
                {
                        Any,
                        Move,
                        Resize,
                }

                public enum Direction
                {
                        Any,
                        Horizontal,
                        Vertical
                }

                internal static WayOfWork _WorkType { get; set; }
                internal static Direction _Direction { get; set; }

                public static void Init (Control control)
                {
                        Init (control, control, Direction.Any, WayOfWork.Any);
                }

                public static void Init (Control control, Direction direction, WayOfWork wayOfWork)
                {
                        Init (control, control, direction, wayOfWork);
                }

                public static void Init (Control control, Control container, Direction direction, WayOfWork wayOfWork)
                {
                        _moving = false;
                        _resizing = false;
                        _moveIsInterNal = false;
                        _cursorStartPoint = Point.Empty;
                        MouseIsInLeftEdge = false;
                        MouseIsInRightEdge = false;
                        MouseIsInTopEdge = false;
                        MouseIsInBottomEdge = false;
                        _WorkType = wayOfWork;
                        _Direction = direction;
                        control.MouseDown += (sender, e) => MouseDown (control, e);
                        control.MouseUp += (sender, e) => MouseUp (control);
                        control.MouseMove += (sender, e) => MouseMove (container, e);
                }

                private static void UpdateMouseEdgeProperties (Control control, Point mouseLocationInControl)
                {
                        if (_WorkType == WayOfWork.Move)
                        {
                                return;
                        }
                        MouseIsInLeftEdge = Math.Abs (mouseLocationInControl.X) <= 2;
                        MouseIsInRightEdge = Math.Abs (mouseLocationInControl.X - control.Width) <= 2;
                        MouseIsInTopEdge = Math.Abs (mouseLocationInControl.Y) <= 2;
                        MouseIsInBottomEdge = Math.Abs (mouseLocationInControl.Y - control.Height) <= 2;
                }

                private static void UpdateMouseCursor (Control control)
                {
                        if (_WorkType == WayOfWork.Move)
                        {
                                return;
                        }
                        if (MouseIsInLeftEdge)
                        {
                                if (MouseIsInTopEdge)
                                {
                                        control.Cursor = Cursors.SizeNWSE;
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        control.Cursor = Cursors.SizeNESW;
                                }
                                else
                                {
                                        control.Cursor = Cursors.SizeWE;
                                }
                        }
                        else if (MouseIsInRightEdge)
                        {
                                if (MouseIsInTopEdge)
                                {
                                        control.Cursor = Cursors.SizeNESW;
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        control.Cursor = Cursors.SizeNWSE;
                                }
                                else
                                {
                                        control.Cursor = Cursors.SizeWE;
                                }
                        }
                        else if (MouseIsInTopEdge || MouseIsInBottomEdge)
                        {
                                control.Cursor = Cursors.SizeNS;
                        }
                        else
                        {
                                control.Cursor = Cursors.Default;
                        }
                }

                private static void MouseDown (Control control, MouseEventArgs e)
                {
                        if (_moving || _resizing)
                        {
                                return;
                        }
                        if (_WorkType != WayOfWork.Move &&
                            (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
                        {
                                _resizing = true;
                                _currentControlStartSize = control.Size;
                        }
                        else if (_WorkType != WayOfWork.Resize)
                        {
                                _moving = true;
                                control.Cursor = Cursors.Hand;
                        }
                        _cursorStartPoint = new Point (e.X, e.Y);
                        control.Capture = true;
                }

                private static void MouseMove (Control control, MouseEventArgs e)
                {
                        if (!_resizing && !_moving)
                        {
                                UpdateMouseEdgeProperties (control, new Point (e.X, e.Y));
                                UpdateMouseCursor (control);
                        }
                        if (_resizing)
                        {
                                if (MouseIsInLeftEdge)
                                {
                                        if (MouseIsInTopEdge)
                                        {
                                                control.Width -= (e.X - _cursorStartPoint.X);
                                                if (_Direction != Direction.Vertical)
                                                {
                                                        control.Left += (e.X - _cursorStartPoint.X);
                                                }
                                                control.Height -= (e.Y - _cursorStartPoint.Y);
                                                if (_Direction != Direction.Horizontal)
                                                {
                                                        control.Top += (e.Y - _cursorStartPoint.Y);
                                                }
                                        }
                                        else if (MouseIsInBottomEdge)
                                        {
                                                control.Width -= (e.X - _cursorStartPoint.X);
                                                if (_Direction != Direction.Vertical)
                                                {
                                                        control.Left += (e.X - _cursorStartPoint.X);
                                                }
                                                control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                                        }
                                        else
                                        {
                                                control.Width -= (e.X - _cursorStartPoint.X);
                                                if (_Direction != Direction.Vertical)
                                                {
                                                        control.Left += (e.X - _cursorStartPoint.X);
                                                }
                                        }
                                }
                                else if (MouseIsInRightEdge)
                                {
                                        if (MouseIsInTopEdge)
                                        {
                                                control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                                                control.Height -= (e.Y - _cursorStartPoint.Y);
                                                if (_Direction != Direction.Horizontal)
                                                {
                                                        control.Top += (e.Y - _cursorStartPoint.Y);
                                                }

                                        }
                                        else if (MouseIsInBottomEdge)
                                        {
                                                control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                                                control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                                        }
                                        else
                                        {
                                                control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                                        }
                                }
                                else if (MouseIsInTopEdge)
                                {
                                        control.Height -= (e.Y - _cursorStartPoint.Y);
                                        if (_Direction != Direction.Horizontal)
                                        {
                                                control.Top += (e.Y - _cursorStartPoint.Y);
                                        }
                                }
                                else if (MouseIsInBottomEdge)
                                {
                                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                                }
                                else
                                {
                                        MouseUp (control);
                                }
                        }
                        else if (_moving)
                        {
                                _moveIsInterNal = !_moveIsInterNal;
                                if (!_moveIsInterNal)
                                {
                                        int x = (e.X - _cursorStartPoint.X) + control.Left;
                                        int y = (e.Y - _cursorStartPoint.Y) + control.Top;
                                        control.Location = new Point (x, y);
                                }
                        }
                }

                private static void MouseUp (Control control)
                {
                        _resizing = false;
                        _moving = false;
                        control.Capture = false;
                        UpdateMouseCursor (control);
                }

                #region Save And Load

                private static List<Control> GetAllChildControls (Control control, List<Control> list)
                {
                        List<Control> controls = control.Controls.Cast<Control> ().ToList ();
                        list.AddRange (controls);
                        return controls.SelectMany (ctrl => GetAllChildControls (ctrl, list)).ToList ();
                }

                internal static string GetSizeAndPositionOfControlsToString (Control container)
                {
                        List<Control> controls = new List<Control> ();
                        GetAllChildControls (container, controls);
                        CultureInfo cultureInfo = new CultureInfo ("en");
                        string info = string.Empty;
                        foreach (Control control in controls)
                        {
                                info += control.Name + ":" + control.Left.ToString (cultureInfo) + "," + control.Top.ToString (cultureInfo) + "," +
                                        control.Width.ToString (cultureInfo) + "," + control.Height.ToString (cultureInfo) + "*";
                        }
                        return info;
                }
                internal static void SetSizeAndPositionOfControlsFromString (Control container, string controlsInfoStr)
                {
                        List<Control> controls = new List<Control> ();
                        GetAllChildControls (container, controls);
                        string[] controlsInfo = controlsInfoStr.Split (new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string> ();
                        foreach (string controlInfo in controlsInfo)
                        {
                                string[] info = controlInfo.Split (new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                controlsInfoDictionary.Add (info[0], info[1]);
                        }
                        foreach (Control control in controls)
                        {
                                string propertiesStr;
                                controlsInfoDictionary.TryGetValue (control.Name, out propertiesStr);
                                string[] properties = propertiesStr.Split (new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (properties.Length == 4)
                                {
                                        control.Left = int.Parse (properties[0]);
                                        control.Top = int.Parse (properties[1]);
                                        control.Width = int.Parse (properties[2]);
                                        control.Height = int.Parse (properties[3]);
                                }
                        }
                }

                #endregion
        }
}
