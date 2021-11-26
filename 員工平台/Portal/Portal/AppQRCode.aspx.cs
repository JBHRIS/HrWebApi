using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using System.Drawing.Imaging;
using Dal;
using System.Configuration;

namespace Portal
{
    public partial class AppQRCode :WebPageBase
    {


        public dcAppDataContext dcApp = new dcAppDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }



            this.txt_SetHeight.Text = "400";
            this.txt_SetWidth.Text = "400";

            //QRCode_Verification mQRCode = new QRCode_Verification();
            //mQRCode.GUID = Guid.NewGuid().ToString();
            //mQRCode.KeyDate = DateTime.Now;
            //mQRCode.KeyMan = "system";
            //dcApp.QRCode_Verification.InsertOnSubmit(mQRCode);
            //dcApp.SubmitChanges();

            //GenerateMyQCCode(mQRCode.GUID);



            

        }

        private void GenerateMyQCCode(string QCText)
        {
            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            QCwriter.Options.Height = int.Parse(this.txt_SetHeight.Text);
            QCwriter.Options.Width = int.Parse(this.txt_SetWidth.Text);





            var result = QCwriter.Write(QCText);
            string path = Server.MapPath("~/images/MyQRImage.jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imgageQRCode.Visible = true;
            imgageQRCode.ImageUrl = "~/images/MyQRImage.jpg";

        }



        



        public void Generate_QRCode_GUID()
        { 
        
            string GUID = Guid.NewGuid().ToString();

            DateTime KeyDate = DateTime.Now;






        }



        protected void btn_QRCode_Click(object sender, EventArgs e)
        {





            //QRCode_Verification mQRCode = new QRCode_Verification();
            string  GUID = this.txt_QRCode.Text;

            if (GUID == "")
            {
                GenerateMyQCCode(Guid.NewGuid().ToString());
            }
            else
            {
            
                GenerateMyQCCode(GUID);
            }
            //mQRCode.KeyDate = DateTime.Now;
            //mQRCode.KeyMan = _User.EmpId;
            //dcApp.QRCode_Verification.InsertOnSubmit(mQRCode);
            //dcApp.SubmitChanges();

            

        }

        protected void btn_QRCode_Decode_Click(object sender, EventArgs e)
        {
            BarcodeReader QCreader = new BarcodeReader();
            string QCfilename = Path.Combine(Request.MapPath
               ("~/images"), "MyQRImage.jpg");


            Bitmap bitmap = new Bitmap(QCfilename);


            Result QCresult = QCreader.Decode(bitmap);
            if (QCresult != null)
            {
                this.txt_QRCode_Decode.Text = "QR Code: " + QCresult.Text;
            }

            bitmap.Clone();

        }





        /// <summary> 
        /// RSA加密資料 
        /// </summary> 
        /// <param name="express">要加密資料</param> 
        /// <param name="KeyContainerName">密匙容器的名稱</param> 
        /// <returns></returns> 
        public static string RSAEncryption(string express, string KeyContainerName = null)
        {

            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = KeyContainerName ?? "zhiqiang"; //密匙容器的名稱，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(express);//將要加密的字串轉換為位元組陣列
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//將加密後的位元組資料轉換為新的加密位元組陣列
                return Convert.ToBase64String(encryptdata);//將加密後的位元組陣列轉換為字串
            }
        }
        /// <summary> 
        /// RSA解密資料 
        /// </summary> 
        /// <param name="express">要解密資料</param> 
        /// <param name="KeyContainerName">密匙容器的名稱</param> 
        /// <returns></returns> 
        public static string RSADecrypt(string ciphertext, string KeyContainerName = null)
        {
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = KeyContainerName ?? "zhiqiang"; //密匙容器的名稱，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return System.Text.Encoding.Default.GetString(decryptdata);
            }
        }

        public void savecode()
        { 
        
        
        }


        public void decode()
        {



            string nobr = _User.EmpId;

            DateTime dateTime = DateTime.Now;





            string encytion = RSAEncryption(nobr + dateTime.ToString());

            RSADecrypt(encytion);
            


            


        }


        public void whieare()
        {





        
        }

        





    }
}