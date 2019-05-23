using System;
using System.Threading.Tasks;
using System.IO;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\User\Desktop\Maga";
            string fileName = "Maga.docx";
            string fileNameCopy = "MagaCopy.docx";

            string sourceFile = Path.Combine(path, fileName);
            string destFile = Path.Combine(path, fileNameCopy);

            Console.WriteLine("Starting copy... ");
            CopyPercent(sourceFile, destFile);
            Console.WriteLine("The end !!");
        }

        /// <summary>
        /// Copy file
        /// </summary>
        /// <param name="soureceFile"> Source file </param>
        /// <param name="destFile"> Copy file </param>
        static public async void CopyPercent(string soureceFile, string destFile)
        {
            using (FileStream readStream = File.OpenRead(soureceFile))
            using (FileStream writeStream = File.OpenWrite(destFile))
            {
                byte[] buffer = new byte[1 * 1];
                int bytesRead;
                string old = "0";
                
                while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    string progress = await Percentage(writeStream.Length, readStream.Length);
                    
                    if (progress != old)
                    {
                        Console.WriteLine("Progress: {0} %", progress);
                        old = progress;
                    }
                }
            }
        }
        /// <summary>
        /// Calculate how many percent has been copied
        /// </summary>
        /// <param name="writeStreamLength"> Source file size</param>
        /// <param name="readStreamLength"> Current file size</param>
        /// <returns></returns>
        static async private Task<string> Percentage(long writeStreamLength, long readStreamLength)
        {
            await Task.Delay(0);
            return ((writeStreamLength * 100) / readStreamLength).ToString();        
        }
    }
}
