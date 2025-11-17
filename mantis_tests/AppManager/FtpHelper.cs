using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.FtpClient;


namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager) // construcor for FtpHelper
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }
        public void BackUpFile(string path) // Create backUp file 
        {
            String backUpPath = path + ".bak";
            if (client.FileExists(backUpPath))
            {
                return;
            }
            client.Rename(path, backUpPath);
        }
        public void RestoreBackUpFile(string path) // Restore backUp file
        {
            String backUpPath = path + ".bak";
            if (! client.FileExists(backUpPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backUpPath, path);
        }
        public void Upload (string path, Stream localFile) // Upload file to the directory
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path)) // using Stream for recording data to file from buffer 
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }

    }
}
