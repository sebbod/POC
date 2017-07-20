
using Libod.Model;

namespace Libod.Ctrl
{
        public class ctrlItem
        {
                public string Text { get; set; }
                public object Value { get; set; }

                public override string ToString ()
                {
                        return Text;
                }
        }

        public class CtrlItem: ICtrlItem
        {
                public long id { get; set; }
                public string nom { get; set; }
        }

        //public class ctrlItem<T> : IBase
        //        where T: IBase, INom
        public class ctrlItem<T> : IBase
                where T: ICtrlItem
        {
                public long id { get; set; }
                public string Text { get; set; }
                public T Value { get; set; }

                public override string ToString ()
                {
                        return Text;
                }
        }
}
