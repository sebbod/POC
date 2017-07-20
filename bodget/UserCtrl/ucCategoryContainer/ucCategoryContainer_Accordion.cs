using System;
using Bodget.Data;
using Bodget.Model;
using System.Linq;

namespace Bodget.UserCtrl
{
        partial class ucCategoryContainer
        {
                private void AccordionClick (Object sender, EventArgs e)
                {
                        ucOperationContainer ucOpCont = sender as ucOperationContainer;
                        foreach (ucOperationContainer opc in tlp.Controls)
                        {
                                //Console.WriteLine (ucOpCont.Name + ", " + opc.Name);
                                if (opc.Equals (ucOpCont))
                                {
                                        // gestion du flag isOpen4ucOperationContainer
                                        // dans la base
                                        opc.Category.isOpen4ucOperationContainer = !opc.Category.isOpen4ucOperationContainer;
                                        BaseMng<Category>.Instance.Update (opc.Category, c => c.isOpen4ucOperationContainer = opc.Category.isOpen4ucOperationContainer);
                                        // dans l'IHM
                                        opc.DetailVisible = opc.Category.isOpen4ucOperationContainer;
                                }
                        }
                }
        }
}
