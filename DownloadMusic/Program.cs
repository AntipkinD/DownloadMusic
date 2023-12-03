using System;
using System.Net.Http;
using System.Diagnostics;
using System.Media;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

internal class Program
{
    private static async Task Main(string[] args)
    {
        bool ok = false;
        HttpClient client = new HttpClient();
        string httpath = Console.ReadLine();
        try
        {
            HttpResponseMessage response = await client.GetAsync(httpath);
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            string path = "D:/VSWorks/DownloadMusic/file1.mp3";
            await File.WriteAllBytesAsync(path, data);
            ok = true;
        }
        catch (Exception e)
        {
            e = new Exception("Неверная ссылка");
            Console.WriteLine(e.Message);
        }
        if (ok == true)
        {
            ProcessStartInfo play = new ProcessStartInfo();
            play.FileName = "cmd";
            play.Arguments = @"/c D:/VSWorks/DownloadMusic/file1.mp3";
            Process.Start(play);
        }
    }
}