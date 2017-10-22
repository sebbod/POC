
using System.Collections.Generic;

namespace Libod.Model
{
        public interface IBaseHas: IBase
        {
                long    /**/ id1         /**/{ get; set; }
                long    /**/ id2         /**/{ get; set; }
                void UpdateLstId2InObj1<T1> (IBaseHas has) where T1: IBase;
                void DeleteLstId2InObj1<T1> (IBaseHas has) where T1: IBase;
                //IEnumerable<T1> lstObj1<T1> (IBaseHas has) where T1: IBase;
                //IEnumerable<T2> lstObj2<T2> (IBaseHas has) where T2: IBase;
        }
}
