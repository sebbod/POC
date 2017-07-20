namespace LibodUserCtrl
{
        partial class ucSelectListInCombo<T>
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
                        this.components = new System.ComponentModel.Container();
                        this.lstResult = new System.Windows.Forms.ListBox();
                        this.cmbSelector = new System.Windows.Forms.ComboBox();
                        this.lblTitle = new System.Windows.Forms.Label();
                        this.btnAdd = new System.Windows.Forms.Button();
                        this.btnDel = new System.Windows.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // lstResult
                        // 
                        this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lstResult.FormattingEnabled = true;
                        this.lstResult.Location = new System.Drawing.Point(1, 23);
                        this.lstResult.Name = "lstResult";
                        this.lstResult.Size = new System.Drawing.Size(245, 121);
                        this.lstResult.TabIndex = 1;
                        // 
                        // cmbSelector
                        // 
                        this.cmbSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.cmbSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cmbSelector.FormattingEnabled = true;
                        this.cmbSelector.Location = new System.Drawing.Point(1, 151);
                        this.cmbSelector.Name = "cmbSelector";
                        this.cmbSelector.Size = new System.Drawing.Size(213, 21);
                        this.cmbSelector.TabIndex = 2;
                        // 
                        // lblTitle
                        // 
                        this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblTitle.Location = new System.Drawing.Point(4, 1);
                        this.lblTitle.Name = "lblTitle";
                        this.lblTitle.Size = new System.Drawing.Size(209, 20);
                        this.lblTitle.TabIndex = 3;
                        this.lblTitle.Text = "label1";
                        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // btnAdd
                        // 
                        this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.btnAdd.Location = new System.Drawing.Point(216, 151);
                        this.btnAdd.Name = "btnAdd";
                        this.btnAdd.Size = new System.Drawing.Size(30, 21);
                        this.btnAdd.TabIndex = 4;
                        this.btnAdd.Text = "+";
                        this.btnAdd.UseVisualStyleBackColor = true;
                        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                        // 
                        // btnDel
                        // 
                        this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnDel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.btnDel.Location = new System.Drawing.Point(216, 0);
                        this.btnDel.Name = "btnDel";
                        this.btnDel.Size = new System.Drawing.Size(30, 21);
                        this.btnDel.TabIndex = 5;
                        this.btnDel.Text = "-";
                        this.btnDel.UseVisualStyleBackColor = true;
                        this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
                        // 
                        // ucSelectListInCombo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BackColor = System.Drawing.SystemColors.Control;
                        this.Controls.Add(this.btnDel);
                        this.Controls.Add(this.btnAdd);
                        this.Controls.Add(this.lblTitle);
                        this.Controls.Add(this.cmbSelector);
                        this.Controls.Add(this.lstResult);
                        this.MinimumSize = new System.Drawing.Size(73, 73);
                        this.Name = "ucSelectListInCombo";
                        this.Size = new System.Drawing.Size(247, 177);
                        this.ResumeLayout(false);

                }

                #endregion

                protected System.Windows.Forms.ListBox lstResult;
                protected System.Windows.Forms.ComboBox cmbSelector;
                private System.Windows.Forms.Label lblTitle;
                protected System.Windows.Forms.Button btnAdd;
                protected System.Windows.Forms.Button btnDel;
        }
}
