namespace Bodget.Windows
{
        partial class FrmFind
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
                        this.txtValue = new System.Windows.Forms.TextBox();
                        this.lblValeurCherche = new System.Windows.Forms.Label();
                        this.btnCancel = new System.Windows.Forms.Button();
                        this.btnRechercher = new System.Windows.Forms.Button();
                        this.txtMsgInfo = new System.Windows.Forms.TextBox();
                        this.lblPropertyName = new System.Windows.Forms.Label();
                        this.cmbPropertyName = new System.Windows.Forms.ComboBox();
                        this.btnClear = new System.Windows.Forms.Button();
                        this.pnlResultat = new System.Windows.Forms.Panel();
                        this.pnlDateSelector = new System.Windows.Forms.Panel();
                        this.SuspendLayout();
                        // 
                        // lblCategDest
                        // 
                        this.lblCategDest.Location = new System.Drawing.Point(7, 94);
                        this.lblCategDest.Name = "lblCategDest";
                        this.lblCategDest.Size = new System.Drawing.Size(117, 23);
                        this.lblCategDest.TabIndex = 0;
                        this.lblCategDest.Text = "Dans la categorie :";
                        this.lblCategDest.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // cmbCategories
                        // 
                        this.cmbCategories.FormattingEnabled = true;
                        this.cmbCategories.Location = new System.Drawing.Point(117, 100);
                        this.cmbCategories.Name = "cmbCategories";
                        this.cmbCategories.Size = new System.Drawing.Size(193, 21);
                        this.cmbCategories.TabIndex = 2;
                        this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
                        // 
                        // txtValue
                        // 
                        this.txtValue.Location = new System.Drawing.Point(117, 47);
                        this.txtValue.Name = "txtValue";
                        this.txtValue.Size = new System.Drawing.Size(193, 20);
                        this.txtValue.TabIndex = 0;
                        // 
                        // lblValeurCherche
                        // 
                        this.lblValeurCherche.Location = new System.Drawing.Point(7, 41);
                        this.lblValeurCherche.Name = "lblValeurCherche";
                        this.lblValeurCherche.Size = new System.Drawing.Size(117, 23);
                        this.lblValeurCherche.TabIndex = 5;
                        this.lblValeurCherche.Text = "Valeur cherchée :";
                        this.lblValeurCherche.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // btnCancel
                        // 
                        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.btnCancel.Location = new System.Drawing.Point(239, 127);
                        this.btnCancel.Name = "btnCancel";
                        this.btnCancel.Size = new System.Drawing.Size(71, 26);
                        this.btnCancel.TabIndex = 5;
                        this.btnCancel.Text = "Annuler";
                        this.btnCancel.UseVisualStyleBackColor = true;
                        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                        // 
                        // btnRechercher
                        // 
                        this.btnRechercher.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.btnRechercher.Location = new System.Drawing.Point(162, 127);
                        this.btnRechercher.Name = "btnRechercher";
                        this.btnRechercher.Size = new System.Drawing.Size(71, 26);
                        this.btnRechercher.TabIndex = 3;
                        this.btnRechercher.Text = "Rechercher";
                        this.btnRechercher.UseVisualStyleBackColor = true;
                        this.btnRechercher.Click += new System.EventHandler(this.btnFind_Click);
                        // 
                        // txtMsgInfo
                        // 
                        this.txtMsgInfo.BackColor = System.Drawing.SystemColors.Menu;
                        this.txtMsgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.txtMsgInfo.Location = new System.Drawing.Point(0, 315);
                        this.txtMsgInfo.Name = "txtMsgInfo";
                        this.txtMsgInfo.Size = new System.Drawing.Size(320, 20);
                        this.txtMsgInfo.TabIndex = 8;
                        // 
                        // lblPropertyName
                        // 
                        this.lblPropertyName.Location = new System.Drawing.Point(7, 67);
                        this.lblPropertyName.Name = "lblPropertyName";
                        this.lblPropertyName.Size = new System.Drawing.Size(117, 23);
                        this.lblPropertyName.TabIndex = 9;
                        this.lblPropertyName.Text = "Dans la colonne :";
                        this.lblPropertyName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        // 
                        // cmbPropertyName
                        // 
                        this.cmbPropertyName.FormattingEnabled = true;
                        this.cmbPropertyName.Location = new System.Drawing.Point(117, 73);
                        this.cmbPropertyName.Name = "cmbPropertyName";
                        this.cmbPropertyName.Size = new System.Drawing.Size(193, 21);
                        this.cmbPropertyName.TabIndex = 1;
                        this.cmbPropertyName.SelectedIndexChanged += new System.EventHandler(this.cmbPropertyName_SelectedIndexChanged);
                        // 
                        // btnClear
                        // 
                        this.btnClear.Location = new System.Drawing.Point(7, 127);
                        this.btnClear.Name = "btnClear";
                        this.btnClear.Size = new System.Drawing.Size(71, 26);
                        this.btnClear.TabIndex = 4;
                        this.btnClear.Text = "Nouvelle";
                        this.btnClear.UseVisualStyleBackColor = true;
                        // 
                        // pnlResultat
                        // 
                        this.pnlResultat.Location = new System.Drawing.Point(7, 159);
                        this.pnlResultat.Name = "pnlResultat";
                        this.pnlResultat.Size = new System.Drawing.Size(303, 150);
                        this.pnlResultat.TabIndex = 11;
                        // 
                        // pnlDateSelector
                        // 
                        this.pnlDateSelector.Location = new System.Drawing.Point(7, 9);
                        this.pnlDateSelector.Name = "pnlDateSelector";
                        this.pnlDateSelector.Size = new System.Drawing.Size(303, 29);
                        this.pnlDateSelector.TabIndex = 12;
                        // 
                        // FrmFind
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(320, 335);
                        this.Controls.Add(this.pnlDateSelector);
                        this.Controls.Add(this.pnlResultat);
                        this.Controls.Add(this.btnClear);
                        this.Controls.Add(this.cmbPropertyName);
                        this.Controls.Add(this.txtMsgInfo);
                        this.Controls.Add(this.btnRechercher);
                        this.Controls.Add(this.btnCancel);
                        this.Controls.Add(this.txtValue);
                        this.Controls.Add(this.cmbCategories);
                        this.Controls.Add(this.lblPropertyName);
                        this.Controls.Add(this.lblValeurCherche);
                        this.Controls.Add(this.lblCategDest);
                        this.Name = "FrmFind";
                        this.Text = "FrmCategorizationAuto";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label lblCategDest;
                private System.Windows.Forms.ComboBox cmbCategories;
                private System.Windows.Forms.TextBox txtValue;
                private System.Windows.Forms.Label lblValeurCherche;
                private System.Windows.Forms.Button btnCancel;
                private System.Windows.Forms.Button btnRechercher;
                private System.Windows.Forms.TextBox txtMsgInfo;
                private System.Windows.Forms.Label lblPropertyName;
                private System.Windows.Forms.ComboBox cmbPropertyName;
                private System.Windows.Forms.Button btnClear;
                private System.Windows.Forms.Panel pnlResultat;
                private System.Windows.Forms.Panel pnlDateSelector;
        }
}