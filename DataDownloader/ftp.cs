using System;
using System.IO;
using System.Linq;
using Renci.SshNet;

namespace DataDownloader
{
    internal class Ftp
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _pass;

        /* Construct Object */
        public Ftp(string hostIp, string userName, string password)
        {
            _host = hostIp;
            _user = userName;
            _pass = password;
        }

        public int GetAmountOfFiles(string directory)
        {
            using (var sftp = new SftpClient(_host, _user, _pass))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(directory).ToList();

                var totalFiles = files.Count - 2; //-2 to skip current dir and prev dir
                return totalFiles;
            }
        }

        public void DownloadAll(string directory, string localDirectory)
        {
            using (var sftp = new SftpClient(_host, _user, _pass))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(directory).ToList();

                var count = 1;
                var totalFiles = files.Count - 2; //-2 to skip current dir and prev dir
                foreach (var file in files)
                {
                    if (file.Name.StartsWith(".")) continue;
                    var remoteFileName = file.Name;
                    Console.WriteLine("Downloading " + remoteFileName + "... (" + count + "/" + totalFiles + ")");
                    using (Stream localFile = File.OpenWrite(localDirectory + remoteFileName))
                    {
                        sftp.DownloadFile(directory + remoteFileName, localFile);
                    }
                    count++;
                }
            }
        }
    }
}