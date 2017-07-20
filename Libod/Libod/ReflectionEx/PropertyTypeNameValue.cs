using System;

namespace Libod.ReflectionEx
{
        public class PropertyTypeNameValue: PropertyTypeName
        {
                public Object Value { get; set; }

                public override bool Equals (object otherPropertyTypeNameValue)
                {
                        if(otherPropertyTypeNameValue == null)
                        {
                                return false;
                        }
                        PropertyTypeNameValue obj = otherPropertyTypeNameValue as PropertyTypeNameValue;
                        return base.Equals(obj)
                                && Value == obj.Value;
                }

                public override int GetHashCode ()
                {
                        return base.GetHashCode () + Value.GetHashCode();
                }
        }
}
