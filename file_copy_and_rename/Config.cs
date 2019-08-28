namespace file_copy_and_rename
{
    class Config
    {
        private string db_name;
        private string user;
        private string pass;
        private string source_dir;
        private string dest_dir;
        private string export_dir;


        public string Server_name { get; set; }
        public string Db_name { get => db_name; set => db_name = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Source_dir { get => source_dir; set => source_dir = value; }
        public string Dest_dir { get => dest_dir; set => dest_dir = value; }
        public string Export_dir { get => export_dir; set => export_dir = value; }
    }
}
