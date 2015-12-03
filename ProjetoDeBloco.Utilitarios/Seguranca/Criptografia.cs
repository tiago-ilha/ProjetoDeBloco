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
        public static string CriptografaSenha(string senha)
        {
            try
            {
                MD5 md5Hash = MD5.Create();
                // Converter a String para array de bytes, que é como a biblioteca trabalha.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Cria-se um StringBuilder para recompôr a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop para formatar cada byte como uma String em hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
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
