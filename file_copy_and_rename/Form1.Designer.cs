namespace file_copy_and_rename
{
    partial class Form1
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_files = new System.Windows.Forms.DataGridView();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_populate_grid = new System.Windows.Forms.Button();
            this.cb_company_name = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_scanned = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cb_regno = new System.Windows.Forms.ComboBox();
            this.rb_new = new System.Windows.Forms.RadioButton();
            this.rb_add = new System.Windows.Forms.RadioButton();
            this.dgv_scanned_item = new System.Windows.Forms.DataGridView();
            this.cb_company_name_scann = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_files)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned_item)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cb_regno);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.cb_type);
            this.tabPage1.Controls.Add(this.rb_add);
            this.tabPage1.Controls.Add(this.rb_new);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.dgv_files);
            this.tabPage1.Controls.Add(this.btn_copy);
            this.tabPage1.Controls.Add(this.btn_populate_grid);
            this.tabPage1.Controls.Add(this.cb_company_name);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1302, 690);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unos skeniranih dokumenata";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(380, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(97, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Skupi skenove";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Enter += new System.EventHandler(this.checkBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Preduzece";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(122, 38);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(220, 21);
            this.cb_type.TabIndex = 7;
            this.cb_type.Enter += new System.EventHandler(this.cb_type_Enter);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(710, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 655);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 594);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_files
            // 
            this.dgv_files.AllowUserToAddRows = false;
            this.dgv_files.AllowUserToDeleteRows = false;
            this.dgv_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_files.Location = new System.Drawing.Point(9, 108);
            this.dgv_files.Name = "dgv_files";
            this.dgv_files.ReadOnly = true;
            this.dgv_files.Size = new System.Drawing.Size(695, 508);
            this.dgv_files.TabIndex = 1;
            this.dgv_files.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_files_CellClick);
            // 
            // btn_copy
            // 
            this.btn_copy.Enabled = false;
            this.btn_copy.Location = new System.Drawing.Point(9, 622);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(695, 30);
            this.btn_copy.TabIndex = 4;
            this.btn_copy.Text = "Prenesi";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_populate_grid
            // 
            this.btn_populate_grid.Location = new System.Drawing.Point(483, 39);
            this.btn_populate_grid.Name = "btn_populate_grid";
            this.btn_populate_grid.Size = new System.Drawing.Size(208, 63);
            this.btn_populate_grid.TabIndex = 3;
            this.btn_populate_grid.Text = "Ucitaj i dodeli imena";
            this.btn_populate_grid.UseVisualStyleBackColor = true;
            this.btn_populate_grid.Click += new System.EventHandler(this.btn_populate_grid_Click);
            // 
            // cb_company_name
            // 
            this.cb_company_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_company_name.FormattingEnabled = true;
            this.cb_company_name.Location = new System.Drawing.Point(70, 6);
            this.cb_company_name.Name = "cb_company_name";
            this.cb_company_name.Size = new System.Drawing.Size(220, 21);
            this.cb_company_name.TabIndex = 2;
            this.cb_company_name.SelectedIndexChanged += new System.EventHandler(this.cb_company_name_SelectedIndexChanged);
            this.cb_company_name.Enter += new System.EventHandler(this.cb_company_name_Enter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cb_company_name_scann);
            this.tabPage2.Controls.Add(this.btn_export);
            this.tabPage2.Controls.Add(this.btn_refresh);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1302, 690);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pregled";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(1047, 622);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(252, 31);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(311, 622);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(266, 31);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Osvezi pregled";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_scanned_item);
            this.panel4.Controls.Add(this.dgv_scanned);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1296, 613);
            this.panel4.TabIndex = 6;
            // 
            // dgv_scanned
            // 
            this.dgv_scanned.AllowUserToAddRows = false;
            this.dgv_scanned.AllowUserToOrderColumns = true;
            this.dgv_scanned.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_scanned.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgv_scanned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_scanned.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_scanned.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_scanned.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgv_scanned.Location = new System.Drawing.Point(0, 0);
            this.dgv_scanned.MultiSelect = false;
            this.dgv_scanned.Name = "dgv_scanned";
            this.dgv_scanned.Size = new System.Drawing.Size(1296, 392);
            this.dgv_scanned.TabIndex = 0;
            this.dgv_scanned.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellClick);
            this.dgv_scanned.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellDoubleClick);
            this.dgv_scanned.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellLeave);
            this.dgv_scanned.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1310, 716);
            this.tabControl1.TabIndex = 6;
            // 
            // cb_regno
            // 
            this.cb_regno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_regno.FormattingEnabled = true;
            this.cb_regno.Location = new System.Drawing.Point(122, 81);
            this.cb_regno.Name = "cb_regno";
            this.cb_regno.Size = new System.Drawing.Size(220, 21);
            this.cb_regno.TabIndex = 12;
            this.cb_regno.Enter += new System.EventHandler(this.cb_regno_Enter);
            // 
            // rb_new
            // 
            this.rb_new.AutoSize = true;
            this.rb_new.Checked = true;
            this.rb_new.Location = new System.Drawing.Point(9, 39);
            this.rb_new.Name = "rb_new";
            this.rb_new.Size = new System.Drawing.Size(97, 17);
            this.rb_new.TabIndex = 12;
            this.rb_new.TabStop = true;
            this.rb_new.Text = "Novi dokument";
            this.rb_new.UseVisualStyleBackColor = true;
            this.rb_new.CheckedChanged += new System.EventHandler(this.rb_new_CheckedChanged);
            // 
            // rb_add
            // 
            this.rb_add.AutoSize = true;
            this.rb_add.Location = new System.Drawing.Point(9, 81);
            this.rb_add.Name = "rb_add";
            this.rb_add.Size = new System.Drawing.Size(109, 17);
            this.rb_add.TabIndex = 15;
            this.rb_add.Text = "Dodaj dokumentu";
            this.rb_add.UseVisualStyleBackColor = true;
            this.rb_add.CheckedChanged += new System.EventHandler(this.rb_add_CheckedChanged);
            // 
            // dgv_scanned_item
            // 
            this.dgv_scanned_item.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgv_scanned_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_scanned_item.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_scanned_item.Location = new System.Drawing.Point(0, 398);
            this.dgv_scanned_item.MultiSelect = false;
            this.dgv_scanned_item.Name = "dgv_scanned_item";
            this.dgv_scanned_item.Size = new System.Drawing.Size(1296, 215);
            this.dgv_scanned_item.TabIndex = 1;
            this.dgv_scanned_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_item_CellClick);
            this.dgv_scanned_item.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_item_CellDoubleClick);
            this.dgv_scanned_item.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_item_CellLeave);
            this.dgv_scanned_item.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_item_CellValueChanged);
            // 
            // cb_company_name_scann
            // 
            this.cb_company_name_scann.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_company_name_scann.FormattingEnabled = true;
            this.cb_company_name_scann.Location = new System.Drawing.Point(70, 628);
            this.cb_company_name_scann.Name = "cb_company_name_scann";
            this.cb_company_name_scann.Size = new System.Drawing.Size(220, 21);
            this.cb_company_name_scann.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 631);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Preduzece";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 698);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Knjiga poste";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_files)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned_item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_files;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_populate_grid;
        private System.Windows.Forms.ComboBox cb_company_name;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_scanned;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox cb_regno;
        private System.Windows.Forms.RadioButton rb_add;
        private System.Windows.Forms.RadioButton rb_new;
        private System.Windows.Forms.DataGridView dgv_scanned_item;
        private System.Windows.Forms.ComboBox cb_company_name_scann;
        private System.Windows.Forms.Label label2;
    }
}

