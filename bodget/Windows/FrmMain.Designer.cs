namespace Bodget.Windows
{
        partial class FrmMain
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
                        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                        this.tsmFichier = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmRechercher = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmImport = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmImportOperation = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmImportDataFiles = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmData = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmBanque = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmCompte = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmBeneficiare = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmCategories = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmCategotyCRUD = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmCategoryRules = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmAppliquerLesRegles = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmiCheques = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmiPersonnes = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmiRemboursements = new System.Windows.Forms.ToolStripMenuItem();
                        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmOptions = new System.Windows.Forms.ToolStripMenuItem();
                        this.tsmAffichages = new System.Windows.Forms.ToolStripMenuItem();
                        this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
                        this.ucCategoryContainer = new Bodget.UserCtrl.ucCategoryContainer();
                        this.pnlMenu = new System.Windows.Forms.Panel();
                        this.menuStrip1.SuspendLayout();
                        this.toolStripContainer2.ContentPanel.SuspendLayout();
                        this.toolStripContainer2.SuspendLayout();
                        this.pnlMenu.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // menuStrip1
                        // 
                        this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFichier,
            this.tsmData,
            this.toolStripMenuItem1,
            this.tsmOptions});
                        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                        this.menuStrip1.Name = "menuStrip1";
                        this.menuStrip1.Size = new System.Drawing.Size(784, 25);
                        this.menuStrip1.TabIndex = 0;
                        this.menuStrip1.Text = "menuStrip1";
                        // 
                        // tsmFichier
                        // 
                        this.tsmFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPrint,
            this.tsmRechercher,
            this.tsmImport,
            this.tsmExport});
                        this.tsmFichier.Name = "tsmFichier";
                        this.tsmFichier.Size = new System.Drawing.Size(54, 21);
                        this.tsmFichier.Text = "&Fichier";
                        // 
                        // tsmPrint
                        // 
                        this.tsmPrint.Name = "tsmPrint";
                        this.tsmPrint.Size = new System.Drawing.Size(179, 22);
                        this.tsmPrint.Text = "Im&primer";
                        this.tsmPrint.Click += new System.EventHandler(this.tsmPrint_Click);
                        // 
                        // tsmRechercher
                        // 
                        this.tsmRechercher.Name = "tsmRechercher";
                        this.tsmRechercher.Size = new System.Drawing.Size(179, 22);
                        this.tsmRechercher.Text = "Rechercher";
                        this.tsmRechercher.Click += new System.EventHandler(this.tsmRechercher_Click);
                        // 
                        // tsmImport
                        // 
                        this.tsmImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImportOperation,
            this.tsmImportDataFiles});
                        this.tsmImport.Name = "tsmImport";
                        this.tsmImport.Size = new System.Drawing.Size(179, 22);
                        this.tsmImport.Text = "&Importer";
                        // 
                        // tsmImportOperation
                        // 
                        this.tsmImportOperation.Name = "tsmImportOperation";
                        this.tsmImportOperation.Size = new System.Drawing.Size(223, 22);
                        this.tsmImportOperation.Text = "Liste d\'opérations banquaire";
                        this.tsmImportOperation.Click += new System.EventHandler(this.tsmImportOperation_Click);
                        // 
                        // tsmImportDataFiles
                        // 
                        this.tsmImportDataFiles.Name = "tsmImportDataFiles";
                        this.tsmImportDataFiles.Size = new System.Drawing.Size(223, 22);
                        this.tsmImportDataFiles.Text = " Fichiers de données";
                        this.tsmImportDataFiles.Click += new System.EventHandler(this.tsmImportDataFiles_Click);
                        // 
                        // tsmExport
                        // 
                        this.tsmExport.Name = "tsmExport";
                        this.tsmExport.Size = new System.Drawing.Size(179, 22);
                        this.tsmExport.Text = "Exporter des fichiers";
                        this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
                        // 
                        // tsmData
                        // 
                        this.tsmData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBanque,
            this.tsmCompte,
            this.tsmBeneficiare,
            this.tsmCategories,
            this.tsmiCheques,
            this.tsmiPersonnes,
            this.tsmiRemboursements});
                        this.tsmData.Name = "tsmData";
                        this.tsmData.Size = new System.Drawing.Size(65, 21);
                        this.tsmData.Text = "Données";
                        // 
                        // tsmBanque
                        // 
                        this.tsmBanque.Name = "tsmBanque";
                        this.tsmBanque.Size = new System.Drawing.Size(167, 22);
                        this.tsmBanque.Text = "Banque";
                        this.tsmBanque.Click += new System.EventHandler(this.tsmBanque_Click);
                        // 
                        // tsmCompte
                        // 
                        this.tsmCompte.Name = "tsmCompte";
                        this.tsmCompte.Size = new System.Drawing.Size(167, 22);
                        this.tsmCompte.Text = "Compte";
                        this.tsmCompte.Click += new System.EventHandler(this.tsmCompte_Click);
                        // 
                        // tsmBeneficiare
                        // 
                        this.tsmBeneficiare.Name = "tsmBeneficiare";
                        this.tsmBeneficiare.Size = new System.Drawing.Size(167, 22);
                        this.tsmBeneficiare.Text = "Beneficiare";
                        this.tsmBeneficiare.Click += new System.EventHandler(this.tsmBeneficiare_Click);
                        // 
                        // tsmCategories
                        // 
                        this.tsmCategories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCategotyCRUD,
            this.tsmCategoryRules,
            this.tsmAppliquerLesRegles});
                        this.tsmCategories.Name = "tsmCategories";
                        this.tsmCategories.Size = new System.Drawing.Size(167, 22);
                        this.tsmCategories.Text = "Categories";
                        // 
                        // tsmCategotyCRUD
                        // 
                        this.tsmCategotyCRUD.Name = "tsmCategotyCRUD";
                        this.tsmCategotyCRUD.Size = new System.Drawing.Size(177, 22);
                        this.tsmCategotyCRUD.Text = "Gérer";
                        this.tsmCategotyCRUD.Click += new System.EventHandler(this.tsmCategotyCRUD_Click);
                        // 
                        // tsmCategoryRules
                        // 
                        this.tsmCategoryRules.Name = "tsmCategoryRules";
                        this.tsmCategoryRules.Size = new System.Drawing.Size(177, 22);
                        this.tsmCategoryRules.Text = "Règles";
                        this.tsmCategoryRules.Click += new System.EventHandler(this.tsmCategoryRules_Click);
                        // 
                        // tsmAppliquerLesRegles
                        // 
                        this.tsmAppliquerLesRegles.Name = "tsmAppliquerLesRegles";
                        this.tsmAppliquerLesRegles.Size = new System.Drawing.Size(177, 22);
                        this.tsmAppliquerLesRegles.Text = "Appliquer les règles";
                        this.tsmAppliquerLesRegles.Click += new System.EventHandler(this.tsmAppliquerLesRegles_Click);
                        // 
                        // tsmiCheques
                        // 
                        this.tsmiCheques.Name = "tsmiCheques";
                        this.tsmiCheques.Size = new System.Drawing.Size(167, 22);
                        this.tsmiCheques.Text = "Chéques";
                        this.tsmiCheques.Click += new System.EventHandler(this.tsmiCheques_Click);
                        // 
                        // tsmiPersonnes
                        // 
                        this.tsmiPersonnes.Name = "tsmiPersonnes";
                        this.tsmiPersonnes.Size = new System.Drawing.Size(167, 22);
                        this.tsmiPersonnes.Text = "Personnes";
                        this.tsmiPersonnes.Click += new System.EventHandler(this.tsmiPersonnes_Click);
                        // 
                        // tsmiRemboursements
                        // 
                        this.tsmiRemboursements.Name = "tsmiRemboursements";
                        this.tsmiRemboursements.Size = new System.Drawing.Size(167, 22);
                        this.tsmiRemboursements.Text = "Remboursements";
                        this.tsmiRemboursements.Click += new System.EventHandler(this.tsmiRemboursements_Click);
                        // 
                        // toolStripMenuItem1
                        // 
                        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                        this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
                        // 
                        // tsmOptions
                        // 
                        this.tsmOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAffichages});
                        this.tsmOptions.Name = "tsmOptions";
                        this.tsmOptions.Size = new System.Drawing.Size(61, 21);
                        this.tsmOptions.Text = "Options";
                        // 
                        // tsmAffichages
                        // 
                        this.tsmAffichages.Name = "tsmAffichages";
                        this.tsmAffichages.Size = new System.Drawing.Size(130, 22);
                        this.tsmAffichages.Text = "Affichages";
                        this.tsmAffichages.Click += new System.EventHandler(this.tsmAffichages_Click);
                        // 
                        // toolStripContainer2
                        // 
                        this.toolStripContainer2.BottomToolStripPanelVisible = false;
                        // 
                        // toolStripContainer2.ContentPanel
                        // 
                        this.toolStripContainer2.ContentPanel.AutoScroll = true;
                        this.toolStripContainer2.ContentPanel.Controls.Add(this.ucCategoryContainer);
                        this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(784, 712);
                        this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.toolStripContainer2.LeftToolStripPanelVisible = false;
                        this.toolStripContainer2.Location = new System.Drawing.Point(0, 25);
                        this.toolStripContainer2.Name = "toolStripContainer2";
                        this.toolStripContainer2.RightToolStripPanelVisible = false;
                        this.toolStripContainer2.Size = new System.Drawing.Size(784, 737);
                        this.toolStripContainer2.TabIndex = 4;
                        this.toolStripContainer2.Text = "toolStripContainer2";
                        // 
                        // ucCategoryContainer
                        // 
                        this.ucCategoryContainer.BackColor = System.Drawing.SystemColors.ControlLight;
                        this.ucCategoryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucCategoryContainer.FilterByCompte = null;
                        this.ucCategoryContainer.FilterByDateInfo = null;
                        this.ucCategoryContainer.Location = new System.Drawing.Point(0, 0);
                        this.ucCategoryContainer.Name = "ucCategoryContainer";
                        this.ucCategoryContainer.SearchCriteria = null;
                        this.ucCategoryContainer.Size = new System.Drawing.Size(784, 712);
                        this.ucCategoryContainer.TabIndex = 3;
                        // 
                        // pnlMenu
                        // 
                        this.pnlMenu.Controls.Add(this.menuStrip1);
                        this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
                        this.pnlMenu.Location = new System.Drawing.Point(0, 0);
                        this.pnlMenu.Name = "pnlMenu";
                        this.pnlMenu.Size = new System.Drawing.Size(784, 25);
                        this.pnlMenu.TabIndex = 4;
                        // 
                        // FrmMain
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(784, 762);
                        this.Controls.Add(this.toolStripContainer2);
                        this.Controls.Add(this.pnlMenu);
                        this.MainMenuStrip = this.menuStrip1;
                        this.Name = "FrmMain";
                        this.menuStrip1.ResumeLayout(false);
                        this.menuStrip1.PerformLayout();
                        this.toolStripContainer2.ContentPanel.ResumeLayout(false);
                        this.toolStripContainer2.ResumeLayout(false);
                        this.toolStripContainer2.PerformLayout();
                        this.pnlMenu.ResumeLayout(false);
                        this.pnlMenu.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.MenuStrip menuStrip1;
                private System.Windows.Forms.ToolStripMenuItem tsmFichier;
                private System.Windows.Forms.ToolStripMenuItem tsmImport;
                private System.Windows.Forms.ToolStripMenuItem tsmData;
                private System.Windows.Forms.ToolStripMenuItem tsmBanque;
                private System.Windows.Forms.ToolStripMenuItem tsmCompte;
                private UserCtrl.ucCategoryContainer ucCategoryContainer;
                private System.Windows.Forms.ToolStripContainer toolStripContainer2;
                private System.Windows.Forms.Panel pnlMenu;
                private System.Windows.Forms.ToolStripMenuItem tsmPrint;
                private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
                private System.Windows.Forms.ToolStripMenuItem tsmOptions;
                private System.Windows.Forms.ToolStripMenuItem tsmAffichages;
                private System.Windows.Forms.ToolStripMenuItem tsmRechercher;
                private System.Windows.Forms.ToolStripMenuItem tsmBeneficiare;
                private System.Windows.Forms.ToolStripMenuItem tsmCategories;
                private System.Windows.Forms.ToolStripMenuItem tsmCategotyCRUD;
                private System.Windows.Forms.ToolStripMenuItem tsmCategoryRules;
                private System.Windows.Forms.ToolStripMenuItem tsmExport;
                private System.Windows.Forms.ToolStripMenuItem tsmImportOperation;
                private System.Windows.Forms.ToolStripMenuItem tsmImportDataFiles;
                private System.Windows.Forms.ToolStripMenuItem tsmiCheques;
                private System.Windows.Forms.ToolStripMenuItem tsmAppliquerLesRegles;
                private System.Windows.Forms.ToolStripMenuItem tsmiPersonnes;
                private System.Windows.Forms.ToolStripMenuItem tsmiRemboursements;
        }
}

