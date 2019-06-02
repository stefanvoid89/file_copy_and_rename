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

        DataSet ds_scanned;


        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
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
                    DataTable companies_scann = companies.Copy();

                    


                    DataRow all_companies = companies_scann.NewRow();

                    all_companies["anId"] = 0;
                    all_companies["acDataBaseName"] = "SVA PREDUZECA";

                    companies_scann.Rows.InsertAt(all_companies, 0);

                    cb_company_name.DataSource = companies;
                    cb_company_name.ValueMember = "anId";
                    cb_company_name.DisplayMember = "acDataBaseName";


                    cb_company_name_scann.DataSource = companies_scann;
                    cb_company_name_scann.ValueMember = "anId";
                    cb_company_name_scann.DisplayMember = "acDataBaseName";


                    cb_type.DataSource = types;
                    cb_type.ValueMember = "anId";
                    cb_type.DisplayMember = "acTypeDocName";

                    // predifinisana vrednost
                    load_and_fill_scanned_grids(0);


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

        private void load_and_fill_scanned_grids(int database_id) {

            dgv_scanned.DataSource = null;
            dgv_scanned_item.DataSource = null;

            ds_scanned = new DataSet();
            ds_scanned.Tables.Add(utils.fetch_list_all(config, database_id));
            ds_scanned.Tables.Add(utils.fetch_list_all_item(config, database_id));

            DataRelation relation = new DataRelation("pc_relation", ds_scanned.Tables[0].Columns[2], ds_scanned.Tables[1].Columns[2]);
            ds_scanned.Relations.Add(relation);


            dgv_scanned.DataSource = ds_scanned.Tables[0];

            if (dgv_scanned.Columns.Contains("Delete"))  dgv_scanned.Columns.Remove("Delete");
                DataGridViewButtonColumn delete_scanned = new DataGridViewButtonColumn();
                delete_scanned.UseColumnTextForButtonValue = true;
                delete_scanned.Name = "Delete";
                delete_scanned.Text = "Obrisi zapis";

                dgv_scanned.Columns.Insert(ds_scanned.Tables[0].Columns.Count, delete_scanned);
            

           
            dgv_scanned_item.DataMember = "pc_relation";
            dgv_scanned_item.DataSource = ds_scanned.Tables[0];

            dgv_scanned_item.AllowUserToAddRows = false;

            if (dgv_scanned_item.Columns.Contains("Delete")) dgv_scanned_item.Columns.Remove("Delete");
            
                DataGridViewButtonColumn delete_scanned_item = new DataGridViewButtonColumn();
                delete_scanned_item.UseColumnTextForButtonValue = true;
                delete_scanned_item.Name = "Delete";
                delete_scanned_item.Text = "Obrisi zapis";
                dgv_scanned_item.Columns.Insert(ds_scanned.Tables[1].Columns.Count, delete_scanned_item);
            


            dgv_scanned.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgv_scanned.AutoResizeColumns();
            dgv_scanned.AllowUserToResizeColumns = true;
            dgv_scanned.AllowUserToOrderColumns = true;


            dgv_scanned.Columns[0].Visible = false;
            dgv_scanned.Columns[1].Visible = false;
            dgv_scanned.Columns[2].ReadOnly = true;
            dgv_scanned.Columns[3].ReadOnly = true;
            //dgv_scanned.Columns[6].ReadOnly = true;


            dgv_scanned_item.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgv_scanned_item.AutoResizeColumns();
            dgv_scanned_item.AllowUserToResizeColumns = true;
            dgv_scanned_item.AllowUserToOrderColumns = true;


            dgv_scanned_item.Columns[0].Visible = false;
            dgv_scanned_item.Columns[1].Visible = false;
            dgv_scanned_item.Columns[2].ReadOnly = true;
            dgv_scanned_item.Columns[3].ReadOnly = true;
            dgv_scanned_item.Columns[4].ReadOnly = true;



            dgv_scanned.Columns[2].Width = 200;
            dgv_scanned.Columns[3].Width = 150;
            dgv_scanned.Columns[4].Width = 200;
            dgv_scanned.Columns[5].Width = 350;
            dgv_scanned.Columns[6].Width = 150;


            dgv_scanned.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgv_scanned.Columns[6].DefaultCellStyle.Format = "dd.MM.yyyy";

            dgv_scanned_item.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy";



            dgv_scanned_item.Columns[2].Width = 200;
            dgv_scanned_item.Columns[3].Width = 300;
            dgv_scanned_item.Columns[4].Width = 150;
            dgv_scanned_item.Columns[5].Width = 350;

            dgv_scanned.KeyUp += new KeyEventHandler(tb_KeyDown);
        }





        private void btn_populate_grid_Click(object sender, EventArgs e)
        {
            int database_id = int.Parse(cb_company_name.SelectedValue.ToString());
            int type_id = int.Parse(cb_type.SelectedValue.ToString());


            string isGrouped = "F";

            if (checkBox2.Checked == true) isGrouped = "T";

            string reg_no = null;

            if (rb_add.Checked && cb_regno.SelectedValue != null) reg_no = cb_regno.SelectedValue.ToString();


            DataTable files = utils.fetch_list(config, database_id, type_id, isGrouped, reg_no);
            dgv_files.DataSource = files;
            dgv_files.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_files.AutoResizeColumns();
            dgv_files.AllowUserToResizeColumns = true;
            dgv_files.AllowUserToOrderColumns = true;
            dgv_files.Columns["anNo"].Visible = false;
            dgv_files.Columns["anRegNo"].Visible = false;

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

                //int database_id = int.Parse(cb_company_name_scann.SelectedValue.ToString());
                load_and_fill_scanned_grids(database_id);

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
            if (e.ColumnIndex == 7 && e.RowIndex > -1)
            {
                int index = dgv_scanned.CurrentCell.RowIndex;
                string reg_no = dgv_scanned.Rows[index].Cells["Zaglavlje"].Value.ToString();

                //string file = dgv_scanned.Rows[index].Cells[6].Value.ToString();
                //string company = dgv_scanned.Rows[index].Cells[1].Value.ToString();
                //string path = Path.Combine(config.Dest_dir, company, file);

                //if (File.Exists(path)) MessageBox.Show("Ne mozete obristati zapis pre brisanja skeniranog dokumenta.");

                if (utils.reg_item_exists(config, reg_no)) MessageBox.Show("Ne mozete obristati zapis, postoje vezana dokumenta.");


                else
                {

                    try
                    {
                        utils.delete_scan(config, reg_no);
                        dgv_scanned.Rows.RemoveAt(index);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally {
                        //int database_id = int.Parse(cb_company_name_scann.SelectedValue.ToString());
                        //load_and_fill_scanned_grids(database_id);
                    }
                    



                }
            }
            //{
            //    string id = dgv_scanned.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    //Image img = utils.load_image_from_db(config, id); // izbacuje se zbog mesta u bazi i zbog mesta na formi
            //    //pictureBox2.Image = new Bitmap(img,100,100);

            //}


            if (e.ColumnIndex == 6 && e.RowIndex > -1)
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

            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {

                //MessageBox.Show("kutija");
                tb = new TextBox();
                tb.Visible = false;
                tb.Text = (string)dgv_scanned.CurrentCell.Value;
                tb.Multiline = true;
                //tb.AcceptsReturn = true;           
                tb.ScrollBars = ScrollBars.Vertical;

                // tb.Text = "";

                dgv_scanned.Controls.Add(tb);

                Rectangle Rectangle = dgv_scanned.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                tb.Size = new Size(350,100);
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
            if (e.ColumnIndex == 6 && e.RowIndex > -1)
            {
                if(dtp != null)     dtp.Visible = false;
            }

            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                if (tb != null) tb.Visible = false;
            }
        }

        


        private void dgv_scanned_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(dgv_scanned.Rows[e.RowIndex].Index.ToString());

            int id = (int)dgv_scanned.Rows[e.RowIndex].Cells[0].Value;

            string column = "";

            if (e.ColumnIndex == 4) column = "acSubject";
            if (e.ColumnIndex == 5) column = "acNote";
            if (e.ColumnIndex == 6) column = "adDateDoc";


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
            int database_id = int.Parse(cb_company_name_scann.SelectedValue.ToString()) ;
            load_and_fill_scanned_grids(database_id);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            utils.export_data_table((DataTable)dgv_scanned.DataSource);
        }

        private void dgv_scanned_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

  
        private void cb_company_name_Enter(object sender, EventArgs e)
        {
            btn_copy.Enabled = false;
        }

        private void cb_type_Enter(object sender, EventArgs e)
        {
            btn_copy.Enabled = false;
        }

        private void checkBox2_Enter(object sender, EventArgs e)
        {
            btn_copy.Enabled = false;
        }

        private void rb_new_CheckedChanged(object sender, EventArgs e)
        {

            cb_type.Enabled = true;
            checkBox2.Enabled = true;
            cb_regno.Enabled = false;
            btn_copy.Enabled = false;

            cb_regno.DataSource = null;

        }

        private void rb_add_CheckedChanged(object sender, EventArgs e)
        {
            cb_type.Enabled = false;
            checkBox2.Enabled = false;
            cb_regno.Enabled = true;
            btn_copy.Enabled = false;


            DataTable regs = utils.fetch_reg_no_by_companies(config, (int) cb_company_name.SelectedValue);
            cb_regno.DataSource = regs;
            cb_regno.ValueMember = "acRegNo";
            cb_regno.DisplayMember = "acRegNo";

        }

        private void cb_company_name_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (((ComboBox)sender).SelectedValue != null && rb_add.Checked) {
                DataTable regs = utils.fetch_reg_no_by_companies(config, (int)cb_company_name.SelectedValue);
                cb_regno.DataSource = regs;
                cb_regno.ValueMember = "acRegNo";
                cb_regno.DisplayMember = "acRegNo";
            }

            

        }

        private void cb_regno_Enter(object sender, EventArgs e)
        {
            btn_copy.Enabled = false;
        }

        private void dgv_scanned_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                string reg_no = dgv_scanned_item.Rows[e.RowIndex].Cells["Zaglavlje"].Value.ToString();
                string file = dgv_scanned_item.Rows[e.RowIndex].Cells["Dokument"].Value.ToString();
                string company = utils.get_database_name(config, reg_no);
                string path = Path.Combine(config.Dest_dir, company, file);

                try
                {
                    Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void dgv_scanned_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6 && e.RowIndex > -1)
            {
                int index = dgv_scanned_item.CurrentCell.RowIndex;
                int id = (int)dgv_scanned_item.Rows[e.RowIndex].Cells["anId"].Value;
                string reg_no = dgv_scanned_item.Rows[e.RowIndex].Cells["Zaglavlje"].Value.ToString();

                string file = dgv_scanned_item.Rows[e.RowIndex].Cells["Dokument"].Value.ToString();
                string company = utils.get_database_name(config, reg_no);
                string path = Path.Combine(config.Dest_dir, company, file);

                if (File.Exists(path)) MessageBox.Show("Ne mozete obristati zapis pre brisanja skeniranog dokumenta.");

                else
                {

                    try
                    {
                        utils.delete_scan_item(config, id);
                        dgv_scanned_item.Rows.RemoveAt(index);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //int database_id = int.Parse(cb_company_name_scann.SelectedValue.ToString());
                        //load_and_fill_scanned_grids(database_id);
                    }




                }
            }

        }

        private void dgv_scanned_item_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_scanned_item_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
