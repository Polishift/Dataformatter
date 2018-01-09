using System.IO;
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

        public void DownloadAll(string directory, string localDirectory)
        {
            using (var sftp = new SftpClient(_host, _user, _pass))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(directory);

                foreach (var file in files)
                {
                    if (file.Name.StartsWith(".")) continue;
                    var remoteFileName = file.Name;
                    using (Stream file1 = File.OpenWrite(localDirectory + remoteFileName))
                    {
                        sftp.DownloadFile(directory + remoteFileName, file1);
                    }
                }
            }
        }
    }
}