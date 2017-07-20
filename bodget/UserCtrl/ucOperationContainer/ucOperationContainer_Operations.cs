using System;
using System.Windows.Forms;
using Bodget.Model;
using System.Linq;

namespace Bodget.UserCtrl
{
        public partial class ucOperationContainer
        {
                private const int OP_LINE_HEIGHT = 21;
                private const int OP_HEADER_LINE_HEIGHT = 25;

                /// <summary>
                /// Control container des ucOperations
                /// </summary>
                public Panel opContainer { get; set; }

                public int ucOpCount
                {
                        get
                        {
                                return opContainer.Controls.OfType<ucOperation> ().Count ();
                        }
                }

                public void RefreshLblOperationCount ()
                {
                        ucTitleBar.OperationCount = ucOpCount;
                }

                public void AddHeader (ucOperationHeader ucOp)
                {
                        PlaceUcOperation (ucOp);
                }

                public void Add (ucOperation ucOp)
                {
                        if (opContainer.Contains (ucOp))
                        {
                                return;
                        }

                        Mt += ucOp.Operation.mt;
                        if (ucOp.Parent != null)
                        {
                                // after a Drag and Drop
                                Panel oldOpContainerParent = ucOp.Parent as Panel;
                                foreach (ucOperation ucOpRestant in oldOpContainerParent.Controls.OfType<ucOperation> ().Where (x => x.Top > ucOp.Top))
                                {
                                        ucOpRestant.Top -= OP_LINE_HEIGHT;
                                }
                                PlaceUcOperation (ucOp);
                                TableLayoutPanel tlpParent = oldOpContainerParent.Parent as TableLayoutPanel;
                                ucOperationContainer oldUcOpContainer = tlpParent.Parent as ucOperationContainer;
                                oldUcOpContainer.RefreshLblOperationCount ();
                                oldUcOpContainer.Remove (ucOp);
                                ucOp.Category = Category;
                        }
                        else
                        {
                                // at initialisation
                                PlaceUcOperation (ucOp);
                                _ucOpDrag = null;
                        }
                        RefreshLblOperationCount ();
                }

                public void Remove (ucOperation ucOp)
                {
                        Mt -= ucOp.Operation.mt;
                }

                //private void PlaceUcOperation (ucOperation ucOp)
                private void PlaceUcOperation (Control ucOp)
                {
                        //ucOp.SizeChanged += ucOp_SizeChanged;
                        if (ucOp.GetType () == typeof (ucOperationHeader))
                        {
                                ucOp.Top = 0;
                                ucOp.Width = Width;
                                ucOp.Height = OP_HEADER_LINE_HEIGHT;
                        }
                        else
                        {
                                ucOp.Top = OP_HEADER_LINE_HEIGHT  + (OP_LINE_HEIGHT * ucOpCount) + 1;
                                ucOp.Width = Width;
                                ucOp.Height = OP_LINE_HEIGHT;
                        }
                        opContainer.Controls.Add (ucOp);
                }
               
        }
}
