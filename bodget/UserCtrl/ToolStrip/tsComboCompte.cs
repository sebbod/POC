using System.Linq;
using Bodget.CRUD;
using Bodget.Logic;
using Bodget.Model;
using LibodUserCtrl;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using RESX = Libod.ResourceText;

namespace Bodget.UserCtrl
{
        [DefaultProperty ("Items")]
        [ToolStripItemDesignerAvailability (ToolStripItemDesignerAvailability.All)]
        public class tsComboCompte: ToolStripControlHost
        {
                public tsComboCompte ()
                        : base (new ucCombo (RESX.Compte, 80, new Compte ().ComboLst ().ToList (), Constantes.CTRL_MARGE))
                {
                }

                [Browsable (false)]
                public ucCombo ucCombo
                {
                        get { return base.Control as ucCombo; }
                }


                //[Browsable (true)]
                //[DefaultValue (false)]
                //public string LabelText
                //{
                //        get { return ucCombo.LabelText; }
                //        set { ucCombo.LabelText = value; }
                //}

                //[Localizable (true)]
                //[DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
                //[Editor ("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
                //public System.Windows.Forms.ComboBox.ObjectCollection Items
                //{
                //        get { return ComboBoxWithLabel.comboBox1.Items; }
                //        set
                //        {
                //                foreach (var item in value)
                //                {
                //                        ComboBoxWithLabel.comboBox1.Items.Add (item);
                //                }
                //        }
                //}
        }
}
