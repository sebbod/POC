namespace Bodget.Windows
{
        partial class FrmBaseCRUD<T>
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
                        this.lstObjet = new System.Windows.Forms.ListBox();
                        this.lblLstObjet = new System.Windows.Forms.Label();
                        this.btnDelete = new System.Windows.Forms.Button();
                        this.txtMsgInfo = new System.Windows.Forms.TextBox();
                        this.btnAdd = new System.Windows.Forms.Button();
                        this.btnCancel = new System.Windows.Forms.Button();
                        this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                        this.pnlCreateObject = new System.Windows.Forms.Panel();
                        this.SuspendLayout();
                        // 
                        // lstObjet
                        // 
                        this.lstObjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.lstObjet.FormattingEnabled = true;
                        this.lstObjet.Location = new System.Drawing.Point(12, 35);
                        this.lstObjet.Name = "lstObjet";
                        this.lstObjet.Size = new System.Drawing.Size(196, 394);
                        this.lstObjet.TabIndex = 16;
                        this.lstObjet.SelectedIndexChanged += new System.EventHandler(this.lstObjet_SelectedIndexChanged);
                        // 
                        // lblLstObjet
                        // 
                        this.lblLstObjet.Location = new System.Drawing.Point(12, 9);
                        this.lblLstObjet.Name = "lblLstObjet";
                        this.lblLstObjet.Size = new System.Drawing.Size(196, 23);
                        this.lblLstObjet.TabIndex = 15;
                        this.lblLstObjet.Text = "Liste des objets existantes :";
                        this.lblLstObjet.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // btnDelete
                        // 
                        this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.btnDelete.Location = new System.Drawing.Point(233, 410);
                        this.btnDelete.Name = "btnDelete";
                        this.btnDelete.Size = new System.Drawing.Size(71, 26);
                        this.btnDelete.TabIndex = 20;
                        this.btnDelete.Text = "Supprimer";
                        this.btnDelete.UseVisualStyleBackColor = true;
                        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                        // 
                        // txtMsgInfo
                        // 
                        this.txtMsgInfo.BackColor = System.Drawing.SystemColors.Menu;
                        this.txtMsgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.txtMsgInfo.Location = new System.Drawing.Point(0, 442);
                        this.txtMsgInfo.Name = "txtMsgInfo";
                        this.txtMsgInfo.Size = new System.Drawing.Size(784, 20);
                        this.txtMsgInfo.TabIndex = 19;
                        // 
                        // btnAdd
                        // 
                        this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnAdd.Location = new System.Drawing.Point(624, 410);
                        this.btnAdd.Name = "btnAdd";
                        this.btnAdd.Size = new System.Drawing.Size(71, 26);
                        this.btnAdd.TabIndex = 18;
                        this.btnAdd.Text = "Ajouter";
                        this.btnAdd.UseVisualStyleBackColor = true;
                        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                        // 
                        // btnCancel
                        // 
                        this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.btnCancel.Location = new System.Drawing.Point(701, 410);
                        this.btnCancel.Name = "btnCancel";
                        this.btnCancel.Size = new System.Drawing.Size(71, 26);
                        this.btnCancel.TabIndex = 17;
                        this.btnCancel.Text = "Annuler";
                        this.btnCancel.UseVisualStyleBackColor = true;
                        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                        // 
                        // lineShape1
                        // 
                        this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.lineShape1.Name = "lineShape1";
                        this.lineShape1.X1 = 220;
                        this.lineShape1.X2 = 220;
                        this.lineShape1.Y1 = 0;
                        this.lineShape1.Y2 = 442;
                        // 
                        // shapeContainer1
                        // 
                        this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
                        this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                        this.shapeContainer1.Name = "shapeContainer1";
                        this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
                        this.shapeContainer1.Size = new System.Drawing.Size(784, 462);
                        this.shapeContainer1.TabIndex = 21;
                        this.shapeContainer1.TabStop = false;
                        // 
                        // pnlCreateObject
                        // 
                        this.pnlCreateObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.pnlCreateObject.AutoScroll = true;
                        this.pnlCreateObject.Location = new System.Drawing.Point(233, 9);
                        this.pnlCreateObject.Name = "pnlCreateObject";
                        this.pnlCreateObject.Size = new System.Drawing.Size(539, 395);
                        this.pnlCreateObject.TabIndex = 24;
                        // 
                        // FrmBaseCRUD
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(784, 462);
                        this.Controls.Add(this.btnDelete);
                        this.Controls.Add(this.txtMsgInfo);
                        this.Controls.Add(this.btnAdd);
                        this.Controls.Add(this.btnCancel);
                        this.Controls.Add(this.lstObjet);
                        this.Controls.Add(this.lblLstObjet);
                        this.Controls.Add(this.pnlCreateObject);
                        this.Controls.Add(this.shapeContainer1);
                        this.MinimumSize = new System.Drawing.Size(600, 400);
                        this.Name = "FrmBaseCRUD";
                        this.Text = "FrmBaseCRUD";
                        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBaseCRUD_FormClosed);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.ListBox lstObjet;
                private System.Windows.Forms.Label lblLstObjet;
                private System.Windows.Forms.Button btnDelete;
                private System.Windows.Forms.TextBox txtMsgInfo;
                private System.Windows.Forms.Button btnAdd;
                private System.Windows.Forms.Button btnCancel;
                private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
                private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
                private System.Windows.Forms.Panel pnlCreateObject;



        }
}