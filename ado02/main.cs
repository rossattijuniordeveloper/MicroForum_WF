using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ado02
{
    public static class Main
    {
        // variaveis globais
        //---------------------------------------------------------
        //        
        public static string pastaBD;
        public static string nomeBD;
        public static string strCnx;
        public static SqlConnection Ligacao;
        public static SqlCommand comando;
        public static string expressaoSQL;

        //
        //---------------------------------------------------------
        //
        public static void IniciarVariaveis()
        {
            strCnx = "Data Source=DESKTOP-1SO8CFA\\SQLEXPRESS01;Initial Catalog=teste;Integrated Security=True";
            expressaoSQL = "";
            Ligacao = new SqlConnection(strCnx);
        }

    }


}
