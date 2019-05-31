using Ghostscript.NET.Rasterizer;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace file_copy_and_rename
{
    public partial class Form1 : Form
    {

        static Config config = utils.fetch_configuration();
        DateTimePicker dtp;
        TextBox tb;
        




        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (config == null) { Close(); }
            else
            {
                try
                {
                    DataTable companies = utils.fetch_companies_data(config);
                    DataTable types = utils.fetch_types_data(config);


                    cb_company_name.DataSource = companies;
                    cb_company_name.ValueMember = "anId";
                    cb_company_name.DisplayMember = "acDataBaseName";


                    cb_type.DataSource = types;
                    cb_type.ValueMember = "anId";
                    cb_type.DisplayMember = "acTypeDoc";



                    DataTable scanned_data = utils.fetch_list_all(config);
                    dgv_scanned.DataSource = scanned_data;

                    dgv_scanned.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_scanned.AutoResizeColumns();
                    dgv_scanned.AllowUserToResizeColumns = true;
                    dgv_scanned.AllowUserToOrderColumns = true;

                    
                    dgv_scanned.Columns[0].ReadOnly = true;
                    dgv_scanned.Columns[1].ReadOnly = true;
                    dgv_scanned.Columns[2].ReadOnly = true;
                    dgv_scanned.Columns[5].ReadOnly = true;
                    dgv_scanned.Columns[6].ReadOnly = true;


                    dgv_scanned.Columns[0].Width = 20;
                    dgv_scanned.Columns[1].Width = 100;
                    dgv_scanned.Columns[2].Width = 70;
                    dgv_scanned.Columns[3].Width = 300;
                    dgv_scanned.Columns[4].Width = 200;
                    dgv_scanned.Columns[5].Width = 70;
                    dgv_scanned.Columns[6].Width = 300;
                    

                    dgv_scanned.KeyUp += new KeyEventHandler(tb_KeyDown);

                }

                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(System.Data.SqlClient.SqlException))
                    {
                        MessageBox.Show("Greska pri prijavi");
                    }
                    else { MessageBox.Show(ex.GetType().ToString()); }

                    Close();
                }

            }

        }

        private void btn_populate_grid_Click(object sender, EventArgs e)
        {
            int database_id = int.Parse(cb_company_name.SelectedValue.ToString());
            int type_id = int.Parse(cb_type.SelectedValue.ToString());
            //  string list_of_files = utils.find_all_files(config);

            string parent = "F";

            if (checkBox2.Checked == true) parent = "T";


            DataTable files = utils.fetch_list(config, database_id, type_id,parent);
            dgv_files.DataSource = files;
            dgv_files.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_files.AutoResizeColumns();
            dgv_files.AllowUserToResizeColumns = true;
            dgv_files.AllowUserToOrderColumns = true;

            if (files != null && files.Rows.Count > 0)
            {
                // cb_company_name.Enabled = false;
                //cb_type.Enabled = false;
                btn_copy.Enabled = true;
            }

        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            int database_id = int.Parse(cb_company_name.SelectedValue.ToString());
            int type_id = int.Parse(cb_type.SelectedValue.ToString());
            DataTable table = (DataTable)dgv_files.DataSource;
            string folder_name = cb_company_name.Text;
            try
            {
                utils.file_copy_and_rename(config, table, folder_name, database_id, type_id);

                dgv_files.DataSource = null;
                cb_type.Enabled = true;
                cb_company_name.Enabled = true;
                btn_copy.Enabled = false;

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                DataTable scanned_data = utils.fetch_list_all(config);
                dgv_scanned.DataSource = scanned_data;

            }
            catch (Exception ex)
            {
          
                
                    MessageBox.Show(ex.Message);
                
            }




        }

        private void dgv_files_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {

                int width;
                int height;
                Image img = null;
                Bitmap smallImg = null;

                string source_file = Path.Combine(config.Source_dir, dgv_files.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                string extension = dgv_files.Rows[e.RowIndex].Cells["Tip"].Value.ToString();

                if (extension == ".pdf")
                {

                    using (var rasterizer = new GhostscriptRasterizer())
                    {

                        byte[] data = File.ReadAllBytes(source_file);
                        MemoryStream ms = new MemoryStream(data);

                        rasterizer.Open(ms);


                        img = rasterizer.GetPage(72, 72, 1);

                        width = panel2.Width;
                        height = (width * img.Height) / img.Width;


                        smallImg = new Bitmap(img, width, height);
  
                        pictureBox1.Image = smallImg;

                    }
                }
                else
                {

                    try
                    {
                        using (var bmpTemp = new Bitmap(source_file))
                        {

                          
                            img = new Bitmap(bmpTemp);
                            width = panel2.Width;
                            height = (width * img.Height) / img.Width;
                            smallImg = new Bitmap(img, width, height);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    pictureBox1.Image = smallImg;

                }

            }
        }

        private void dgv_scanned_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex > -1)
            {
                string id = dgv_scanned.Rows[e.RowIndex].Cells[6].Value.ToString();
                //Image img = utils.load_image_from_db(config, id);
                //pictureBox2.Image = new Bitmap(img,100,100);
                
            }

            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                DateTime date;
                dtp = new DateTimePicker();

                if (DateTime.TryParse(dgv_scanned.CurrentCell.Value.ToString(), out date))
                {
                    dtp.Value = (DateTime)dgv_scanned.CurrentCell.Value;
                }
                else
                {
                    dtp.Value = DateTime.Now;
                }
                dgv_scanned.Controls.Add(dtp);
                dtp.Format = DateTimePickerFormat.Short;

                Rectangle Rectangle = GetCellRectangle(e.ColumnIndex, e.RowIndex);
                dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                dtp.Location = new Point(Rectangle.X, Rectangle.Y);
                dtp.Visible = true;
                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_OnTextChange);
            }

            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {

                //MessageBox.Show("kutija");
                tb = new TextBox();
                tb.Visible = false;
                tb.Text = (string)dgv_scanned.CurrentCell.Value;

                tb.Multiline = true;
                tb.ScrollBars = ScrollBars.Vertical;

                // tb.Text = "";

                dgv_scanned.Controls.Add(tb);

                Rectangle Rectangle = dgv_scanned.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                tb.Size = new Size(300,300);
                tb.Location = new Point(Rectangle.X, Rectangle.Y);
                tb.Visible = true;
                tb.Focus();
                tb.Leave += new EventHandler(tb_CloseUp);
                tb.TextChanged += new EventHandler(tb_OnTextChange);
                tb.KeyUp += new KeyEventHandler(tb_KeyDown);
            }


        }


        private Rectangle GetCellRectangle(int columnIndex, int rowIndex)
        {
            Rectangle selRect = new Rectangle(0, 0, 0, 0);

            selRect.X = dgv_scanned.RowHeadersWidth + 1;
            for (int i = dgv_scanned.FirstDisplayedScrollingColumnIndex; i < columnIndex; i++)
            {
                selRect.X += dgv_scanned.Columns[i].Width;
            }
            selRect.X -= dgv_scanned.FirstDisplayedScrollingColumnHiddenWidth;

            selRect.Y = dgv_scanned.ColumnHeadersHeight + 1;
            for (int i = dgv_scanned.FirstDisplayedScrollingRowIndex; i < rowIndex; i++)
            {
                selRect.Y += dgv_scanned.Rows[i].Height;
            }

            selRect.Width = dgv_scanned.Rows[rowIndex].Cells[columnIndex].Size.Width;
            selRect.Height = dgv_scanned.Rows[rowIndex].Cells[columnIndex].Size.Height;
            return selRect;
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {

            dgv_scanned.CurrentCell.Value = dtp.Text.ToString();
    }


        private void tb_OnTextChange(object sender, EventArgs e)
        {

            dgv_scanned.CurrentCell.Value = tb.Text.ToString();
        }


        void dtp_CloseUp(object sender, EventArgs e)
        {

            dtp.Visible = false;

        }


        void tb_CloseUp(object sender, EventArgs e)
        {

            tb.Visible = false;

        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tb.Visible = false;
            }



        }

 

        private void dgv_scanned_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                if(dtp != null)     dtp.Visible = false;
            }

            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                if (tb != null) tb.Visible = false;
            }
        }

        


        private void dgv_scanned_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(dgv_scanned.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

            int id = (Int32)dgv_scanned.Rows[e.RowIndex].Cells[0].Value;

            string column = "";
            if (e.ColumnIndex == 3) column = "acNote";
            if (e.ColumnIndex == 4) column = "acSubject";
            if (e.ColumnIndex == 5) column = "adDateDoc";


            string value = dgv_scanned.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (column != "")
                try
                {
                    utils.update_scan(config, id, column, value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DataTable scanned_data = utils.fetch_list_all(config);
            dgv_scanned.DataSource = scanned_data;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            utils.export_data_table((DataTable)dgv_scanned.DataSource);
        }

        private void dgv_scanned_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex > -1)
            {
                string file = dgv_scanned.Rows[e.RowIndex].Cells[6].Value.ToString();
                string company = dgv_scanned.Rows[e.RowIndex].Cells[1].Value.ToString();
               string path = Path.Combine(config.Dest_dir, company,file);
                
                try
                {
                    Process.Start(path);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void dgv_scanned_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {


      


        }

        private void deleteScanned_Click(object sender, EventArgs e)
        {

            int index = dgv_scanned.CurrentCell.RowIndex;
            int id = (Int32)dgv_scanned.Rows[index].Cells[0].Value;
            string file = dgv_scanned.Rows[index].Cells[6].Value.ToString();
            string company = dgv_scanned.Rows[index].Cells[1].Value.ToString();
            string path = Path.Combine(config.Dest_dir, company, file);

            if (File.Exists(path)) MessageBox.Show("Ne mozete obristati zapis pre brisanja skeniranog dokumenta dokumenta.");


            else {

                try
                {
                    utils.delete_scan(config, id);
                    dgv_scanned.Rows.RemoveAt(index);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DataTable scanned_data = utils.fetch_list_all(config);
                dgv_scanned.DataSource = scanned_data;

            }

        }
    }
}
