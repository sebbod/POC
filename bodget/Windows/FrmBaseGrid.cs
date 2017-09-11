using System;
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

                        //pnl.BackColor = Color.LightYellow;
                        pnl.Dock = DockStyle.Fill;
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

                private int heightDelta4Resize;
                private void FrmBaseGrid_ResizeBegin (object sender, System.EventArgs e)
                {
                        heightDelta4Resize = this.Height;
                        //Console.WriteLine ("FrmBaseGrid_ResizeBegin - heightDelta4Resize=" + heightDelta4Resize);
                }
                private void FrmBaseGrid_ResizeEnd (object sender, System.EventArgs e)
                {
                       // Console.WriteLine ("FrmBaseGrid_ResizeEnd - crid.g.Height=" + crid.g.Height);
                        int heightChange = this.Height - heightDelta4Resize;
                        crid.pnl.Height                 /**/ += heightChange;
                        crid.g.Height                   /**/ += heightChange;
                        crid.btnRapprochement.Top       /**/ += heightChange;
                       // Console.WriteLine ("FrmBaseGrid_ResizeEnd - crid.g.Height=" + crid.g.Height);
                }


        }
}
