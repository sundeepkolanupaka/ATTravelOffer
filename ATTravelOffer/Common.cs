using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace ATTravelOffer
{
    public class Common
    {
        public bool VerifyPassword(string l_strPlain, string l_strEncrypted)
        {
            string[] l_arrStack;
            try
            {
                if (l_strPlain != "" && l_strEncrypted != "")
                {
                    l_arrStack = l_strEncrypted.Split(':');
                    if (l_arrStack.Length != 2) return false;
                    if (MD5(l_arrStack[1] + l_strPlain) == l_arrStack[0])
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
            finally
            {
                l_arrStack = null;
            }
        }

        public string MD5(string l_strPlain)
        {

            string l_strReturn = "";
            try
            {
                l_strReturn = hashAlgoritham(l_strPlain, "MD5");

                return l_strReturn.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public string hashAlgoritham(string l_strPlain, string l_strHashName)
        {
            string l_strReturn = "";
            byte[] l_bytByte;
            System.Text.UTF8Encoding iEncode = null;
            System.Security.Cryptography.HashAlgorithm iHash = null;
            try
            {
                iEncode = new System.Text.UTF8Encoding();
                l_bytByte = iEncode.GetBytes(l_strPlain);
                iHash = System.Security.Cryptography.HashAlgorithm.Create(l_strHashName);
                l_bytByte = iHash.ComputeHash(l_bytByte);
                foreach (byte b in l_bytByte)
                {
                    l_strReturn += Microsoft.VisualBasic.Conversion.Hex(b);
                }
                return l_strReturn.ToLower();
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
            finally
            {
                iEncode = null; iHash = null; l_bytByte = null;
            }
        }
    }
}