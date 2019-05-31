using Ghostscript.NET.Rasterizer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace file_copy_and_rename
{
    class utils
    {


        static public Config fetch_configuration()
        {

            Config config = null;

            try
            {

                string current_directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string config_file = File.ReadAllText(Path.Combine(current_directory, @"config.txt"));
                List<string> sql_parameters = new List<string>(config_file.Split(Environment.NewLine.ToCharArray()));

                config = new Config();


                foreach (string param in sql_parameters)
                {
                    switch (param)
                    {
                        case var this_param when new Regex(@"SERVER_NAME=").IsMatch(this_param):
                            config.Server_name = this_param.Replace("SERVER_NAME=", "");
                            break;
                        case var this_param when new Regex(@"DATA_BASE=").IsMatch(this_param):
                            config.Db_name = this_param.Replace("DATA_BASE=", "");
                            break;
                        case var this_param when new Regex(@"USER=").IsMatch(this_param):
                            config.User = this_param.Replace(@"USER=", "");
                            break;
                        case var this_param when new Regex(@"PASS=").IsMatch(this_param):
                            config.Pass = this_param.Replace("PASS=", "");
                            break;
                        case var this_param when new Regex(@"SOURCE_DIR=").IsMatch(this_param):
                            config.Source_dir = this_param.Replace("SOURCE_DIR=", "");
                            break;
                        case var this_param when new Regex(@"DEST_DIR=").IsMatch(this_param):
                            config.Dest_dir = this_param.Replace("DEST_DIR=", "");
                            break;
                    }
                }



            }
            catch (Exception)
            {
                MessageBox.Show("Nedostaje config.txt file!");
            }

            return config;

        }

        private static string get_connection_string(Config config)
        {
            return $"Server = {config.Server_name}; Database = {config.Db_name}; User Id = {config.User}; Password = {config.Pass};Pooling=false ";

        }


        static public DataTable fetch_companies_data(Config config)
        {

            DataTable data_table = null;

            try
            {
                string connetion_string = get_connection_string(config);
                using (SqlConnection connection = new SqlConnection(connetion_string))
                using (SqlCommand command = new SqlCommand("select anId, acDataBaseName from _tDataBases ", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    data_table = new DataTable();
                    adapter.Fill(data_table);
                }



            }

            catch (Exception)
            {
                throw;
            }

            return data_table;

        }




        static public DataTable fetch_types_data(Config config)
        {

            DataTable data_table = null;

            try
            {
                string connetion_string = get_connection_string(config);
                using (SqlConnection connection = new SqlConnection(connetion_string))
                using (SqlCommand command = new SqlCommand("select anId, acTypeDoc from _tTypeDoc ", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    data_table = new DataTable();
                    adapter.Fill(data_table);
                }
            }

            catch (Exception)
            {
                throw;
            }

            return data_table;

        }




        public static DataTable fetch_list(Config config, int database_id, int type_id, string parent)
        {

            DataTable files = find_all_files(config);
            DataTable data_table = null;

            string connetion_string = get_connection_string(config);
            SqlConnection connection = new SqlConnection(connetion_string);

            using (SqlCommand command = new SqlCommand("_pReturnIdentifiers", connection)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@cFiles", files);
                command.Parameters.AddWithValue("@nDataBaseId", database_id);
                command.Parameters.AddWithValue("@nTypeDocId", type_id);
                command.Parameters.AddWithValue("@nParentDoc", parent);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data_table = new DataTable();
                adapter.Fill(data_table);

            }
            return data_table;

        }


        public static DataTable fetch_list_all(Config config)
        {

            DataTable data_table = null;
            string connetion_string = get_connection_string(config);
            SqlConnection connection = new SqlConnection(connetion_string);

            using (SqlCommand command = new SqlCommand("_pReturnScaned", connection)
            {
                CommandType = CommandType.StoredProcedure
            }) {
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data_table = new DataTable();
                adapter.Fill(data_table);
            }

            return data_table;
        }





        public static DataTable find_all_files(Config config)
        {

            DataTable files_table = new DataTable();

            DataColumn identity = files_table.Columns.Add("anNo", typeof(int));
            identity.AutoIncrement = true;
            identity.AutoIncrementSeed = 1;
            identity.AutoIncrementStep = 1;
            files_table.Columns.Add("full_filename", typeof(string));
            files_table.Columns.Add("filename", typeof(string));
            files_table.Columns.Add("extension", typeof(string));


            // string current_directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            DirectoryInfo directory_info = new DirectoryInfo(config.Source_dir);
            FileInfo[] files = directory_info.GetFiles("*.*");
            foreach (FileInfo file in files)
            {

                string extension = image_checker.FileType(file.FullName);

                if (extension != null)
                {
                    string full_filename = file.Name;
                    string filename = Path.GetFileNameWithoutExtension(file.FullName);

                    files_table.Rows.Add(null, full_filename, filename, extension);
                }

            }

            return files_table;

        }


        public static void file_copy_and_rename(Config config, DataTable files, string folder_name, int database_id, int type_id)
        {
            string source_path = config.Source_dir;
            string target_path = Path.Combine(config.Dest_dir, folder_name);

            if (!Directory.Exists(target_path))
            {
                Directory.CreateDirectory(target_path);
                MessageBox.Show("Kreiran novi folder: " + folder_name);
            }

            string connetion_string = get_connection_string(config);




            foreach (DataRow row in files.Rows) {

                string old_name = row["Dokument"].ToString();

                string source_file = Path.Combine(source_path, old_name);

                FileInfo file = new FileInfo(source_file);

                if (IsFileLocked(file)) throw new IOException("Fajl " + old_name + " je otvoren! Molim vas zatvorite fajl!"); 

            }



            foreach (DataRow row in files.Rows)
            {

                string old_name = row["Dokument"].ToString();
                string new_name = row["Broj"].ToString();
                int id = int.Parse(row["Brojac"].ToString());
                string extension = row["Tip"].ToString();
                string parent = row["Zaglavlje"].ToString();

                string source_file = Path.Combine(source_path, old_name);
                string dest_file = Path.Combine(target_path, new_name);


                try { File.Move(source_file, dest_file); }
                catch (Exception)
                {
                    throw;
                }


                using (SqlConnection connection = new SqlConnection(connetion_string))
                {

                   
                    byte[] file = File.ReadAllBytes(dest_file);


                    SqlCommand command = new SqlCommand("_pInsertIdentifiers", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@cIdentifier", new_name);
                    command.Parameters.AddWithValue("@nIdentifier", id);
                    command.Parameters.AddWithValue("@nIdDataBase", database_id);
                    command.Parameters.AddWithValue("@cImage", dest_file);
                    command.Parameters.AddWithValue("@cExtension", extension);
                    command.Parameters.AddWithValue("@nTypeDocId", type_id);
                    command.Parameters.AddWithValue("@cParentIdentifier", parent);
                    command.Parameters.AddWithValue("@bImage", file);
                    using (command)
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();

                    }

                }


            }
        }


        public static void update_scan(Config config, int index, string column, string value)
        {

            string connetion_string = get_connection_string(config);

            using (SqlConnection connection = new SqlConnection(connetion_string))
            {

                SqlCommandBuilder builder = new SqlCommandBuilder();
                string escaped_column = builder.QuoteIdentifier(column);
                DateTime date;


                SqlCommand command = new SqlCommand("update [_tIdentityTable]  set " + escaped_column + "= @cValue where anId = @nId", connection);

                command.Parameters.AddWithValue("@nId", index);
                command.Parameters.AddWithValue("@cColumn", column);
                if (DateTime.TryParse(value, out date))
                {
                    command.Parameters.AddWithValue("@cValue", date);
                }
                else {
                    command.Parameters.AddWithValue("@cValue", value);
                }

                using (command)
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

            }
        }

        public static void delete_scan(Config config, int index) {

            string connetion_string = get_connection_string(config);

            using (SqlConnection connection = new SqlConnection(connetion_string))
            {

                SqlCommand command = new SqlCommand("delete from  [_tIdentityTable]  where anId = @nId", connection);

                command.Parameters.AddWithValue("@nId", index);

                 using (command)
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

            }

        }



        public static Image load_image_from_db(Config config, string id)
        {
            DataTable data_table = null;
            Image img = null;
            string connetion_string = get_connection_string(config);
            SqlConnection connection = new SqlConnection(connetion_string);

            using (SqlCommand command = new SqlCommand("select top 1 ltrim(rtrim(acExtension)) acExtension, abImage from _tIdentityTable where acIdentifier = @nId", connection))
            {
                command.Parameters.AddWithValue("@nId", id);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data_table = new DataTable();
                adapter.Fill(data_table);

            }


            byte[] bytes = (byte[])data_table.Rows[0][1];
            string extension = (string)data_table.Rows[0][0];

            if (extension == ".pdf")
            {
                using (var rasterizer = new GhostscriptRasterizer())
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    rasterizer.Open(ms);
                    img = rasterizer.GetPage(72, 72, 1);
                }
            }
            else
            {
                try
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        img = new Bitmap(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return img;

        }




        public static void export_data_table(DataTable datatable) {

            using (ExcelPackage pack = new ExcelPackage())
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Knjiga poste");
                ws.Cells["A1"].LoadFromDataTable(datatable, true);
                ws.Cells["C:C"].Style.Numberformat.Format = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                ws.Cells["F:F"].Style.Numberformat.Format = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                ws.Cells.AutoFitColumns();
                var ms = new MemoryStream();
                pack.SaveAs(new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"knjiga_poste.xlsx")));
            }


        }





        protected static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }





    }
}
