namespace Bodget.UserCtrl
{
        partial class ucOperationContainer
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
                        this.ucTitleBar = new Bodget.UserCtrl.ucOperationContainerTitleBar();
                        this.pnl = new System.Windows.Forms.Panel();
                        this.tlp.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // tlp
                        // 
                        this.tlp.ColumnCount = 1;
                        this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tlp.Controls.Add(this.ucTitleBar, 0, 0);
                        this.tlp.Controls.Add(this.pnl, 0, 1);
                        this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tlp.Location = new System.Drawing.Point(0, 0);
                        this.tlp.Name = "tlp";
                        this.tlp.RowCount = 2;
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tlp.Size = new System.Drawing.Size(391, 100);
                        this.tlp.TabIndex = 1;
                        this.tlp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlp_MouseDown);
                        this.tlp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tlp_MouseMove);
                        this.tlp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlp_MouseUp);
                        // 
                        // ucTitleBar
                        // 
                        this.ucTitleBar.DetailVisible = false;
                        this.ucTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucTitleBar.Location = new System.Drawing.Point(3, 3);
                        this.ucTitleBar.Mt = new decimal(new int[] {
            0,
            0,
            0,
            0});
                        this.ucTitleBar.Name = "ucTitleBar";
                        this.ucTitleBar.OperationCount = 0;
                        this.ucTitleBar.Size = new System.Drawing.Size(385, 14);
                        this.ucTitleBar.TabIndex = 0;
                        this.ucTitleBar.DetailVisibilityChange += new System.EventHandler(this.ucTitleBar_DetailVisibilityChange);
                        this.ucTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTitleBar_MouseDown);
                        // 
                        // pnl
                        // 
                        this.pnl.Location = new System.Drawing.Point(3, 23);
                        this.pnl.Name = "pnl";
                        this.pnl.Size = new System.Drawing.Size(240, 48);
                        this.pnl.TabIndex = 1;
                        this.pnl.SizeChanged += new System.EventHandler(this.pnl_SizeChanged);
                        this.pnl.Resize += new System.EventHandler(this.pnl_Resize);
                        // 
                        // ucOperationContainer
                        // 
                        this.AllowDrop = true;
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.Controls.Add(this.tlp);
                        this.Name = "ucOperationContainer";
                        this.Size = new System.Drawing.Size(391, 100);
                        this.Load += new System.EventHandler(this.ucOperationContainer_Load);
                        this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ucOperationContainer_DragDrop);
                        this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ucOperationContainer_DragEnter);
                        this.tlp.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tlp;
                private ucOperationContainerTitleBar ucTitleBar;
                private System.Windows.Forms.Panel pnl;


        }
}
