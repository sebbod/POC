using System.Text;

namespace Libod
{
  public static class StringBuilderEx
  {

    public static StringBuilder SelectFirstChar(this StringBuilder sbVal, int length)
    {
      if (length < 0) return sbVal;
      if (sbVal.Length < length) return sbVal; // on veut sélectionner plus que la longueur de la chaine donc on vide l'objet
      
      if (sbVal.Length >= length)
      {
        int len2remove = sbVal.Length - length;
        sbVal = sbVal.Remove(length, len2remove);
      }
      return sbVal;
    }

    /// <summary>
    /// supprime les X derniers caractère d'une chaine
    /// <para>ne fait rien si le paramétre length est inférieur à 0</para>
    /// </summary>
    /// <param name="sbVal"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static StringBuilder RemoveLastChar(this StringBuilder sbVal, int length)
    {
      if (length < 0) return sbVal;
      if (sbVal.Length < length)
      {
        // on veut supprimer plus que la longueur de la chaine donc on vide l'objet
        sbVal.Clear();
        return sbVal;
      }
      if (sbVal.Length >= length)
      {
        sbVal = sbVal.Remove(sbVal.Length - length, length);
      }
      return sbVal;
    }

    /// <summary>
    /// supprime le dernier caractère d'une chaine
    /// </summary>
    /// <param name="sbVal"></param>
    /// <returns></returns>
    public static StringBuilder RemoveTheLastChar(this StringBuilder sbVal)
    {
      int longueurActuelle = sbVal.Length;
      if (longueurActuelle > 1)
      {
        // Dans le cas où le dernier caractère est un FinDeLigne (CR+LF), il faut supprimer 2 caractères
        if (sbVal[longueurActuelle - 1] == '\n')
        {
          if (sbVal[longueurActuelle - 2] == '\r')
          {
            // Supprimer les 2 caractères signifiant NouvelleLigne
            return RemoveLastChar(sbVal, 2);
          }
        }
      }
      return RemoveLastChar(sbVal, 1);
    }
  }
}
