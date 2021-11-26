using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Util 的摘要描述
/// </summary>

    public class Encrypt

  {

      private static string superKey = "www.jbjob.com.tw";

      private static string vectoryString = "033554436";

      private static RijndaelManaged rijndael = new RijndaelManaged();

      private static byte[] key;

      private static byte[] iv;



      private static void InitialKeyAndIV()

      {
          byte[] superKeyByte = Encoding.UTF8.GetBytes(superKey);

          byte[] vectoryStringByte = Encoding.UTF8.GetBytes(vectoryString);

          key = new byte[32];

          Array.Copy(superKeyByte, key, superKeyByte.Length);

          iv = new byte[16];

          Array.Copy(vectoryStringByte, key, vectoryStringByte.Length);
      }



      public static string EncryptInforamtion(string dataString)

      {

          UTF32Encoding utf32Encoding = new UTF32Encoding();



          if (key == null || iv == null)

          {

              InitialKeyAndIV();

          }



          Byte[] returnVal = AESEncrypt(utf32Encoding.GetBytes(dataString), rijndael.CreateEncryptor(key, iv));          
           
          return Convert.ToBase64String(returnVal);

      }



      public static string DecryptInformation(string dataString)

      {

          UTF32Encoding utf32Encoding = new UTF32Encoding();



          if (key == null || iv == null)

          {

              InitialKeyAndIV();

          }



          Byte[] returnVal = AESDencrypt(Convert.FromBase64String(dataString), rijndael.CreateDecryptor(key, iv));



          //因為加解密會對byte[]做填充，所以解完密後要去掉。

          return utf32Encoding.GetString(returnVal).Replace("\0", "");

      }



      /// <summary>

      /// AES 加密

      /// </summary>

      /// <param name="input"></param>

      /// <param name="encryptor"></param>

      /// <returns></returns>

      private static byte[] AESEncrypt(byte[] input, ICryptoTransform encryptor)

      {

          //Encrypt the data.

          MemoryStream msEncrypt = new MemoryStream();

          CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);



          //Write all data to the crypto stream and flush it.

          csEncrypt.Write(input, 0, input.Length);

          csEncrypt.FlushFinalBlock();



          //Get encrypted array of bytes.

          return msEncrypt.ToArray();

      }



      /// <summary>

      /// AES 解密

      /// </summary>

      /// <param name="input"></param>

      /// <param name="decryptor"></param>

      /// <returns></returns>

      private static byte[] AESDencrypt(byte[] input, ICryptoTransform decryptor)

      {

          //Now decrypt the previously encrypted message using the decryptor

          // obtained in the above step.

          MemoryStream msDecrypt = new MemoryStream(input);

          CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);



          byte[] fromEncrypt = new byte[input.Length];



          //Read the data out of the crypto stream.

          csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);





          return fromEncrypt;

      }

  }

