using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ado02
{
    public partial class frmMain : Form
    {
        // --------- DECLARAÇÃO DE VARIAVEIS GLOBAIS ------


        // -------------- EVENTOS DOSCOMPONENTES -------------------------
        public frmMain()
        {            
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        //
        // -------------- METODOS CUSTOMIZADOS -------------------------
        //
        //--------------------------------------------------------------------
        //
        //
        //--------------------------------------------------------------------
        //
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //--------------------------------------------------------------------
        //
        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario formUsuario = new frmUsuario();
            formUsuario.ShowDialog();
        }
        //
        //--------------------------------------------------------------------
        //
        private void postagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPosts formPostagens = new frmPosts();
            formPostagens.ShowDialog();

        }
        //
        //--------------------------------------------------------------------
        //
    }
}
