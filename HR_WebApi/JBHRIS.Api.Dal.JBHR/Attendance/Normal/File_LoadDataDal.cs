using JBHRIS.Api.Dal.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class File_LoadDataDal : IFile_LoadDataDal
    {
        public string[] GetFiles(string textFileFolder, string fileExtension)
        {
            var files = System.IO.Directory.GetFiles(textFileFolder, fileExtension);
            return files;
        }
    }
}
