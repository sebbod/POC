using System;
using Bodget.Data;
using Bodget.Model;
using Libod.ReflectionEx;
using System.Linq;

namespace Bodget.Logic
{
        public static class PropertyTypeNameEx
        {
                [Obsolete ("use PropertyTypeNameAttribute instead", true)]
                public static PropertyHeader PropertyHeader (this PropertyTypeName o)
                {
                        var val = BaseMng<PropertyHeader>.Instance.All.FirstOrDefault (h => h.propertyName == o.Name);
                        if (val == null)
                        {
                                throw new Exception ("create a new entry in static void create_PropertyHeader () in Program.cs");
                        }
                        return val;
                }
        }
}
