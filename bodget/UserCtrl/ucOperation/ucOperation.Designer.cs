namespace Bodget.UserCtrl
{
        partial class ucOperation
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
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tlp.Location = new System.Drawing.Point(3, 3);
                        this.tlp.Name = "tlp";
                        this.tlp.RowCount = 1;
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tlp.Size = new System.Drawing.Size(152, 88);
                        this.tlp.TabIndex = 0;
                        // 
                        // ucOperation
                        // 
                        this.AllowDrop = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.SystemColors.Control;
                        this.Controls.Add(this.tlp);
                        this.Name = "ucOperation";
                        this.Size = new System.Drawing.Size(251, 129);
                        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucOperation_MouseDown);
                        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucOperation_MouseMove);
                        this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucOperation_MouseUp);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tlp;
        }
}
