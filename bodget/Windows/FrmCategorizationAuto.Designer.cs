namespace Bodget.Windows
{
        partial class FrmCategorizationAuto
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
                        this.lblCategDest = new System.Windows.Forms.Label();
                        this.cmbCategories = new System.Windows.Forms.ComboBox();
                        this.lblTexteExistantPourColonne = new System.Windows.Forms.Label();
                        this.txtContient = new System.Windows.Forms.TextBox();
                        this.lblNomContient = new System.Windows.Forms.Label();
                        this.btnCancel = new System.Windows.Forms.Button();
                        this.btnAdd = new System.Windows.Forms.Button();
                        this.txtMsgInfo = new System.Windows.Forms.TextBox();
                        this.lblPropertyName = new System.Windows.Forms.Label();
                        this.cmbPropertyName = new System.Windows.Forms.ComboBox();
                        this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                        this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.lstTextExistant = new System.Windows.Forms.ListBox();
                        this.lstRules = new System.Windows.Forms.ListBox();
                        this.lblRules = new System.Windows.Forms.Label();
                        this.btnDelete = new System.Windows.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // lblCategDest
                        // 
                        this.lblCategDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblCategDest.Location = new System.Drawing.Point(436, 84);
                        this.lblCategDest.Name = "lblCategDest";
                        this.lblCategDest.Size = new System.Drawing.Size(295, 23);
                        this.lblCategDest.TabIndex = 0;
                        this.lblCategDest.Text = "Alors, ajouter automatiquement l\'opération dans la categorie :";
                        this.lblCategDest.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // cmbCategories
                        // 
                        this.cmbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.cmbCategories.FormattingEnabled = true;
                        this.cmbCategories.Location = new System.Drawing.Point(436, 110);
                        this.cmbCategories.Name = "cmbCategories";
                        this.cmbCategories.Size = new System.Drawing.Size(295, 21);
                        this.cmbCategories.TabIndex = 1;
                        this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
                        // 
                        // lblTexteExistantPourColonne
                        // 
                        this.lblTexteExistantPourColonne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblTexteExistantPourColonne.Location = new System.Drawing.Point(748, 9);
                        this.lblTexteExistantPourColonne.Name = "lblTexteExistantPourColonne";
                        this.lblTexteExistantPourColonne.Size = new System.Drawing.Size(196, 23);
                        this.lblTexteExistantPourColonne.TabIndex = 2;
                        this.lblTexteExistantPourColonne.Text = "Texte existant pour cette colonne :";
                        this.lblTexteExistantPourColonne.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // txtContient
                        // 
                        this.txtContient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.txtContient.Location = new System.Drawing.Point(439, 61);
                        this.txtContient.Name = "txtContient";
                        this.txtContient.Size = new System.Drawing.Size(292, 20);
                        this.txtContient.TabIndex = 4;
                        // 
                        // lblNomContient
                        // 
                        this.lblNomContient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblNomContient.Location = new System.Drawing.Point(436, 35);
                        this.lblNomContient.Name = "lblNomContient";
                        this.lblNomContient.Size = new System.Drawing.Size(295, 23);
                        this.lblNomContient.TabIndex = 5;
                        this.lblNomContient.Text = "Contient le texte suivant :";
                        this.lblNomContient.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // btnCancel
                        // 
                        this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.btnCancel.Location = new System.Drawing.Point(660, 137);
                        this.btnCancel.Name = "btnCancel";
                        this.btnCancel.Size = new System.Drawing.Size(71, 26);
                        this.btnCancel.TabIndex = 6;
                        this.btnCancel.Text = "Annuler";
                        this.btnCancel.UseVisualStyleBackColor = true;
                        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                        // 
                        // btnAdd
                        // 
                        this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.btnAdd.Location = new System.Drawing.Point(583, 137);
                        this.btnAdd.Name = "btnAdd";
                        this.btnAdd.Size = new System.Drawing.Size(71, 26);
                        this.btnAdd.TabIndex = 7;
                        this.btnAdd.Text = "Ajouter";
                        this.btnAdd.UseVisualStyleBackColor = true;
                        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                        // 
                        // txtMsgInfo
                        // 
                        this.txtMsgInfo.BackColor = System.Drawing.SystemColors.Menu;
                        this.txtMsgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.txtMsgInfo.Location = new System.Drawing.Point(0, 174);
                        this.txtMsgInfo.Name = "txtMsgInfo";
                        this.txtMsgInfo.Size = new System.Drawing.Size(1008, 20);
                        this.txtMsgInfo.TabIndex = 8;
                        // 
                        // lblPropertyName
                        // 
                        this.lblPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblPropertyName.Location = new System.Drawing.Point(436, 5);
                        this.lblPropertyName.Name = "lblPropertyName";
                        this.lblPropertyName.Size = new System.Drawing.Size(171, 23);
                        this.lblPropertyName.TabIndex = 9;
                        this.lblPropertyName.Text = "Si dans une opération la colonne :";
                        this.lblPropertyName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // cmbPropertyName
                        // 
                        this.cmbPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.cmbPropertyName.FormattingEnabled = true;
                        this.cmbPropertyName.Location = new System.Drawing.Point(608, 11);
                        this.cmbPropertyName.Name = "cmbPropertyName";
                        this.cmbPropertyName.Size = new System.Drawing.Size(123, 21);
                        this.cmbPropertyName.TabIndex = 10;
                        this.cmbPropertyName.SelectedIndexChanged += new System.EventHandler(this.cmbPropertyName_SelectedIndexChanged);
                        // 
                        // shapeContainer1
                        // 
                        this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
                        this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                        this.shapeContainer1.Name = "shapeContainer1";
                        this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
                        this.shapeContainer1.Size = new System.Drawing.Size(1008, 194);
                        this.shapeContainer1.TabIndex = 11;
                        this.shapeContainer1.TabStop = false;
                        // 
                        // lineShape2
                        // 
                        this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lineShape2.Name = "lineShape2";
                        this.lineShape2.X1 = 740;
                        this.lineShape2.X2 = 740;
                        this.lineShape2.Y1 = 0;
                        this.lineShape2.Y2 = 175;
                        // 
                        // lineShape1
                        // 
                        this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lineShape1.Name = "lineShape1";
                        this.lineShape1.X1 = 427;
                        this.lineShape1.X2 = 427;
                        this.lineShape1.Y1 = 0;
                        this.lineShape1.Y2 = 175;
                        // 
                        // lstTextExistant
                        // 
                        this.lstTextExistant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lstTextExistant.FormattingEnabled = true;
                        this.lstTextExistant.Location = new System.Drawing.Point(751, 35);
                        this.lstTextExistant.Name = "lstTextExistant";
                        this.lstTextExistant.Size = new System.Drawing.Size(245, 134);
                        this.lstTextExistant.TabIndex = 12;
                        this.lstTextExistant.Click += new System.EventHandler(this.lstTextExistant_Click);
                        // 
                        // lstRules
                        // 
                        this.lstRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lstRules.FormattingEnabled = true;
                        this.lstRules.Location = new System.Drawing.Point(12, 35);
                        this.lstRules.Name = "lstRules";
                        this.lstRules.Size = new System.Drawing.Size(405, 134);
                        this.lstRules.TabIndex = 14;
                        this.lstRules.SelectedIndexChanged += new System.EventHandler(this.lstRules_SelectedIndexChanged);
                        // 
                        // lblRules
                        // 
                        this.lblRules.Location = new System.Drawing.Point(12, 9);
                        this.lblRules.Name = "lblRules";
                        this.lblRules.Size = new System.Drawing.Size(196, 23);
                        this.lblRules.TabIndex = 13;
                        this.lblRules.Text = "Liste des règles existantes :";
                        this.lblRules.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // btnDelete
                        // 
                        this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnDelete.Location = new System.Drawing.Point(436, 137);
                        this.btnDelete.Name = "btnDelete";
                        this.btnDelete.Size = new System.Drawing.Size(71, 26);
                        this.btnDelete.TabIndex = 15;
                        this.btnDelete.Text = "Supprimer";
                        this.btnDelete.UseVisualStyleBackColor = true;
                        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                        // 
                        // FrmCategorizationAuto
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1008, 194);
                        this.Controls.Add(this.btnDelete);
                        this.Controls.Add(this.lstRules);
                        this.Controls.Add(this.lblRules);
                        this.Controls.Add(this.lstTextExistant);
                        this.Controls.Add(this.cmbPropertyName);
                        this.Controls.Add(this.lblPropertyName);
                        this.Controls.Add(this.txtMsgInfo);
                        this.Controls.Add(this.btnAdd);
                        this.Controls.Add(this.btnCancel);
                        this.Controls.Add(this.lblNomContient);
                        this.Controls.Add(this.txtContient);
                        this.Controls.Add(this.lblTexteExistantPourColonne);
                        this.Controls.Add(this.cmbCategories);
                        this.Controls.Add(this.lblCategDest);
                        this.Controls.Add(this.shapeContainer1);
                        this.Name = "FrmCategorizationAuto";
                        this.Text = "FrmCategorizationAuto";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label lblCategDest;
                private System.Windows.Forms.ComboBox cmbCategories;
                private System.Windows.Forms.Label lblTexteExistantPourColonne;
                private System.Windows.Forms.TextBox txtContient;
                private System.Windows.Forms.Label lblNomContient;
                private System.Windows.Forms.Button btnCancel;
                private System.Windows.Forms.Button btnAdd;
                private System.Windows.Forms.TextBox txtMsgInfo;
                private System.Windows.Forms.Label lblPropertyName;
                private System.Windows.Forms.ComboBox cmbPropertyName;
                private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
                private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
                private System.Windows.Forms.ListBox lstTextExistant;
                private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
                private System.Windows.Forms.ListBox lstRules;
                private System.Windows.Forms.Label lblRules;
                private System.Windows.Forms.Button btnDelete;
        }
}