using System;

namespace Libod.ReflectionEx
{
        public class PropertyTypeName
        {
                public Type Type { get; set; }
                public String Name { get; set; }

                public override bool Equals (object otherPropertyTypeName)
                {
                        if (otherPropertyTypeName == null)
                        {
                                return false;
                        }
                        PropertyTypeName obj = otherPropertyTypeName as PropertyTypeName;
                        return obj != null
                                && Type == obj.Type
                                && Name == obj.Name;
                }

                public override int GetHashCode ()
                {
                        return Name.GetHashCode () + Type.GetHashCode ();
                }
        }
}
