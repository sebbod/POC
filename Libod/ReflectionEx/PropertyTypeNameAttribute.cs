using System;
using Libod.Attribute;

namespace Libod.ReflectionEx
{
        public class PropertyTypeNameAttribute: PropertyTypeName
        {
                public PropertyHeader PropertyHeader { get; set; }
                public ForeignKey ForeignKey { get; set; }

                public override bool Equals (object otherPropertyTypeNameAttribute)
                {
                        if(otherPropertyTypeNameAttribute == null)
                        {
                                return false;
                        }
                        PropertyTypeNameAttribute obj = otherPropertyTypeNameAttribute as PropertyTypeNameAttribute;
                        return base.Equals(obj)
                                && PropertyHeader == obj.PropertyHeader;
                }

                public override int GetHashCode ()
                {
                        return base.GetHashCode () + PropertyHeader.GetHashCode();
                }
        }


}
