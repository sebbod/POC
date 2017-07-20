using System.Windows.Forms;

namespace Bodget.UserCtrl
{
        public partial class ucOperationContainer
        {

                private ucOperation _ucOpDrag;

                private void ucOperationContainer_DragEnter (object sender, DragEventArgs e)
                {
                        if (e.Data.GetDataPresent (typeof (ucOperation)))
                        {
                                _ucOpDrag = e.Data.GetData (typeof (ucOperation)) as ucOperation;
                                e.Effect = DragDropEffects.Move;
                        }
                        else
                        {
                                e.Effect = DragDropEffects.None;
                        }
                }

                private void ucOperationContainer_DragDrop (object sender, DragEventArgs e)
                {
                        if (e.Data.GetDataPresent (typeof (ucOperation)))
                        {
                                Add (_ucOpDrag);
                        }
                }
        }
}
