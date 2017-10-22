
namespace Libod.Model
{
        public enum CRUDform
        {
                /// <summary>
                /// bouton actif => Annuler
                /// </summary>
                select = 0,
                /// <summary>
                /// bouton actif => Annuler + ajouter
                /// </summary>
                insert = 1,
                /// <summary>
                /// bouton actif => Annuler + modifier
                /// </summary>
                update = 2,
                /// <summary>
                /// bouton actif => Annuler + supprimer
                /// </summary>
                delete = 4,
        }
}
