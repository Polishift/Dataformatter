using System;
using System.IO;

namespace DataDownloader
{
    public static class Downloader
    {
        public static void DownloadData(string localDirectory)
        {
            var ftp = new Ftp("145.24.222.117", "ubuntu-0902130", "welkom01");

            var serverCount = ftp.GetAmountOfFiles("ProcessedFiles/");
            var localCount = Directory.GetFiles(localDirectory).Length;

            Console.WriteLine(serverCount + " / " + localCount);

            if (serverCount == localCount)
                return;

            Console.WriteLine("Start downloading");
            ftp.DownloadAll("ProcessedFiles/", localDirectory);
            Console.WriteLine("Finished downloading");
        }
    }
}