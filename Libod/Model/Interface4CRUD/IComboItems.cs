
using Libod.Ctrl;
using System.Collections.Generic;

namespace Libod.Model
{
        public interface IComboItems
        {
                IEnumerable<ctrlItem<T>>        /**/ ComboItems<T>      /**/() where T: ICtrlItem;
        }

        public interface IComboItems<T> where T: ICtrlItem
        {
                IEnumerable<ctrlItem<T>>        /**/ ComboItems         /**/();
                ICollection<ctrlItem<T>>        /**/ ComboItems4Cell    /**/();
        }
}
