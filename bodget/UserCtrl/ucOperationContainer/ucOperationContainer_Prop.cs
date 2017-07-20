using Bodget.Model;
using System.Linq;

namespace Bodget.UserCtrl
{
        public partial class ucOperationContainer
        {

                private Category _Category;
                public Category Category
                {
                        get
                        {
                                return _Category;
                        }
                        set
                        {
                                _Category = value;
                                if (_Category != null)
                                {
                                        ucTitleBar.Text = _Category.nom;
                                }
                        }
                }

                public decimal Mt
                {
                        get
                        {
                                return ucTitleBar.Mt;
                        }
                        set
                        {
                                ucTitleBar.Mt = value;
                        }
                }
        }
}
