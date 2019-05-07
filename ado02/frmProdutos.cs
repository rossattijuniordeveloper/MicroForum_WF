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
    public partial class frmProdutos : Form
    {
        int gId;

        public frmProdutos()
        {
            InitializeComponent();
            _btn_Gravar.Tag = 0;
            _txtNome.Focus();
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
        private void frmProdutos_Load(object sender, EventArgs e)
        {
            LimparComponentes();
            CarregarGrid();
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
            gId = (int)_Grid["Id_Produto", e.RowIndex].Value;
            _txtNome.Text = (string)_Grid["Nome", e.RowIndex].Value;
            _NuDo_Preco.Value = 2;// Convert.ToDouble(_Grid["Preco", e.RowIndex].Value);
            _btn_Gravar.Tag = 1;
            _txtNome.Focus();
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
                Id = (int)_Grid["Id_Produto", linha].Value;
                if (VerificarEncomendas(Id) == false)
                {
                    //------------ EXECUTAR A EXCLUSÃO DO REGISTRO ----------------
                    try
                    {
                        Main.expressaoSQL = MontarQuery_Exclusao(Id);
                        Main.comando = new SqlCommand();
                        Main.comando.CommandText = Main.expressaoSQL;
                        Main.comando.Connection = Main.Ligacao;
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
        private bool VerificarEncomendas(int _Id)
        {
            bool retorno = false;
            try
            {
                Main.expressaoSQL = MontarQuery_VerificarEncomenda(_Id);
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
                MessageBox.Show("Em [VerificarEncomendas] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;

            }
            //Main.Ligacao.Close();
            if (retorno == true)
            {
                MessageBox.Show("O PRODUTO NÃO PODE SER APAGADO, POIS ELE ESTÁ CONTIDO EM ENCOMENDAS!");
            }
            return retorno;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_VerificarEncomenda(int _Id)
        {
            string str = "";
            str += "select id_encomenda FROM encomendas where Id_Produto=" + _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CalcularRegistros()
        {
            _lbl_Registros.Text = "Registros.: " + _Grid.Rows.Count.ToString();
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
        private void CarregarGrid()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_CarregarGrid();
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                //------------------CRIANDO UMA TABELA VIRTUAL ----------
                DataTable dt = new DataTable();
                dt.Columns.Add("Id_Produto", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Preco", typeof(Double));
                while (dr.Read())
                {
                    DataRow Linha = dt.NewRow();
                    Linha["Id_Produto"] = dr["Id_Produto"];
                    Linha["Nome"]       = dr["Nome"];
                    Linha["Preco"]      = dr["Preco"];
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
        private int RetornarNovoId()
        {
            int id = -1;
            try
            {
                //----------  PREPARANDO O ID DO NOVO REGISTRO -------------
                Main.expressaoSQL = "SELECT MAX(Id_Produto) as ID from Produtos";
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                object UltimoID = Main.comando.ExecuteScalar();
                if (UltimoID == DBNull.Value)
                {

                    id = 1;
                }
                else
                {
                    id = (int)UltimoID + 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Em [RetornarNovoId] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Main.comando.Connection.Close();
            return id;
        }
        //
        //--------------------------------------------------------------------
        //
        private void GravarInclusao()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_Inclusao(RetornarNovoId());
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
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
        private void LimparComponentes()
        {
            _txtNome.Text = "";
            _NuDo_Preco.Value = 2;
            _btn_Gravar.Tag = 0;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private bool ValidarDados()
        {
            if ((_NuDo_Preco.Value <= 0) || (_txtNome.Text == ""))
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
        private void GravarAlteracao()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_Alteracao(gId);
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
        private string MontarQuery_Alteracao(int _id)
        {
            string str = "UPDATE PRODUTOS SET" +
                " Nome = '" + _txtNome.Text + "' " +
                ",Preco = '" + _NuDo_Preco.Value.ToString() + "' WHERE id_produto=" + _id;

            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Exclusao(int _Id)
        {
            string str = "";
            str += "DELETE FROM PRODUTOS where Id_Produto=" + _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Inclusao(int _id)
        {
            string str = "INSERT INTO Produtos ([Nome],[Preco]) VALUES(" +
                "'" + _txtNome.Text + "', " +
                "'" + _NuDo_Preco.Value.ToString() + "')";
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarGrid()
        {
            string str = "";
            str += "select Id_Produto, Nome, Preco from Produtos order by Nome";
            return str;
        }
        //
        //--------------------------------------------------------------------
        //

    }
}
