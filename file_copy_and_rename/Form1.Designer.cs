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
            this.label2 = new System.Windows.Forms.Label();
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
            this.deleteScanned = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_files)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cb_type);
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
            this.checkBox2.Location = new System.Drawing.Point(282, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(97, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Skupi skenove";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vrsta dokumenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Firma";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(282, 22);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(259, 21);
            this.cb_type.TabIndex = 7;
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
            this.dgv_files.Location = new System.Drawing.Point(9, 84);
            this.dgv_files.Name = "dgv_files";
            this.dgv_files.ReadOnly = true;
            this.dgv_files.Size = new System.Drawing.Size(695, 532);
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
            this.btn_populate_grid.Location = new System.Drawing.Point(9, 49);
            this.btn_populate_grid.Name = "btn_populate_grid";
            this.btn_populate_grid.Size = new System.Drawing.Size(220, 29);
            this.btn_populate_grid.TabIndex = 3;
            this.btn_populate_grid.Text = "Ucitaj i dodeli imena";
            this.btn_populate_grid.UseVisualStyleBackColor = true;
            this.btn_populate_grid.Click += new System.EventHandler(this.btn_populate_grid_Click);
            // 
            // cb_company_name
            // 
            this.cb_company_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_company_name.FormattingEnabled = true;
            this.cb_company_name.Location = new System.Drawing.Point(9, 22);
            this.cb_company_name.Name = "cb_company_name";
            this.cb_company_name.Size = new System.Drawing.Size(220, 21);
            this.cb_company_name.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleteScanned);
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
            this.btn_export.Location = new System.Drawing.Point(1044, 621);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(252, 31);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(759, 622);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(266, 31);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Osvezi pregled";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // panel4
            // 
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
            this.dgv_scanned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_scanned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_scanned.Location = new System.Drawing.Point(0, 0);
            this.dgv_scanned.MultiSelect = false;
            this.dgv_scanned.Name = "dgv_scanned";
            this.dgv_scanned.Size = new System.Drawing.Size(1296, 613);
            this.dgv_scanned.TabIndex = 0;
            this.dgv_scanned.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellClick);
            this.dgv_scanned.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellDoubleClick);
            this.dgv_scanned.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellLeave);
            this.dgv_scanned.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_scanned_CellValueChanged);
            this.dgv_scanned.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_scanned_UserDeletingRow);
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
            // deleteScanned
            // 
            this.deleteScanned.Location = new System.Drawing.Point(6, 622);
            this.deleteScanned.Name = "deleteScanned";
            this.deleteScanned.Size = new System.Drawing.Size(128, 30);
            this.deleteScanned.TabIndex = 7;
            this.deleteScanned.Text = "Obrisi zapis";
            this.deleteScanned.UseVisualStyleBackColor = true;
            this.deleteScanned.Click += new System.EventHandler(this.deleteScanned_Click);
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
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_scanned)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Button deleteScanned;
    }
}

