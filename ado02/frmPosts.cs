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
    public partial class frmPosts : Form
    {
        public int _gId;

        public frmPosts()
        {
            InitializeComponent();
            CarregarUsuarios();            
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Gravar_Click(object sender, EventArgs e)
        {
            if ((int)_btn_Gravar.Tag == 0)
            {
                if (ValidarDados())
                {
                    GravarInclusao();
                }
            }
            else
            {
                GravarAlteracao();
            }
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparComponentes();
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Apagar_Click(object sender, EventArgs e)
        {
            ApagarRegistros();

        }
        //
        //--------------------------------------------------------------------
        //
        private void _Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _gId              = (int)_Grid["id_posts", e.RowIndex].Value;
            _txtNome.Text     = (string)_Grid["titulo", e.RowIndex].Value;
            _txtMensagem.Text = (string)_Grid["mensagem", e.RowIndex].Value;
            _btn_Gravar.Tag = 1;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private void frmPosts_Load(object sender, EventArgs e)
        {
            LimparComponentes();            
        }
        //
        //--------------------------------------------------------------------
        //
        private void LimparComponentes()
        {
            _txtNome.Text     = "";
            _txtMensagem.Text = "";
            _btn_Gravar.Tag   = 0;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private bool ValidarDados()
        {
            if( (_txtNome.Text == "") || (_txtMensagem.Text==""))
            {
                MessageBox.Show("Preencha completamente todos os campos!",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarGrid(int _id)
        {
            string str = "";
            str += "select p.titulo,p.mensagem,p.id_posts,p.atualizacao from posts as p ";
            //str += " left outer join usuario as usu ON usu.id_usuario = p.id_usuario";
            str += " WHERE p.id_usuario=" + _id;
            str += " ORDER BY p.atualizacao desc";

            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarGrid()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_CarregarGrid(RetornarIdUsuario(_cmb_Usuarios.Text));
                Main.comando             = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                //------------------CRIANDO UMA TABELA VIRTUAL ----------
                DataTable dt = new DataTable();
                dt.Columns.Add("id_posts" , typeof(int));
                dt.Columns.Add("titulo"   , typeof(string));
                dt.Columns.Add("mensagem" , typeof(string));
                while (dr.Read())
                {
                    DataRow Linha = dt.NewRow();
                    Linha["id_posts"]   = dr["id_posts"];
                    Linha["titulo"]     = dr["titulo"];
                    Linha["mensagem"]   = dr["mensagem"];
                    dt.Rows.Add(Linha);
                }
                _Grid.DataSource = dt;
                _Grid.Columns[0].Visible = false;
                Main.comando.Connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Em [CarregarGrid] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularRegistros();
        }
        //
        //--------------------------------------------------------------------
        //
        private void CalcularRegistros()
        {
            if (_Grid.Rows.Count > 1)
            {
                _btn_Apagar.Enabled = true;
            }
            else
            {
                _btn_Apagar.Enabled = false;
            }
        }
        //
        //--------------------------------------------------------------------
        //
        private void ApagarRegistros()
        {
            if (
                (_Grid.Rows.Count > 1) &&
                MessageBox.Show(
                    "Deseja APAGAR o registro ?",
                    "Apagar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                int Id = -1;
                int linha = -1;
                linha = _Grid.SelectedRows[0].Index;
                Id = (int)_Grid["Id_posts", linha].Value;
                //if (VerificarEstrangeira(Id) == false)
                if(true)
                {
                    //------------ EXECUTAR A EXCLUSÃO DO REGISTRO ----------------
                    try
                    {
                        Main.expressaoSQL = MontarQuery_Exclusao(Id);
                        Main.comando      = new SqlCommand();
                        Main.comando.CommandText = Main.expressaoSQL;
                        Main.comando.Connection  = Main.Ligacao;
                        Main.comando.Connection.Open();
                        Main.comando.ExecuteNonQuery();
                        Main.comando.Connection.Close();
                        CarregarGrid();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Em [ApagarRegistros] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                            "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Exclusao(int _Id)
        {
            string str = "";
            str += "DELETE FROM posts where Id_posts="+ _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private bool VerificarEstrangeira(int _Id)
        {
            bool retorno = false;
            try
            {
                Main.expressaoSQL = MontarQuery_VerificarEstrangeira(_Id);
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while ((dr.Read()))
                {
                    retorno = true;
                }
                Main.comando.Connection.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Em [VerificarEstrangeira] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;

            }
            if (retorno == true)
            {
                MessageBox.Show("O USUARIO NÃO PODE SER APAGADO, POIS ELE TEM POSTS");
            }
            return retorno;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_VerificarEstrangeira(int _Id)
        {
            string str = "";
            str += "select id_usuario FROM posts where Id_usuario=" + _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        //
        //--------------------------------------------------------------------
        //
        private void GravarAlteracao()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_Alteracao(_gId);
                Main.comando      = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.Connection.Open();
                Main.comando.ExecuteNonQuery();
                Main.comando.Connection.Close();
                CarregarGrid();
                LimparComponentes();
            }
            catch (Exception)
            {
                MessageBox.Show("Em [GravarAlteracao] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Alteracao(int _id)
        {
            string str = "UPDATE posts SET" +
                " titulo = '" + _txtNome.Text +
                "', mensagem = '"+_txtMensagem.Text +
                "' WHERE Id_posts=" + _id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void GravarInclusao()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_Inclusao(RetornarNovoId());
                Main.comando      = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.Connection.Open();
                Main.comando.ExecuteNonQuery();
                Main.comando.Connection.Close();
                LimparComponentes();
                CarregarGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro de Gravação , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _txtNome.Focus();
            }
            Main.comando.Connection.Close();
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Inclusao(int _id)
        {
            string str = "INSERT INTO posts ([id_posts],[id_usuario],[titulo],[mensagem]) VALUES(" +
            _id + "," +
            RetornarIdUsuario(_cmb_Usuarios.Text) + "," +
            "'" + _txtNome.Text + "'," +
            "'" + _txtMensagem.Text + "')";            
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornarNovoId()
        {
            int _id = -1;
            try
            {
                //----------  PREPARANDO O ID DO NOVO REGISTRO -------------
                Main.expressaoSQL = "SELECT MAX(id_posts) as ID from posts";
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                object UltimoID = Main.comando.ExecuteScalar();
                if (UltimoID == DBNull.Value)
                {
                    _id = 1;
                }
                else
                {
                    _id = (int)UltimoID + 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Em [RetornaNovoId] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Main.comando.Connection.Close();
            return _id;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarUsuarios()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_CarregarUsuarios();
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                    _cmb_Usuarios.Items.Add(dr["Nome"]);                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Main.comando.Connection.Close();
            _cmb_Usuarios.SelectedIndex = 0; //.Items.[0];
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarUsuarios()
        {
            return "SELECT Nome FROM usuario order by nome";
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornarIdUsuario(String _Nome)
        {
            int _id = -1;
            try
            {
                Main.expressaoSQL = "SELECT Id_usuario from usuario where Nome ='"
                     + _Nome + "'"; ;
                Main.comando = new SqlCommand();
                Main.comando.Connection = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                    _id = (int)dr["Id_usuario"];
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Em [RetornarIdusuarios] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cmb_Usuarios.Focus();
            }
            Main.comando.Connection.Close();
            return _id;
        }
        //
        //--------------------------------------------------------------------
        //
        private void _cmb_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void _btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //--------------------------------------------------------------------
        //


    }
}
