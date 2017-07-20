namespace Bodget.UserCtrl
{
        partial class ucOperationContainerTitleBar
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
                        this.lblMt = new System.Windows.Forms.Label();
                        this.lblOperationCount = new System.Windows.Forms.Label();
                        this.lblTitle = new System.Windows.Forms.Label();
                        this.pbxDetailSwitchShowHide = new System.Windows.Forms.PictureBox();
                        this.pbxMove = new System.Windows.Forms.PictureBox();
                        this.tlp = new System.Windows.Forms.TableLayoutPanel();
                        ((System.ComponentModel.ISupportInitialize)(this.pbxDetailSwitchShowHide)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pbxMove)).BeginInit();
                        this.tlp.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // lblMt
                        // 
                        this.lblMt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblMt.Location = new System.Drawing.Point(240, 0);
                        this.lblMt.Name = "lblMt";
                        this.lblMt.Size = new System.Drawing.Size(60, 15);
                        this.lblMt.TabIndex = 5;
                        this.lblMt.Text = "0";
                        this.lblMt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // lblOperationCount
                        // 
                        this.lblOperationCount.Location = new System.Drawing.Point(18, 0);
                        this.lblOperationCount.Name = "lblOperationCount";
                        this.lblOperationCount.Size = new System.Drawing.Size(50, 15);
                        this.lblOperationCount.TabIndex = 4;
                        this.lblOperationCount.Text = "0";
                        this.lblOperationCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblTitle
                        // 
                        this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lblTitle.Location = new System.Drawing.Point(114, 0);
                        this.lblTitle.Name = "lblTitle";
                        this.lblTitle.Size = new System.Drawing.Size(90, 15);
                        this.lblTitle.TabIndex = 3;
                        this.lblTitle.Text = "TITLE";
                        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // pbxDetailSwitchShowHide
                        // 
                        this.pbxDetailSwitchShowHide.Image = global::Bodget.Properties.Resources.grp_detail_show_17x9;
                        this.pbxDetailSwitchShowHide.InitialImage = null;
                        this.pbxDetailSwitchShowHide.Location = new System.Drawing.Point(306, 3);
                        this.pbxDetailSwitchShowHide.Name = "pbxDetailSwitchShowHide";
                        this.pbxDetailSwitchShowHide.Size = new System.Drawing.Size(14, 15);
                        this.pbxDetailSwitchShowHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pbxDetailSwitchShowHide.TabIndex = 8;
                        this.pbxDetailSwitchShowHide.TabStop = false;
                        this.pbxDetailSwitchShowHide.Click += new System.EventHandler(this.pbxDetailSwitchShowHide_Click);
                        // 
                        // pbxMove
                        // 
                        this.pbxMove.Image = global::Bodget.Properties.Resources.wnd_move_11x11;
                        this.pbxMove.InitialImage = null;
                        this.pbxMove.Location = new System.Drawing.Point(3, 3);
                        this.pbxMove.Name = "pbxMove";
                        this.pbxMove.Size = new System.Drawing.Size(9, 15);
                        this.pbxMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pbxMove.TabIndex = 7;
                        this.pbxMove.TabStop = false;
                        this.pbxMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxMove_MouseDown);
                        // 
                        // tlp
                        // 
                        this.tlp.ColumnCount = 5;
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
                        this.tlp.Controls.Add(this.pbxMove, 0, 0);
                        this.tlp.Controls.Add(this.lblOperationCount, 1, 0);
                        this.tlp.Controls.Add(this.pbxDetailSwitchShowHide, 4, 0);
                        this.tlp.Controls.Add(this.lblTitle, 2, 0);
                        this.tlp.Controls.Add(this.lblMt, 3, 0);
                        this.tlp.Location = new System.Drawing.Point(3, 3);
                        this.tlp.Name = "tlp";
                        this.tlp.RowCount = 1;
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tlp.Size = new System.Drawing.Size(323, 22);
                        this.tlp.TabIndex = 11;
                        // 
                        // ucOperationContainerTitleBar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.tlp);
                        this.Name = "ucOperationContainerTitleBar";
                        this.Size = new System.Drawing.Size(358, 30);
                        this.Load += new System.EventHandler(this.ucOperationContainerTitleBar_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pbxDetailSwitchShowHide)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pbxMove)).EndInit();
                        this.tlp.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label lblMt;
                private System.Windows.Forms.Label lblOperationCount;
                private System.Windows.Forms.Label lblTitle;
                private System.Windows.Forms.PictureBox pbxMove;
                private System.Windows.Forms.PictureBox pbxDetailSwitchShowHide;
                private System.Windows.Forms.TableLayoutPanel tlp;
        }
}
