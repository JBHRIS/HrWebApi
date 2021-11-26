using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JBHR
{
    public class PhotoService
    {
        public static void SavePhoto(string Nobr, string PhotoStream)
        {

        }
        public static byte[] GetPhotoByNobr(string Nobr)
        {
            try
            {
                JBHRService.JbhrServiceClient srv = new JBHRService.JbhrServiceClient();
                var bs = srv.GetEmpPhoto(Nobr);
                return bs;
            }
            catch
            {
                return null;
            }
        }

    }
}
