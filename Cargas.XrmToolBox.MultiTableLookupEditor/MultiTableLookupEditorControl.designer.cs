namespace Cargas.XrmToolBox.MultiTableLookupEditor
{
    partial class MultiTableLookupEditorControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbEntities = new System.Windows.Forms.ComboBox();
            this.lblNewAttributeName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSchemaName = new System.Windows.Forms.TextBox();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.clbEntities = new System.Windows.Forms.CheckedListBox();
            label1 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 13);
            label1.TabIndex = 6;
            label1.Text = "Source Entity:";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbLoadEntities});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1058, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbEntities
            // 
            this.cmbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEntities.DisplayMember = "DisplayName";
            this.cmbEntities.Enabled = false;
            this.cmbEntities.FormattingEnabled = true;
            this.cmbEntities.Location = new System.Drawing.Point(99, 19);
            this.cmbEntities.Name = "cmbEntities";
            this.cmbEntities.Size = new System.Drawing.Size(935, 21);
            this.cmbEntities.TabIndex = 7;
            this.cmbEntities.ValueMember = "LogicalName";
            this.cmbEntities.SelectedIndexChanged += new System.EventHandler(this.cmbEntities_SelectedIndexChanged);
            this.cmbEntities.Leave += new System.EventHandler(this.cmbEntities_Leave);
            // 
            // lblNewAttributeName
            // 
            this.lblNewAttributeName.AutoSize = true;
            this.lblNewAttributeName.Location = new System.Drawing.Point(8, 49);
            this.lblNewAttributeName.Name = "lblNewAttributeName";
            this.lblNewAttributeName.Size = new System.Drawing.Size(75, 13);
            this.lblNewAttributeName.TabIndex = 11;
            this.lblNewAttributeName.Text = "Display Name:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(99, 46);
            this.txtDisplayName.MaxLength = 100;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(935, 20);
            this.txtDisplayName.TabIndex = 12;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(21, 587);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(463, 23);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Create Attribute";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbEntities);
            this.groupBox1.Location = new System.Drawing.Point(10, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 405);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lookup Entities";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.cmbEntities);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSchemaName);
            this.groupBox2.Controls.Add(this.txtDisplayName);
            this.groupBox2.Controls.Add(this.lblNewAttributeName);
            this.groupBox2.Location = new System.Drawing.Point(10, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1040, 133);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Attribute Metadata";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(99, 98);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(935, 20);
            this.txtDescription.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Schema Name:";
            // 
            // txtSchemaName
            // 
            this.txtSchemaName.Location = new System.Drawing.Point(99, 72);
            this.txtSchemaName.MaxLength = 100;
            this.txtSchemaName.Name = "txtSchemaName";
            this.txtSchemaName.Size = new System.Drawing.Size(935, 20);
            this.txtSchemaName.TabIndex = 14;
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(78, 22);
            this.tsbLoadEntities.Text = "Load Entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.tsbLoadEntities_Click);
            // 
            // clbEntities
            // 
            this.clbEntities.Enabled = false;
            this.clbEntities.FormattingEnabled = true;
            this.clbEntities.Location = new System.Drawing.Point(11, 19);
            this.clbEntities.Name = "clbEntities";
            this.clbEntities.Size = new System.Drawing.Size(1023, 379);
            this.clbEntities.TabIndex = 22;
            // 
            // MultiTableLookupEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MultiTableLookupEditorControl";
            this.Size = new System.Drawing.Size(1058, 617);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ComboBox cmbEntities;
        private System.Windows.Forms.Label lblNewAttributeName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSchemaName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.CheckedListBox clbEntities;
    }
}
