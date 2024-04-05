
namespace Data_CMM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BrandNewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UseCaseToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.BarriersComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBoxDimSub = new System.Windows.Forms.GroupBox();
            this.groupBoxMaturity = new System.Windows.Forms.GroupBox();
            this.rdbUnknown = new System.Windows.Forms.RadioButton();
            this.rdb4 = new System.Windows.Forms.RadioButton();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.groupBoxChecklists = new System.Windows.Forms.GroupBox();
            this.textBoxChecklistItem = new System.Windows.Forms.TextBox();
            this.groupBoxResponseRate = new System.Windows.Forms.GroupBox();
            this.textBoxResponseRate = new System.Windows.Forms.TextBox();
            this.groupBoxBarriers = new System.Windows.Forms.GroupBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.dataGridViewBarriers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBoxDimSub.SuspendLayout();
            this.groupBoxMaturity.SuspendLayout();
            this.groupBoxChecklists.SuspendLayout();
            this.groupBoxResponseRate.SuspendLayout();
            this.groupBoxBarriers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarriers)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrandNewToolStripButton,
            this.OpenToolStripButton,
            this.SaveToolStripButton,
            this.UseCaseToolStripComboBox,
            this.BarriersComboBox,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(835, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BrandNewToolStripButton
            // 
            this.BrandNewToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            this.BrandNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BrandNewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("BrandNewToolStripButton.Image")));
            this.BrandNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BrandNewToolStripButton.Name = "BrandNewToolStripButton";
            this.BrandNewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.BrandNewToolStripButton.Text = "BrandNewToolStripButton";
            this.BrandNewToolStripButton.ToolTipText = "New File";
            this.BrandNewToolStripButton.Click += new System.EventHandler(this.BrandNewToolStripButton_Click);
            // 
            // OpenToolStripButton
            // 
            this.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripButton.Image")));
            this.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripButton.Name = "OpenToolStripButton";
            this.OpenToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.OpenToolStripButton.Text = "toolStripButton2";
            this.OpenToolStripButton.ToolTipText = "Open File";
            this.OpenToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripButton.Image")));
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStripButton.Text = "toolStripButton3";
            this.SaveToolStripButton.ToolTipText = "Save File";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // UseCaseToolStripComboBox
            // 
            this.UseCaseToolStripComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UseCaseToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UseCaseToolStripComboBox.DropDownWidth = 200;
            this.UseCaseToolStripComboBox.Items.AddRange(new object[] {
            "Generic Use Case",
            "Regional System Management",
            "Offline Analysis Support",
            "University TRC",
            "USDOT Single-Source Data",
            "USDOT Research Program"});
            this.UseCaseToolStripComboBox.Name = "UseCaseToolStripComboBox";
            this.UseCaseToolStripComboBox.Size = new System.Drawing.Size(200, 25);
            this.UseCaseToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.UseCaseToolStripComboBox_SelectedIndexChanged);
            // 
            // BarriersComboBox
            // 
            this.BarriersComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BarriersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BarriersComboBox.DropDownWidth = 100;
            this.BarriersComboBox.Items.AddRange(new object[] {
            "Notes",
            "Barriers"});
            this.BarriersComboBox.Name = "BarriersComboBox";
            this.BarriersComboBox.Size = new System.Drawing.Size(100, 25);
            this.BarriersComboBox.SelectedIndexChanged += new System.EventHandler(this.BarriersComboBox_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "About Data CMM";
            this.toolStripButton1.Click += new System.EventHandler(this.AboutToolStripButton);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(404, 260);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // groupBoxDimSub
            // 
            this.groupBoxDimSub.Controls.Add(this.treeView1);
            this.groupBoxDimSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDimSub.Location = new System.Drawing.Point(12, 31);
            this.groupBoxDimSub.Name = "groupBoxDimSub";
            this.groupBoxDimSub.Size = new System.Drawing.Size(416, 287);
            this.groupBoxDimSub.TabIndex = 90;
            this.groupBoxDimSub.TabStop = false;
            this.groupBoxDimSub.Text = "Dimensions and Subdimensions";
            // 
            // groupBoxMaturity
            // 
            this.groupBoxMaturity.Controls.Add(this.rdbUnknown);
            this.groupBoxMaturity.Controls.Add(this.rdb4);
            this.groupBoxMaturity.Controls.Add(this.rdb3);
            this.groupBoxMaturity.Controls.Add(this.rdb2);
            this.groupBoxMaturity.Controls.Add(this.rdb1);
            this.groupBoxMaturity.Enabled = false;
            this.groupBoxMaturity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMaturity.Location = new System.Drawing.Point(18, 318);
            this.groupBoxMaturity.Name = "groupBoxMaturity";
            this.groupBoxMaturity.Size = new System.Drawing.Size(410, 151);
            this.groupBoxMaturity.TabIndex = 91;
            this.groupBoxMaturity.TabStop = false;
            this.groupBoxMaturity.Text = "Maturity Levels";
            // 
            // rdbUnknown
            // 
            this.rdbUnknown.AutoSize = true;
            this.rdbUnknown.Location = new System.Drawing.Point(23, 21);
            this.rdbUnknown.Name = "rdbUnknown";
            this.rdbUnknown.Size = new System.Drawing.Size(81, 20);
            this.rdbUnknown.TabIndex = 2;
            this.rdbUnknown.TabStop = true;
            this.rdbUnknown.Text = "Unknown";
            this.rdbUnknown.UseVisualStyleBackColor = true;
            this.rdbUnknown.CheckedChanged += new System.EventHandler(this.rdbUnknown_CheckedChanged);
            // 
            // rdb4
            // 
            this.rdb4.AutoSize = true;
            this.rdb4.Location = new System.Drawing.Point(23, 125);
            this.rdb4.Name = "rdb4";
            this.rdb4.Size = new System.Drawing.Size(199, 20);
            this.rdb4.TabIndex = 6;
            this.rdb4.TabStop = true;
            this.rdb4.Text = "Level &4 - Maximum Capability";
            this.rdb4.UseVisualStyleBackColor = true;
            this.rdb4.CheckedChanged += new System.EventHandler(this.rdb4_CheckedChanged);
            this.rdb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdb4_KeyDown);
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(23, 99);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(170, 20);
            this.rdb3.TabIndex = 5;
            this.rdb3.TabStop = true;
            this.rdb3.Text = "Level &3 - High Capability";
            this.rdb3.UseVisualStyleBackColor = true;
            this.rdb3.CheckedChanged += new System.EventHandler(this.rdb3_CheckedChanged);
            this.rdb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdb3_KeyDown);
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(23, 73);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(190, 20);
            this.rdb2.TabIndex = 4;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "Level &2 - Medium Capability";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            this.rdb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdb2_KeyDown);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Location = new System.Drawing.Point(23, 47);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(166, 20);
            this.rdb1.TabIndex = 3;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "Level &1 - Low Capability";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged);
            this.rdb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdb1_KeyDown);
            // 
            // groupBoxChecklists
            // 
            this.groupBoxChecklists.Controls.Add(this.textBoxChecklistItem);
            this.groupBoxChecklists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxChecklists.Location = new System.Drawing.Point(434, 31);
            this.groupBoxChecklists.Name = "groupBoxChecklists";
            this.groupBoxChecklists.Size = new System.Drawing.Size(390, 125);
            this.groupBoxChecklists.TabIndex = 92;
            this.groupBoxChecklists.TabStop = false;
            this.groupBoxChecklists.Text = "Readiness Checklist Items";
            // 
            // textBoxChecklistItem
            // 
            this.textBoxChecklistItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChecklistItem.ForeColor = System.Drawing.Color.Black;
            this.textBoxChecklistItem.Location = new System.Drawing.Point(12, 21);
            this.textBoxChecklistItem.Multiline = true;
            this.textBoxChecklistItem.Name = "textBoxChecklistItem";
            this.textBoxChecklistItem.ReadOnly = true;
            this.textBoxChecklistItem.Size = new System.Drawing.Size(369, 97);
            this.textBoxChecklistItem.TabIndex = 0;
            this.textBoxChecklistItem.TabStop = false;
            this.textBoxChecklistItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChecklistItem_KeyDown);
            // 
            // groupBoxResponseRate
            // 
            this.groupBoxResponseRate.Controls.Add(this.textBoxResponseRate);
            this.groupBoxResponseRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxResponseRate.Location = new System.Drawing.Point(434, 162);
            this.groupBoxResponseRate.Name = "groupBoxResponseRate";
            this.groupBoxResponseRate.Size = new System.Drawing.Size(390, 48);
            this.groupBoxResponseRate.TabIndex = 93;
            this.groupBoxResponseRate.TabStop = false;
            this.groupBoxResponseRate.Text = "Response Rate";
            // 
            // textBoxResponseRate
            // 
            this.textBoxResponseRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResponseRate.ForeColor = System.Drawing.Color.Black;
            this.textBoxResponseRate.Location = new System.Drawing.Point(12, 21);
            this.textBoxResponseRate.Multiline = true;
            this.textBoxResponseRate.Name = "textBoxResponseRate";
            this.textBoxResponseRate.ReadOnly = true;
            this.textBoxResponseRate.Size = new System.Drawing.Size(369, 20);
            this.textBoxResponseRate.TabIndex = 0;
            this.textBoxResponseRate.TabStop = false;
            this.textBoxResponseRate.Text = "0% (0 out of 480 readiness checklist items)";
            // 
            // groupBoxBarriers
            // 
            this.groupBoxBarriers.Controls.Add(this.textBoxNotes);
            this.groupBoxBarriers.Controls.Add(this.dataGridViewBarriers);
            this.groupBoxBarriers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBarriers.Location = new System.Drawing.Point(434, 216);
            this.groupBoxBarriers.Name = "groupBoxBarriers";
            this.groupBoxBarriers.Size = new System.Drawing.Size(390, 253);
            this.groupBoxBarriers.TabIndex = 94;
            this.groupBoxBarriers.TabStop = false;
            this.groupBoxBarriers.Text = "Barriers to Improvement";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(6, 21);
            this.textBoxNotes.MaxLength = 600;
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(378, 223);
            this.textBoxNotes.TabIndex = 7;
            this.textBoxNotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNotes_KeyDown);
            this.textBoxNotes.Leave += new System.EventHandler(this.textBoxNotes_Leave);
            // 
            // dataGridViewBarriers
            // 
            this.dataGridViewBarriers.AllowUserToAddRows = false;
            this.dataGridViewBarriers.AllowUserToDeleteRows = false;
            this.dataGridViewBarriers.AllowUserToResizeColumns = false;
            this.dataGridViewBarriers.AllowUserToResizeRows = false;
            this.dataGridViewBarriers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarriers.ColumnHeadersVisible = false;
            this.dataGridViewBarriers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewBarriers.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewBarriers.Name = "dataGridViewBarriers";
            this.dataGridViewBarriers.RowHeadersVisible = false;
            this.dataGridViewBarriers.Size = new System.Drawing.Size(378, 223);
            this.dataGridViewBarriers.TabIndex = 8;
            this.dataGridViewBarriers.TabStop = false;
            this.dataGridViewBarriers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBarriers_CellContentClick);
            this.dataGridViewBarriers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewBarriers_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Barrier Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 325;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(835, 477);
            this.Controls.Add(this.groupBoxBarriers);
            this.Controls.Add(this.groupBoxResponseRate);
            this.Controls.Add(this.groupBoxChecklists);
            this.Controls.Add(this.groupBoxMaturity);
            this.Controls.Add(this.groupBoxDimSub);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assessment1 - Data CMM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxDimSub.ResumeLayout(false);
            this.groupBoxMaturity.ResumeLayout(false);
            this.groupBoxMaturity.PerformLayout();
            this.groupBoxChecklists.ResumeLayout(false);
            this.groupBoxChecklists.PerformLayout();
            this.groupBoxResponseRate.ResumeLayout(false);
            this.groupBoxResponseRate.PerformLayout();
            this.groupBoxBarriers.ResumeLayout(false);
            this.groupBoxBarriers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarriers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BrandNewToolStripButton;
        private System.Windows.Forms.ToolStripButton OpenToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.ToolStripComboBox UseCaseToolStripComboBox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBoxDimSub;
        private System.Windows.Forms.GroupBox groupBoxMaturity;
        private System.Windows.Forms.RadioButton rdb4;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.GroupBox groupBoxChecklists;
        private System.Windows.Forms.TextBox textBoxChecklistItem;
        private System.Windows.Forms.GroupBox groupBoxResponseRate;
        private System.Windows.Forms.TextBox textBoxResponseRate;
        private System.Windows.Forms.GroupBox groupBoxBarriers;
        private System.Windows.Forms.DataGridView dataGridViewBarriers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.RadioButton rdbUnknown;
        private System.Windows.Forms.ToolStripComboBox BarriersComboBox;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

