using System;
using System.IO;
using System.Linq;

namespace UninstallTools.Junk.WindowsCleaner
{
    public static class SystemCleaner
    {
        public static void CleanTempFiles()
        {
            CleanDirectory(Path.GetTempPath());
            CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp"));
        }

        public static void CleanPrefetch()
        {
            CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch"));
        }

        public static void CleanUpdateCache()
        {
            CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution", "Download"));
        }

        private static void CleanDirectory(string path)
        {
            if (!Directory.Exists(path)) return;

            var dir = new DirectoryInfo(path);

            foreach (var file in dir.GetFiles())
            {
                try { file.Delete(); } catch { /* Ignore locked files */ }
            }
            foreach (var subdir in dir.GetDirectories())
            {
                try { subdir.Delete(true); } catch { /* Ignore locked folders */ }
            }
        }
    }
}
