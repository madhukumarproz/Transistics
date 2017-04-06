using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;

namespace Project_Transport 
{
   public class SecureMessage
    {

        public static string Encrupt(string toencrypt, bool usehasing)
        {
            byte[] keyarray; 
            byte[] encryptarray = UTF8Encoding.UTF8.GetBytes(toencrypt);
            System.Configuration.AppSettingsReader apreader = new AppSettingsReader();
            string key=(string)apreader.GetValue("securitykey",typeof(string));
            if (usehasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else

                keyarray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyarray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ict = tdes.CreateEncryptor();
            byte[] result = ict.TransformFinalBlock(encryptarray, 0, encryptarray.Length);
            tdes.Clear();
                return Convert.ToBase64String(result, 0, result.Length);
                
            
           
        }
        public static string Decrypt(string cyperstring, bool usehasing)
        {
            byte[] keyarray;
            byte[] decrypt = Convert.FromBase64String(cyperstring);
            System.Configuration.AppSettingsReader apreader = new AppSettingsReader();
            string key = (string)apreader.GetValue("securitykey", typeof(string));
            if (usehasing)
            {
               MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
               keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            
                keyarray=UTF8Encoding.UTF8.GetBytes(key);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyarray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform ict = tdes.CreateDecryptor();
                byte[] result = ict.TransformFinalBlock(decrypt, 0, decrypt.Length);
               tdes.Clear();
                return UTF8Encoding.UTF8.GetString(result);
            
            

        }





    }
}
