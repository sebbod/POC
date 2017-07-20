using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodget.Data;
using Bodget.Model;
using Libod.Model;

namespace Bodget.Logic
{
        public static class BaseEx
        {
                /// <summary>
                /// Move the Object with idFirst (= o.id) to idTwo and 
                /// the Object with idTwo to idFirst
                /// useful because the id is used to set object's order
                /// </summary>
                /// <param name="o"></param>
                /// <param name="idTwo"></param>
                /// <returns>false if don't moved</returns>
                public static bool Move<T> (this T o, int idTwo)
                        where T : IBase
                {
                        return BaseMng<T>.Instance.Move (o.id, idTwo);
                }
        }
}
