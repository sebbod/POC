﻿namespace LibodUserCtrl.Extension.WinMenu
{
        partial class ToolStripDropDownContainer
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
                        if (disposing)
                        {
                                if (components != null)
                                {
                                        components.Dispose ();
                                }
                                if (_toolStripItemConrolContainer != null)
                                {
                                        System.Windows.Forms.Control _content = _toolStripItemConrolContainer;
                                        _toolStripItemConrolContainer = null;
                                        _content.Dispose ();
                                }
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
                        components = new System.ComponentModel.Container ();
                }

                #endregion
        }
}
