using System;
using System.Linq;
using System.Windows.Forms;

namespace Libod.Ctrl
{
        public class Drager<Tdrager, Tdragable>
                where Tdrager: Control
                where Tdragable: Control
        {

                private readonly Tdrager _ucOpContainer;
                private Tdragable _ucOp;
                private int _lineHeight;
                private int _startTop;

                private int ucOpCount
                {
                        get
                        {
                                return _ucOpContainer.Controls.OfType<Tdragable> ().Count ();
                        }
                }

                public Drager (Tdrager control)
                {
                        _ucOpContainer = control;
                }

                public void AddDragableCtrl (Tdragable control, int lineHeight, int startTop)
                {
                        _lineHeight = lineHeight;
                        _startTop = startTop;
                        control.DragEnter += DragEnter;
                        control.DragDrop += DragDrop;
                        control.DragLeave += DragLeave;
                }

                private void DragEnter (Object sender, DragEventArgs e)
                {
                        if (e.Data.GetDataPresent (typeof (Tdragable)))
                        {
                                _ucOp = e.Data.GetData (typeof (Tdragable)) as Tdragable;
                                e.Effect = DragDropEffects.Move;
                        }
                        else
                        {
                                e.Effect = DragDropEffects.None;
                        }
                }

                private void DragDrop (Object sender, DragEventArgs e)
                {
                        if (e.Data.GetDataPresent (typeof (Tdragable)))
                        {
                                _ucOp.Top = (_lineHeight * ucOpCount) + _startTop;
                                _ucOp.Width = _ucOpContainer.Width;
                                _ucOp.Height = _lineHeight;
                                _ucOpContainer.Controls.Add (_ucOp);
                        }
                }

                private void DragLeave (Object sender, EventArgs e)
                {
                        _ucOp = null;
                }

        }
}
