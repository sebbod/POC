using Bodget.CRUD;
using Libod.Model;
using System.Windows.Forms;

namespace Bodget.Windows
{
        public partial class FrmBaseGrid<T>: Form
                where T: IBase, IBaseCRUD<T>, new ()
        {

                private crudGrid<T> crid;
                public Panel    /**/ pnl = new Panel ();

                public FrmBaseGrid ()
                {
                        InitializeComponent ();

                        var o = new T ();

                        Text = o.CRUD ().frmTitle;


                        pnl.Dock = DockStyle.Fill;
                        //pnl.BackColor = Color.LightYellow;
                        Controls.Add (pnl);

                        // init
                        crid = new crudGrid<T> (o);
                        var p = crid.CreateObject (pnl);

                        // ajoute un panel de fin pour compléter la place restante (s'il en reste bien sur)
                        var pnlBottom = new Panel ();
                        pnlBottom.Height = pnl.Height - p.Height;
                        pnlBottom.Dock = DockStyle.Bottom;
                        pnl.Controls.Add (pnlBottom);
                }
        }
}
