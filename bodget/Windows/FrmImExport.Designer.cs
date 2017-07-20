namespace Bodget.Windows
{
        partial class FrmImExport
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
                        this.pnl = new System.Windows.Forms.Panel();
                        this.btnAction = new System.Windows.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // txtMsgInfo
                        // 
                        this.txtMsgInfo.BackColor = System.Drawing.SystemColors.Menu;
                        this.txtMsgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.txtMsgInfo.Location = new System.Drawing.Point(0, 249);
                        this.txtMsgInfo.Name = "txtMsgInfo";
                        this.txtMsgInfo.Size = new System.Drawing.Size(280, 20);
                        this.txtMsgInfo.TabIndex = 29;
                        // 
                        // pnl
                        // 
                        this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.pnl.Location = new System.Drawing.Point(12, 12);
                        this.pnl.Name = "pnl";
                        this.pnl.Size = new System.Drawing.Size(256, 204);
                        this.pnl.TabIndex = 30;
                        // 
                        // btnAction
                        // 
                        this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnAction.Location = new System.Drawing.Point(193, 222);
                        this.btnAction.Name = "btnAction";
                        this.btnAction.Size = new System.Drawing.Size(75, 23);
                        this.btnAction.TabIndex = 31;
                        this.btnAction.Text = "Action";
                        this.btnAction.UseVisualStyleBackColor = true;
                        // 
                        // FrmImExport
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(280, 269);
                        this.Controls.Add(this.btnAction);
                        this.Controls.Add(this.pnl);
                        this.Controls.Add(this.txtMsgInfo);
                        this.Name = "FrmImExport";
                        this.Text = "FrmExport";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.TextBox txtMsgInfo;
                private System.Windows.Forms.Panel pnl;
                private System.Windows.Forms.Button btnAction;
        }
}