using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace JBTools.IO
{
    public class FtpTranferFile
    {
        /// <summary>
        /// 從FTP下載一個指定檔案
        /// </summary>
        /// <param name="serverUri">路徑(主機[:通訊阜]/[路徑/])</param>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="targetDirectory">存放下載檔案的資料夾</param>
        /// <param name="userName">帳號(無：空字串)</param>
        /// <param name="password">密碼(無：空字串)</param>
        /// <returns>是否成功</returns>
        public static bool DownloadFileFromFTP(Uri serverUri, string fileName, string targetDirectory
            , string userName, string password)
        {
            bool returnbool = false;

            if (serverUri.Scheme != Uri.UriSchemeFtp)                           //檢查FTP路徑是否有誤
            {
                Console.WriteLine("FTP的路徑錯誤");
                throw new Exception("FTP的路徑錯誤");                           //有錯誤，丟出例外
            }

            try
            {
                Uri getFileURL = new Uri(serverUri.ToString() + fileName);      //先組合檔案的路徑
                Console.WriteLine("下載：" + getFileURL.ToString());

                //用FtpWebRequest類別下載檔案
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(getFileURL);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                if (userName != String.Empty)
                {
                    request.Credentials = new NetworkCredential(userName, password);//驗證身份
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();               //取得回應的資料流
                StreamReader reader = new StreamReader(responseStream);             //設定讀取資料流
                string fileString = reader.ReadToEnd();                             //執行讀取資料流
                File.WriteAllText(String.Format(@"{0}\{1}", targetDirectory, fileName), fileString); //存檔

                Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }

            returnbool = true;

            return returnbool;
        }

        /// <summary>
        /// 上傳一個指定檔案到FTP
        /// </summary>
        /// <param name="serverUri">路徑(主機[:通訊阜]/[路徑/])</param>
        /// <param name="fileName">上傳檔案的儲存檔名(更改檔名)</param>
        /// <param name="file">上傳的檔案</param>
        /// <param name="userName">帳號(無：空字串)</param>
        /// <param name="password">密碼(無：空字串)</param>
        /// <returns>是否成功</returns>
        public static bool UploadFileToFTP(Uri serverUri, string fileName, string file, string userName, string password)
        {
            bool returnbool = false;

            if (serverUri.Scheme != Uri.UriSchemeFtp)                           //檢查FTP路徑是否有誤
            {
                Console.WriteLine("FTP的路徑錯誤");
                throw new Exception("FTP的路徑錯誤");                           //有錯誤，丟出例外
            }

            try
            {
                Uri getFileURL = new Uri(serverUri.ToString() + fileName);      //先組合檔案的路徑
                Console.WriteLine("上傳：" + getFileURL.ToString());

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(getFileURL);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                if (userName != String.Empty)
                {
                    request.Credentials = new NetworkCredential(userName, password);    //驗證身份
                }

                StreamReader sourceStream = new StreamReader(file);                     //讀取傳送檔案
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();            //用來上傳的資料流
                requestStream.Write(fileContents, 0, fileContents.Length);       //執行寫入
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();//執行上傳及回覆訊息

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }

            return returnbool;
        }
    }
}
