using Bodget.Model;
using Libod.ReflectionEx;
using System;

namespace Bodget.Logic
{
        public static class PropertyTypeNameAttributeEx
        {

                public static PropertyHeader CreatePropertyHeader (this PropertyTypeNameAttribute prop, Type typeParent)
                {
                        PropertyHeader oh = new PropertyHeader ();
                        oh.visible = prop.PropertyHeader.visible;
                        oh.nom = prop.PropertyHeader.text;
                        oh.propertyName = prop.Name;
                        oh.propertyType = prop.Type;
                        oh.width = prop.PropertyHeader.width;
                        oh.typeParent = typeParent;
                        return oh;
                }
        }
}
