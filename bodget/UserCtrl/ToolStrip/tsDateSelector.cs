using System.Linq;
using Bodget.Logic;
using Bodget.Model;
using LibodUserCtrl;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Bodget.UserCtrl
{
        [DefaultProperty ("Items")]
        [ToolStripItemDesignerAvailability (ToolStripItemDesignerAvailability.All)]
        public class tsDateSelector: ToolStripControlHost
        {
                public tsDateSelector ()
                        : base (new ucDateSelector (new Operation ().GetYears ().ToList ()))
                {
                }

                [Browsable (false)]
                public ucDateSelector ucDateSelector
                {
                        get { return base.Control as ucDateSelector; }
                }


                //[Browsable (true)]
                //[DefaultValue (false)]
                //public string LabelText
                //{
                //        get { return ucDateSelector.LabelText; }
                //        set { ucDateSelector.LabelText = value; }
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
