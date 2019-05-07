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
    public partial class frmUsuario : Form
    {
        public int _gId;

        public frmUsuario()
        {
            InitializeComponent();
            LimparComponentes();
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //--------------------------------------------------------------------
        //
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            LimparComponentes();
            CarregarGrid();
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
            _gId = (int)_Grid["id_Usuario", e.RowIndex].Value;
            _txtNome.Text = (string)_Grid["Nome", e.RowIndex].Value;
            _btn_Gravar.Tag = 1;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private void LimparComponentes()
        {
            _txtNome.Text = "";
            _btn_Gravar.Tag = 0;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private bool ValidarDados()
        {
            if (_txtNome.Text == "")
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
            string str = "INSERT INTO usuario ([id_usuario],[Nome],[Senha]) VALUES(" +
                      _id+","+
                "'" + _txtNome.Text + "','0')";
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
                Main.expressaoSQL = "SELECT MAX(Id_usuario) as ID from usuario";
                Main.comando             = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
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
        private string MontarQuery_CarregarGrid()
        {
            string str = "";
            str += "select Id_usuario, Nome from usuario order by Nome";
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarGrid()
        {
            try
            {
                Main.expressaoSQL        = MontarQuery_CarregarGrid();
                Main.comando             = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr  = Main.comando.ExecuteReader();
                //------------------CRIANDO UMA TABELA VIRTUAL ----------
                DataTable dt = new DataTable();
                dt.Columns.Add("id_usuario", typeof(int));
                dt.Columns.Add("nome"      , typeof(string));
                while (dr.Read())
                {
                    DataRow Linha = dt.NewRow();
                    Linha["id_usuario"] = dr["id_usuario"];
                    Linha["nome"]       = dr["nome"];
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
                Id = (int)_Grid["Id_usuario", linha].Value;
                if (VerificarEstrangeira(Id) == false)
                {
                    //------------ EXECUTAR A EXCLUSÃO DO REGISTRO ----------------
                    try
                    {
                        Main.expressaoSQL = MontarQuery_Exclusao(Id);
                        Main.comando             = new SqlCommand();
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
            str += "DELETE FROM USUARIO where Id_usuario = " + _Id;
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
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
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
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Alteracao(int _id)
        {
            string str = "UPDATE USUARIO SET" +
                " Nome = '" + _txtNome.Text + "' WHERE Id_usuario=" + _id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //


    }
}
