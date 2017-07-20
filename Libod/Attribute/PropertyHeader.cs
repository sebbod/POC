
namespace Libod.Attribute
{
        public class PropertyHeader: System.Attribute
        {
                public string text { get; protected set; }
                public int width { get; protected set; }
                public bool visible { get; protected set; }

                public PropertyHeader (string text, int width = 0, bool visible = true)
                {
                        this.text = text;
                        this.width = width;
                        this.visible = visible;
                }
        }
}
