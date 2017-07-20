using System;

namespace Libod.ReflectionEx
{
        public class PropertyTypeNameValueAttribute : PropertyTypeNameAttribute
        {
                public Object Value { get; set; }

                public override bool Equals (object otherPropertyTypeNameValueAttribute)
                {
                        if(otherPropertyTypeNameValueAttribute == null)
                        {
                                return false;
                        }
                        PropertyTypeNameValueAttribute obj = otherPropertyTypeNameValueAttribute as PropertyTypeNameValueAttribute;
                        return base.Equals(obj)
                                && Value == obj.Value;
                }

                public override int GetHashCode ()
                {
                        return base.GetHashCode () + Value.GetHashCode();
                }
        }
}
