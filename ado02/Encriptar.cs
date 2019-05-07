using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

//
//--------------------------------------------------------------------
//


namespace ado02
{
    class Encriptar
    {
        //
        //--------------------------------------------------------------------
        //
        public string CriarMD5(string _senhaOriginal)
        {
            MD5 encriptador = MD5.Create();
            byte[] inicial = Encoding.ASCII.GetBytes(_senhaOriginal);
            byte[] final = encriptador.ComputeHash(inicial);

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < final.Length; i++)
            {
                str.Append(final[i].ToString("X2"));
            }
            return str.ToString();
        }
        //
        //--------------------------------------------------------------------
        //


    }
}
