
namespace Bodget.Model
{
        public class CategorySub
        {
                public long     /**/ id         /**/{ get; set; }
                public string   /**/ nom        /**/{ get; set; }
                /// <summary>
                /// FK -> Category.id
                /// </summary>
                public long     /**/ idCategory         /**/{ get; set; }
        }
}
