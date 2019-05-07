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
    public partial class frmClientes : Form
    {
        int gId_cliente;

        public frmClientes()
        {
            InitializeComponent();
            _btn_Gravar.Tag = 0;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private void LimparComponent()
        {
            _txtCEP.Text    = "";
            _txtMorada.Text = "";
            _txtNome.Text = "";
            _txtTelefone.Text = "(0xx65)";
            _btn_Gravar.Tag = 0;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private bool ValidarDados()
        {
            if( (_txtCEP.Text=="") || (_txtMorada.Text=="") || (_txtNome.Text==""))
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
                Main.expressaoSQL = MontarQuery_Inclusao(RetornaNovoIdClientes());
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                Main.comando.ExecuteNonQuery();
                Main.comando.Connection.Close();
                LimparComponent();
                CarregarGridClientes();
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
        private string MontarQuery_Inclusao(int _id_cliente)
        {            
            string str = "INSERT INTO clientes ([Nome],[Morada],[Telefone],[Cep]) VALUES(" +
                "'"  + _txtNome.Text     + "', " +
                "'"  + _txtMorada.Text   + "', " +
                "'"  + _txtTelefone.Text + "', " +
                "'"  + _txtCEP.Text      + "')";
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornaNovoIdClientes()
        {
            int id_cliente = -1;
            try
            {
                //----------  PREPARANDO O ID DO NOVO REGISTRO -------------
                Main.expressaoSQL = "SELECT MAX(Id_cliente) as chave from clientes";
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                object UltimoID = Main.comando.ExecuteScalar();
                if (UltimoID == DBNull.Value)
                {

                    id_cliente = 1;
                }
                else
                {
                    id_cliente = (int)UltimoID + 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Em [RetornaNovoIdClientes] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Main.comando.Connection.Close();
            return id_cliente;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarGrid()
        {
            string str = "";
            str += "select Id_Cliente, Nome, Morada, Cep,Telefone from Clientes order by Nome";            
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarGridClientes()
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
                dt.Columns.Add("id_cliente", typeof(int));                
                dt.Columns.Add("nome"      , typeof(string));
                dt.Columns.Add("morada"    , typeof(string));
                dt.Columns.Add("cep"       , typeof(string));
                dt.Columns.Add("Telefone"  , typeof(string));                
                while (dr.Read())
                {
                    DataRow Linha = dt.NewRow();
                    Linha["id_cliente"] = dr["id_cliente"];
                    Linha["nome"]       = dr["nome"];
                    Linha["morada"]     = dr["morada"];
                    Linha["cep"]        = dr["cep"];
                    Linha["Telefone"]   = dr["Telefone"];
                    dt.Rows.Add(Linha);                    
                }
                _Grid.DataSource = dt;
                _Grid.Columns[0].Visible = false;
                Main.comando.Connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Em [CarregarGridClientes] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularRegistros();
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
                Id = (int)_Grid["Id_cliente", linha].Value;
                if(VerificarEncomendas(Id)==false)
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
                        CarregarGridClientes();
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
            str += "DELETE FROM CLIENTES where Id_cliente=" + _Id;
            return str;
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
                MessageBox.Show("O CLIENTE NÃO PODE SER APAGADO, POIS ELE TEM ENCOMENDAS");
            }
            return retorno;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_VerificarEncomenda(int _Id)
        {
            string str = "";
            str += "select id_encomenda FROM encomendas where Id_cliente=" + _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void frmClientes_Load(object sender, EventArgs e)
        {
            LimparComponent();
            CarregarGridClientes();
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparComponent();
        }
        //
        //--------------------------------------------------------------------
        //
        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Gravar_Click(object sender, EventArgs e)
        {
            if ((int)_btn_Gravar.Tag==0)
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
            gId_cliente       =    (int)_Grid["id_cliente", e.RowIndex].Value;
            _txtNome.Text     = (string)_Grid["Nome", e.RowIndex].Value;
            _txtMorada.Text   = (string)_Grid["Morada", e.RowIndex].Value;
            _txtCEP.Text      = (string)_Grid["cep", e.RowIndex].Value;
            _txtTelefone.Text = (string)_Grid["Telefone", e.RowIndex].Value;
            _btn_Gravar.Tag = 1;
            _txtNome.Focus();
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Alteracao(int _id_cliente)
        {
            string str = "UPDATE CLIENTES SET" +
                " Nome = '"     + _txtNome.Text     + "' " +
                ",morada = '"   + _txtMorada.Text   + "' " +
                ",Telefone = '" + _txtTelefone.Text + "' " +
                ",Cep = '"      + _txtCEP.Text + "' WHERE Id_cliente="  + _id_cliente;

            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void GravarAlteracao()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_Alteracao(gId_cliente);
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection = Main.Ligacao;
                Main.comando.Connection.Open();
                Main.comando.ExecuteNonQuery();
                Main.comando.Connection.Close();
                CarregarGridClientes();
                LimparComponent();
            }
            catch (Exception)
            {
                MessageBox.Show("Em [GravarAlteracao] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //
        //--------------------------------------------------------------------
        //

    }
}
