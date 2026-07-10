using System;
using Klocman.Tools;

namespace BulkCrapUninstaller.Functions.Tracking
{
    public class DatabaseStatSender
    {
        private readonly ulong userId;

        public DatabaseStatSender(ulong userId)
        {
            this.userId = userId;
        }

        public bool SendData(string value)
        {
            try
            {
                var compressed = CompressionTools.BrotliCompress(value);

                using var s = Program.HomeServerClient;
                var response = s.PostAsync(new Uri($"SendStats?userId={userId}&data={Convert.ToBase64String(compressed)}", UriKind.Relative), null!).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to send stats: " + e);
                return false;
            }
            return true;
        }
    }
}
