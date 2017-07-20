namespace Bodget.Windows
{
        partial class FrmBaseGrid<T>
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

                #region Windows Form Designer generated code

                /// <summary>
                /// Required method for Designer support - do not modify
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent ()
                {
                        this.txtMsgInfo = new System.Windows.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // txtMsgInfo
                        // 
                        this.txtMsgInfo.BackColor = System.Drawing.SystemColors.Menu;
                        this.txtMsgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.txtMsgInfo.Location = new System.Drawing.Point(0, 452);
                        this.txtMsgInfo.Name = "txtMsgInfo";
                        this.txtMsgInfo.Size = new System.Drawing.Size(784, 20);
                        this.txtMsgInfo.TabIndex = 19;
                        // 
                        // FrmBaseGrid
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(784, 472);
                        this.Controls.Add(this.txtMsgInfo);
                        this.MinimumSize = new System.Drawing.Size(600, 400);
                        this.Name = "FrmBaseGrid";
                        this.Text = "FrmBaseGrid";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.TextBox txtMsgInfo;



        }
}