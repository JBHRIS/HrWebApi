using ICSharpCode.SharpZipLib.Zip;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace JBHRIS.Api.Tools.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializationHelper
    {
        /// 
        /// 將傳入的字串以GZip演算法壓縮後，傳回Base64編碼字串
        /// 
        /// 要壓縮的字串
        /// 壓縮後的字串(Base64)
        public static string GZipCompressString(string rawString)
        {
            if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rawString.ToString());
                byte[] zippedData = Compress(rawData);
                return (string)(Convert.ToBase64String(zippedData));
            }
        }

        //GZip壓縮
        private static byte[] Compress(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }

        /// 
        /// 將傳入的二進位字串資料以GZip演算法解壓縮
        /// 
        /// 傳入經GZip壓縮後的二進位字串資料
        /// 傳回原後的未壓縮原始字串資料
        public static string GZipDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
            }
        }

        //GZip解壓縮
        private static byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                {
                    break;
                }
                else
                {
                    outBuffer.Write(block, 0, bytesRead);
                }
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }

        #region ISerializationHelper 

        /// <summary>
        /// 
        /// </summary>
        public static byte[] Serialize2Bytes(object data)
        {
            if (data == null)
            {
                return new byte[0];
            }
            else
            {
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(streamMemory, data);
                return streamMemory.GetBuffer();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static object DeserializeFromBytes(byte[] binData)
        {
            if (binData == null)
            {
                return null;
            }
            else
            {
                if (binData.Length == 0)
                {
                    return null;
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(binData);
                    return formatter.Deserialize(ms);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Serialize2String(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            else
            {
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(streamMemory, data);
                return Convert.ToBase64String(streamMemory.GetBuffer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static object DeserializeFromString(string binString)
        {
            if (binString == null)
            {
                return null;
            }
            else
            {
                if (binString.Length == 0)
                {
                    return null;
                }
                else
                {
                    byte[] binData = Convert.FromBase64String(binString);
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(binData);
                    return formatter.Deserialize(ms);
                }
            }
        }

        #endregion

        #region

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Zip1(string str)
        {
            // remove whitespace from xml and convert to byte array
            byte[] normalBytes = Encoding.UTF8.GetBytes(str);

            // zip into new, zipped, byte array
            using (Stream memOutput = new MemoryStream())
            using (ZipOutputStream zipOutput = new ZipOutputStream(memOutput))
            {
                zipOutput.SetLevel(9);

                ZipEntry entry = new ZipEntry(Guid.NewGuid().ToString());
                entry.DateTime = DateTime.Now;
                zipOutput.PutNextEntry(entry);

                zipOutput.Write(normalBytes, 0, normalBytes.Length);
                zipOutput.Finish();

                byte[] newBytes = new byte[memOutput.Length];
                memOutput.Seek(0, SeekOrigin.Begin);
                memOutput.Read(newBytes, 0, newBytes.Length);

                zipOutput.Close();

                return newBytes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Unzip1(byte[] bytes)
        {
            // unzip bytes into unzipped byte array
            using (Stream memInput = new MemoryStream(bytes))
            using (ZipInputStream input = new ZipInputStream(memInput))
            {
                ZipEntry entry = input.GetNextEntry();

                byte[] newBytes = new byte[entry.Size];
                int count = input.Read(newBytes, 0, newBytes.Length);
                if (count != entry.Size)
                {
                    throw new Exception("Invalid read: " + count);
                }

                // convert bytes to string, then to xml
                return Encoding.UTF8.GetString(newBytes);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 設置當前流的位置為流的開始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// 將 byte[] 轉成 Stream
        /// </summary>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - -
        * Stream 和 檔之間的轉換
        * - - - - - - - - - - - - - - - - - - - - - - - */
        /// <summary>
        /// 將 str 經過壓縮 寫入檔
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fileName"></param>
        /// <param name="UploadFileSetInfo"></param>
        public static void StringToFile(string str, string fileName, UploadFileSetInfoRow UploadFileSetInfo)
        {
            bool UploadValid = UploadFileSetInfo.UploadValid;
            string UploadPath = UploadFileSetInfo.UploadPath;
            string UploadDomain = UploadFileSetInfo.UploadDomain;
            string UploadUserID = UploadFileSetInfo.UploadUserID;
            string UploadPassword = UploadFileSetInfo.UploadPassword;

            Auth oAuth = new Auth();

            if (UploadValid)
                oAuth.ImpersonateUser(UploadDomain, UploadUserID, UploadPassword);
            {
                try
                {
                    byte[] bytes = Zip(str);

                    // 把 byte[] 寫入檔
                    FileStream fs = new FileStream(@UploadPath + fileName, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(bytes);
                    bw.Close();
                    fs.Close();
                }
                catch { }

                if (UploadValid)
                    oAuth.undoImpersonation();
            }
        }

        /// <summary>
        /// 將 str 經過壓縮 寫入檔
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fileName"></param>
        /// <param name="UploadPath"></param>
        public static void StringToFile(string str, string fileName, string UploadPath)
        {
            try
            {
                //string a= Environment.UserName;




                byte[] bytes = Zip(str);
                // 把 byte[] 寫入檔
                // File.WriteAllBytes(System.Web.Hosting.HostingEnvironment.MapPath(@UploadPath) + fileName, bytes);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 將 byte[] 寫入檔
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        public static void BytesToFile(byte[] bytes, string fileName)
        {
            // 把 byte[] 寫入檔
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 將 Stream 寫入檔
        /// </summary>
        public static void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 轉換成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 設置當前流的位置為流的開始
            stream.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 寫入檔
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 從檔讀取 Stream
        /// </summary>
        public static Stream FileToStream(string fileName)
        {
            // 打開檔
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 讀取檔的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 轉換成 Stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 從檔讀取 Stream
        /// </summary>
        public static string FileToString(string fileName, UploadFileSetInfoRow UploadFileSetInfo)
        {
            bool UploadValid = UploadFileSetInfo.UploadValid;
            string UploadPath = UploadFileSetInfo.UploadPath;
            string UploadDomain = UploadFileSetInfo.UploadDomain;
            string UploadUserID = UploadFileSetInfo.UploadUserID;
            string UploadPassword = UploadFileSetInfo.UploadPassword;

            string file = "";
            string FileName = @UploadPath + fileName;

            Auth oAuth = new Auth();

            if (UploadValid)
            {
                oAuth.ImpersonateUser(UploadDomain, UploadUserID, UploadPassword);
            }
            string message = "";

            {
                try
                {
                    if (System.IO.File.Exists(FileName))
                    {
                        // 打開檔
                        FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        // 讀取檔的 byte[]
                        byte[] bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);
                        fileStream.Close();

                        file = Unzip(bytes);
                    }

                    if (UploadValid)
                    {
                        oAuth.undoImpersonation();
                    }
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                }
            }
            return file;
        }

        /// <summary>
        /// 從檔讀取 Stream
        /// </summary>
        public static string FileToString(string fileName, string UploadPath)
        {
            string file = "";

            try
            {
                // string FileName = System.Web.Hosting.HostingEnvironment.MapPath(@UploadPath) + fileName;
                //file = File.ReadAllText(FileName);
            }
            catch (Exception ex)
            {
            }

            return file;
        }

        /// <summary>
        /// 請求
        /// </summary>
        /// <param name="Path">目標路徑</param>
        /// <param name="Method">請求方法(GET|POST)</param>
        /// <param name="Passdata">請求時發送的數據</param>
        /// <param name="Token">相關驗證</param>
        /// <param name="Headers">Header</param>
        /// <param name="ContentType">ContentType</param>
        /// <param name="ErrorCollect">回傳錯誤訊息</param>
        /// <returns>static</returns>
        public static List<T> HttpRequest<T>(string Path, string Method, string Passdata, string Token, Dictionary<string, string> Headers, string ContentType, ref ErrorCollectionRow ErrorCollect)
        {
            List<T> jsonResult = new List<T>();

            try
            {
                string result = string.Empty;

                // 設置參數
                HttpWebRequest request = WebRequest.Create(Path) as HttpWebRequest;
                request.Method = Method;
                request.AllowAutoRedirect = false; // 禁止重新導向網頁
                request.Timeout = 10000; //逾時時間
                request.KeepAlive = false; // 每次 HTTP request 就會是新的連線，避免遠端連線關閉，但可能會比較耗資源。
                foreach (var dc in Headers)
                {
                    request.Headers.Add(dc.Key, dc.Value);
                }
                request.ContentType = ContentType;
                //request.ContentType = "application/json";
                //request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

                //傳入參數
                if (!string.IsNullOrEmpty(Passdata))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(Passdata);
                    request.ContentLength = byteArray.Length;

                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }

                // 拿回資料
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                result = reader.ReadToEnd();

                                jsonResult = JsonConvert.DeserializeObject<List<T>>(result, new IsoDateTimeConverter());
                            }
                        }
                    }
                    else //error handle
                    {
                        ErrorCollect.ErrorType = "Http";
                        ErrorCollect.Code = (response.StatusCode).ToString();
                        ErrorCollect.Description = response.StatusDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                //ERROR 紀錄

                if (ex is WebException)
                {
                    HttpWebResponse res = (HttpWebResponse)((WebException)ex).Response;
                    ErrorCollect.ErrorType = "Http";
                    ErrorCollect.Code = (res?.StatusCode)?.ToString();
                    ErrorCollect.Description = res?.StatusDescription;
                }
                else
                {
                    ErrorCollect.ErrorType = "Exception";
                    ErrorCollect.Message = (ex.Message).ToString();
                }
                //return (ex.Message).ToString();
            }

            return jsonResult;
        }
    }
}
