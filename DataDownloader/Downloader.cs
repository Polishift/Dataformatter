namespace DataDownloader
{
    public static class Downloader
    {
        public static void DownloadData(string localDirectory)
        {
            var ftp = new Ftp("145.24.222.117", "ubuntu-0902130", "welkom01");
            ftp.DownloadAll("ProcessedFiles/", localDirectory);
        }
    }
}