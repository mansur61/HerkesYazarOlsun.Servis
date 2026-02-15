using System.Runtime.InteropServices;

namespace HerkesYazarOlsun.BLL.Helper
{
    public static class LogHelper
    {
        public static void log(string path, string message)
        {
            bool containsLog = path.IndexOf("log", StringComparison.OrdinalIgnoreCase) >= 0;

            string baseDirectory = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? (containsLog ? "C:\\" : "C:\\log")
                : (containsLog ? Environment.CurrentDirectory : Path.Combine(Environment.CurrentDirectory, "log"));

            string fullPath = Path.Combine(baseDirectory, path.TrimStart('\\', '/').Replace("\\", "/"));

            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using StreamWriter sw = new StreamWriter(fullPath, true);
            sw.WriteLine($"{DateTime.Now} ___ {message}");
            sw.Close();
        }

        public static string logToTxtFolderWithGuid(string folder, string message)
        {
            string driver = "C:\\log";
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                driver = Path.Combine(Environment.CurrentDirectory, "log");
            }

            var result = Guid.NewGuid().ToString();
            string path = Path.Combine(driver, folder, DateTime.Now.ToShortDateString().Replace(".", ""));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path, $"{result}.txt");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString()} ___ {message}");
            }

            return result;
        }
    }
}
