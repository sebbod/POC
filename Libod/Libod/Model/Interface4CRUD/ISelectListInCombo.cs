
using Libod.Ctrl;
using System.Collections.Generic;

namespace Libod.Model
{
        public interface ISelectListInCombo: IComboItems
        {
                IEnumerable<ctrlItem<T>>        /**/ SelectedItems<T>   /**/() where T: ICtrlItem;
        }

        public interface ISelectListInCombo<T>: IComboItems<T>
                where T: ICtrlItem
        {
                IEnumerable<ctrlItem<T>>        /**/ SelectedItems   /**/();
        }
}
