
namespace Libod.Model
{
        public interface IBaseCRUD<T> //where T : IBase, INom
        {
                ICRUD<T>   /**/ CRUD ();
        }
}
