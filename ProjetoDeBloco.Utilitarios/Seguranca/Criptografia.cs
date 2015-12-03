using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Utilitarios.Seguranca
{
    public class Criptografia
    {
        private static string _chave;        

        public static string Chave
        {
            set
            {
                _chave = value;
            }
        }

        public static string CriptografaSenha(string senhaCripto)
        {
            try
            {
                return CriptografaSenha(senhaCripto, _chave);
            }
            catch (Exception ex)
            {
                return string.Format("String errada.{0}", ex.Message);
            }
        }

        public static string DescriptografaSenha(string senhaDescripto)
        {
            try
            {
                return DescriptografaSenha(senhaDescripto, _chave);
            }
            catch (Exception ex)
            {
                return string.Format("String errada.{0}", ex.Message);
            }
        }

        public static string CriptografaSenha(string senhaCripto, string chave)
        {
            try
            {
                var objcriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = chave;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objcriptografaSenha.Key = byteHash;
                objcriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = ASCIIEncoding.ASCII.GetBytes(senhaCripto);
                return Convert.ToBase64String(objcriptografaSenha.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }


        public static string DescriptografaSenha(string strCriptografada, string chave)
        {
            try
            {
                var objdescriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = chave;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objdescriptografaSenha.Key = byteHash;
                objdescriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = Convert.FromBase64String(strCriptografada);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objdescriptografaSenha.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objdescriptografaSenha = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }

        public bool compararStrings(string num01, string num02)
        {
            if (num01.Equals(num02))
                return true;
            return false;
        }
    }
}
