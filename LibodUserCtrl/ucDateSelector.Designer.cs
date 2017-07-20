namespace LibodUserCtrl
{
        partial class ucDateSelector
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
                        this.cmbYear = new System.Windows.Forms.ComboBox();
                        this.cmbMonth = new System.Windows.Forms.ComboBox();
                        this.lblYear = new System.Windows.Forms.Label();
                        this.lblMonth = new System.Windows.Forms.Label();
                        this.cmbDay = new System.Windows.Forms.ComboBox();
                        this.lblDay = new System.Windows.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // cmbYear
                        // 
                        this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cmbYear.FormattingEnabled = true;
                        this.cmbYear.Location = new System.Drawing.Point(53, 0);
                        this.cmbYear.Name = "cmbYear";
                        this.cmbYear.Size = new System.Drawing.Size(50, 21);
                        this.cmbYear.TabIndex = 0;
                        this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
                        // 
                        // cmbMonth
                        // 
                        this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cmbMonth.FormattingEnabled = true;
                        this.cmbMonth.Location = new System.Drawing.Point(146, 0);
                        this.cmbMonth.Name = "cmbMonth";
                        this.cmbMonth.Size = new System.Drawing.Size(76, 21);
                        this.cmbMonth.TabIndex = 1;
                        this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
                        // 
                        // lblYear
                        // 
                        this.lblYear.Location = new System.Drawing.Point(3, 3);
                        this.lblYear.Name = "lblYear";
                        this.lblYear.Size = new System.Drawing.Size(47, 18);
                        this.lblYear.TabIndex = 2;
                        this.lblYear.Text = "Year :";
                        // 
                        // lblMonth
                        // 
                        this.lblMonth.Location = new System.Drawing.Point(105, 3);
                        this.lblMonth.Name = "lblMonth";
                        this.lblMonth.Size = new System.Drawing.Size(51, 18);
                        this.lblMonth.TabIndex = 3;
                        this.lblMonth.Text = "Month :";
                        // 
                        // cmbDay
                        // 
                        this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cmbDay.FormattingEnabled = true;
                        this.cmbDay.Location = new System.Drawing.Point(258, 0);
                        this.cmbDay.Name = "cmbDay";
                        this.cmbDay.Size = new System.Drawing.Size(40, 21);
                        this.cmbDay.TabIndex = 4;
                        this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
                        // 
                        // lblDay
                        // 
                        this.lblDay.Location = new System.Drawing.Point(224, 3);
                        this.lblDay.Name = "lblDay";
                        this.lblDay.Size = new System.Drawing.Size(37, 18);
                        this.lblDay.TabIndex = 5;
                        this.lblDay.Text = "Day :";
                        // 
                        // ucDateSelector
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.cmbMonth);
                        this.Controls.Add(this.cmbDay);
                        this.Controls.Add(this.lblDay);
                        this.Controls.Add(this.lblMonth);
                        this.Controls.Add(this.lblYear);
                        this.Controls.Add(this.cmbYear);
                        this.Name = "ucDateSelector";
                        this.Size = new System.Drawing.Size(298, 21);
                        this.Load += new System.EventHandler(this.ucDateSelector_Load);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.ComboBox cmbYear;
                private System.Windows.Forms.ComboBox cmbMonth;
                private System.Windows.Forms.Label lblYear;
                private System.Windows.Forms.Label lblMonth;
                private System.Windows.Forms.ComboBox cmbDay;
                private System.Windows.Forms.Label lblDay;
        }
}
