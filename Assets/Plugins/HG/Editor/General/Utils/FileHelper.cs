using System;
using System.IO;

namespace HG.General.Utils
{
    public static class FileHelper
    {
        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}