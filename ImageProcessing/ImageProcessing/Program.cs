using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImageProcessing
{
    class Program
    {
        static bool done = false;
        // forlder path on disk
        static string imageResourcesPath = @"C:\Users\User\Desktop\peony";
        static void Main(string[] args)
        {
            string[] url = {"https://cdn.pixabay.com/photo/2016/09/01/10/23/image-1635747_960_720.jpg",
                            "https://www.what-dog.net/Images/faces2/scroll0015.jpg"};
            for (int i = 0; i < url.Length; i++)
            {
                string filename = Path.GetFileName(url[i]);

                DownloadImage(url[i]).ContinueWith(downloadTask =>
                {
                    var origImageBytes = downloadTask.Result;
                    string origImagePath = Path.Combine(imageResourcesPath, filename);
                    SaveImage(origImageBytes, origImagePath).ContinueWith(saveTask =>
                    {
                        Task<byte[]> blurTask = BlurImage(origImagePath);
                        var blurredImageBytes = blurTask.Result;
                        var blurredFileName = $"{Path.GetFileNameWithoutExtension(filename)}_blurred.jpg";
                        var blurredImagePath = Path.Combine(imageResourcesPath, blurredFileName);

                        Task[] tasks = new Task[i];
                        for (int t = 0; t < tasks.Length; t++)
                        {
                            tasks[t] = SaveImage(blurredImageBytes, blurredImagePath);

                        }

                        Task.WhenAll(tasks).ContinueWith(task =>
                        {

                            done = true;
                        });
                    });
                });
            }

            //Task<byte[]> downloadtask = DownloadImage(url);
            //var imageBytes = downloadtask.Result;
            //string origImagePath = Path.Combine(imageResourcesPath, filename);
            //SaveImage(imageBytes, origImagePath);

            //Task<byte[]> blureTask = BlurImage(origImagePath);
            //byte[] blurredImageBytes = blureTask.Result;
            //var blurredFileName = $"{Path.GetFileNameWithoutExtension(filename)}_blurred.jpg";
            //var blurredImagePath = Path.Combine(imageResourcesPath, blurredFileName);
            //SaveImage(blurredImageBytes, blurredImagePath);

            while (!done)
            {
                Console.CursorLeft = 0;
                Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
                Thread.Sleep(50);
            }

            Console.WriteLine("\nDone!");

            Console.WriteLine("\nHit Enter to exit the program...");
            Console.Read();
        }

        static Task<byte[]> DownloadImage(string url)
        {
            var client = new HttpClient();
            return client.GetByteArrayAsync(url);
        }

        static Task<byte[]> BlurImage(string imagePath)
        {
            return Task.Run(() =>
            {
                IImageDecoder decoder = new SixLabors.ImageSharp.Formats.Png.PngDecoder();
                var image = Image.Load(imagePath);
                image.Mutate(ctx => ctx.GaussianBlur());
                using (var memoryStream = new MemoryStream())
                {
                    image.SaveAsJpeg(memoryStream);
                    return memoryStream.ToArray();
                }
            });
        }

        static Task SaveImage(byte[] bytes, string imagePath)
        {
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
            return Task.FromResult<object>(null);
        }
    }
}
