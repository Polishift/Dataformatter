namespace Dataformatter
{
    public static class Paths
    {
        public static string ProcessedDataFolder;
        public static string RawDataFolder;

        public static void SetProcessedDataFolder(string path)
        {
            ProcessedDataFolder = @path;
        }
        
        public static void SetRawDataFolder(string path)
        {
            RawDataFolder = @path;
        }
    }
}