using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Services
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filepath)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filepath);   
        }
    }
}
