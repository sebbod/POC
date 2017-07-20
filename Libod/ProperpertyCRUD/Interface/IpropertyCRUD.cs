
using System;
using System.Windows.Forms;

namespace Libod.Model
{
        public interface IpropertyCRUD<T>
        {
                T               /**/ Object             /**/{ get; }
                Panel           /**/ CreateObject       /**/(Panel parentPanel);
                /// <summary>
                /// 
                /// </summary>
                /// <returns>Exception or null</returns>
                Exception       /**/ Validation         /**/();
                void            /**/ Insert             /**/();
                void            /**/ Update             /**/();
        }
}
