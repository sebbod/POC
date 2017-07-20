using Bodget.Model;
using Libod.DataType;

namespace Bodget.UserCtrl
{
        partial class ucCategoryContainer
        {
                private void Refresh_ucCategoryContainer ()
                {
                        SearchCriteria = null;  // si on passe par là alors RAZ du SearchCriteria
                        RefreshCategories ();
                }

                private static DateSelectorInfo _FilterByDateInfo;
                public DateSelectorInfo FilterByDateInfo
                {
                        get
                        {
                                return _FilterByDateInfo;
                        }
                        set
                        {
                                if (_FilterByDateInfo == value)
                                {
                                        return;
                                }

                                _FilterByDateInfo = value;
                                Refresh_ucCategoryContainer ();
                        }
                }

                private static Compte _FilterByCompte;
                public Compte FilterByCompte
                {
                        get
                        {
                                return _FilterByCompte;
                        }
                        set
                        {
                                if (_FilterByCompte == value)
                                {
                                        return;
                                }

                                _FilterByCompte = value;
                                Refresh_ucCategoryContainer ();
                        }
                }
        }
}
