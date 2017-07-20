namespace Bodget.UserCtrl
{
        partial class ucCategoryContainer
        {
                /// <summary> 
                /// Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary> 
                /// Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                protected override void Dispose (bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose ();
                        }
                        base.Dispose (disposing);
                }

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent ()
                {
                        this.tlp = new System.Windows.Forms.TableLayoutPanel();
                        this.SuspendLayout();
                        // 
                        // tlp
                        // 
                        this.tlp.ColumnCount = 1;
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tlp.Location = new System.Drawing.Point(0, 0);
                        this.tlp.Name = "tlp";
                        this.tlp.RowCount = 1;
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
                        this.tlp.Size = new System.Drawing.Size(338, 303);
                        this.tlp.TabIndex = 0;
                        // 
                        // ucCategoryContainer
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.tlp);
                        this.Name = "ucCategoryContainer";
                        this.Size = new System.Drawing.Size(338, 303);
                        this.Load += new System.EventHandler(this.ucCategoryContainer_Load);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tlp;

        }
}
