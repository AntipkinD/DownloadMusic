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
        await Console.Out.WriteLineAsync("Введите (вставьте) ссылку на скачивание песни");
        string httpath = Console.ReadLine();
        try
        {
            string path = $"D:/VSWorks/DownloadMusic/file{0}.mp3";
            File.Delete(path);
            HttpResponseMessage response = await client.GetAsync(httpath);
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(path, data);
            ok = true;
            await Console.Out.WriteLineAsync("Песня успешно загружена");
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
            play.Arguments = @$"/c D:/VSWorks/DownloadMusic/file{0}.mp3";
            Process.Start(play);
        }
    }
}