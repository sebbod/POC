
using System;

namespace Libod.Attribute
{
        public class ForeignKey: System.Attribute
        {
                public Type type { get; protected set; }


                public ForeignKey (Type type)
                {
                        this.type = type;
                }
        }
}
