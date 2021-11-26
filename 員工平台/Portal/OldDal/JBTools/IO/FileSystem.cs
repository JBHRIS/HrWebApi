using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace JBTools.IO
{
    public class FileSystem
    {
        public static void CheckPath(string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }
        public static bool IsOpenedFile(string file)
        {
            bool result = false;
            try
            {
                FileStream fs = File.OpenWrite(file);
                fs.Close();
            }
            catch (Exception ex)
            {
                result = true;
            }

            return result;
        }
    }
}
