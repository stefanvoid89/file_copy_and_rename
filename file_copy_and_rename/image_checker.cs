using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace file_copy_and_rename
{
    class image_checker
    {
      private  static string IsValidImageFile(string file)
        {


            string extension = null;

            byte[] buffer = new byte[8];
            byte[] bufferEnd = new byte[2];

            var bmp = new byte[] { 0x42, 0x4D };               // BMP "BM"
            var gif87a = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 };     // "GIF87a"
            var gif89a = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 };     // "GIF89a"
            var png = new byte[] { 0x89, 0x50, 0x4e, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };   // PNG "\x89PNG\x0D\0xA\0x1A\0x0A"
            var tiffI = new byte[] { 0x49, 0x49, 0x2A, 0x00 }; // TIFF II "II\x2A\x00"
            var tiffM = new byte[] { 0x4D, 0x4D, 0x00, 0x2A }; // TIFF MM "MM\x00\x2A"
            var jpeg = new byte[] { 0xFF, 0xD8, 0xFF };        // JPEG JFIF (SOI "\xFF\xD8" and half next marker xFF)
            var jpegEnd = new byte[] { 0xFF, 0xD9 };           // JPEG EOI "\xFF\xD9"

            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    if (fs.Length > buffer.Length)
                    {
                        fs.Read(buffer, 0, buffer.Length);
                        fs.Position = (int)fs.Length - bufferEnd.Length;
                        fs.Read(bufferEnd, 0, bufferEnd.Length);
                    }

                    fs.Close();
                }

                if (ByteArrayStartsWith(buffer, bmp))        extension = ".bmp";
                if ( ByteArrayStartsWith(buffer, gif87a))    extension = ".gif";
                if ( ByteArrayStartsWith(buffer, gif89a))    extension = ".gif";
                if ( ByteArrayStartsWith(buffer, png))       extension = ".png";
                if ( ByteArrayStartsWith(buffer, tiffI))     extension = ".tif";
                if ( ByteArrayStartsWith(buffer, tiffM))     extension = ".tif";


                if (ByteArrayStartsWith(buffer, jpeg))
                {
                            if (ByteArrayStartsWith(bufferEnd, jpegEnd))
                    {
                        extension = ".jpg";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return extension;
        }


        private static string  IsValidPDFFile(string file)
        {

            string extension = null;

            

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read)) {

                byte[] buffer = null;
                using (BinaryReader br = new BinaryReader(fs)) {
                    long numBytes = new FileInfo(file).Length;
                    //buffer = br.ReadBytes((int)numBytes);
                    buffer = br.ReadBytes(5);

                    var enc = new ASCIIEncoding();
                    var header = enc.GetString(buffer);


                    //%PDF−1.0
                    // If you are loading it into a long, this is (0x04034b50).
                    try
                    {
                        if (buffer[0] == 0x25 && buffer[1] == 0x50
                       && buffer[2] == 0x44 && buffer[3] == 0x46)
                        {
                            if (header.StartsWith("%PDF-")) extension = ".pdf";
                        }
                    }
                    catch { }

                }

            }


            return extension;

        }


        public static string FileType(string file) {
            string extension = null;
            extension = image_checker.IsValidImageFile(file);
            if (extension == null) extension = image_checker.IsValidPDFFile(file);

            return extension;
        }


        private static bool ByteArrayStartsWith(byte[] a, byte[] b)
        {
            if (a.Length < b.Length)
            {
                return false;
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }



    }
}
