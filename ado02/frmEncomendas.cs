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
    public partial class frmEncomendas : Form
    {
        public int gId;        
        public frmEncomendas()
        {
            InitializeComponent();
            InicializarVariaveis();            
        }
        //               METODOS CUSTOMIZADOS
        //--------------------------------------------------------------------
        //
        private void LimparComponentes()
        {
            _cmb_Clientes.SelectedIndex = -1;
            _cmb_Produtos.SelectedIndex = -1;
            _nup_Qtdd.Value = 1;
        }
        //
        //--------------------------------------------------------------------
        //
        private bool ValidarDados()
        {
            bool retorno=true;
            if (
                (_cmb_Clientes.SelectedIndex<0) ||
                (_cmb_Produtos.SelectedIndex<0) ||
                (_nup_Qtdd.Value < 1)
                )
            {
                MessageBox.Show("Preencha completamente todos os campos",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno =  false;
            }
            return retorno;
        }
        //
        //--------------------------------------------------------------------
        //
        private void GravarDados()
        {
            try
            {
                //----------  BUSCANDO O ID DISPONIVEL DE ENCOMENDAS -------------
                int id_encomenda = RetornaNovoIdEncomendas();
                //----------  BUSCANDO O ID do cliente -------------
                int id_cliente  = RetornarIdClientes();
                //----------  BUSCANDO O ID do Produto -------------
                int id_Produto = RetornarIdProdutos();

                //------------ EXECUTAR A INCLUSÃO DA ENCOMENDA ----------------
                Main.expressaoSQL = MontarQuery_Inclusao(id_encomenda,id_cliente,id_Produto);
                Main.comando             = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();
                Main.comando.ExecuteNonQuery();
                Main.comando.Connection.Close();                
                LimparComponentes();
                CarregarGridEncomendas();            }
            catch (Exception)
            {                
                MessageBox.Show("Em [GravarDados] Houve um erro de Gravação , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _nup_Qtdd.Focus();
            }            
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornarIdClientes()
        {
            int _id = -1;
            try
            {
                Main.expressaoSQL = "SELECT Id_cliente from clientes where Nome ='"
                     +_cmb_Clientes.Text + "'"; ;
                Main.comando = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();                
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                    _id = (int)dr["Id_cliente"];
                }
            }
            catch (Exception)
            {                
                MessageBox.Show("Em [RetornarIdClientes] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cmb_Clientes.Focus();
            }
            Main.comando.Connection.Close();
            return _id;
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornaNovoIdEncomendas()
        {
            int id_encomenda = -1;
            try
            {
                //----------  PREPARANDO O ID DO NOVO REGISTRO -------------
                Main.expressaoSQL = "SELECT MAX(Id_encomenda) as ID from encomendas";
                Main.comando = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();
                object UltimoID = Main.comando.ExecuteScalar();
                Main.comando.Connection.Close();
                if (UltimoID == DBNull.Value)
                {

                    id_encomenda = 1;
                }
                else
                {
                    id_encomenda = (int)UltimoID + 1;
                }

            }
            catch (Exception)
            {             
                MessageBox.Show("Em [RetornaNovoIdEncomendas] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            return id_encomenda;
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Inclusao(int _id_encomenda, int _id_cliente, int _id_Produto)
        {
            string str = "";
            
            str +=  "INSERT INTO encomendas (Id_Cliente,Id_Produto,Qtdd) VALUES" +
//                      _id_encomenda+
                "(" + _id_cliente  +
                "," + _id_Produto  +
                "," + _nup_Qtdd.Value.ToString()+ ")";
                
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void InicializarVariaveis()
        {
//            _lbl_Registros.Text = "Registros.: 0";
            _btn_Gravar.Tag = 0;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarClientes()
        {
            try
            {
                /*
                Main.Ligacao.Close();
                Main.comando = new SqlCommand(Main.expressaoSQL, Main.Ligacao);
                Main.Ligacao = new SqlConnection(Main.strCnx);
                Main.Ligacao.Open();
                */

                Main.expressaoSQL = MontarQuery_CarregarClientes();
                Main.comando = new SqlCommand();
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                  _cmb_Clientes.Items.Add(dr["Nome"]);
                }                
            }
            catch (Exception)
            {                
                MessageBox.Show("Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            Main.comando.Connection.Close();
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarClientes()
        {
            return "SELECT Nome FROM Clientes order by nome";
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarGridEncomendas()
        {
            try
            {
//                Main.Ligacao.Close();
                //Main.Ligacao = new SqlConnection(Main.strCnx);
                Main.expressaoSQL        = MontarQuery_CarregarGrid();
                Main.comando             = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();                
                SqlDataReader dr = Main.comando.ExecuteReader();
                //------------------CRIANDO UMA TABELA DINAMICA ----------
                DataTable dt = new DataTable();
                dt.Columns.Add("id_encomenda", typeof(int));                
                dt.Columns.Add("Nome"        , typeof(string));
                dt.Columns.Add("Produto"     , typeof(string));
                dt.Columns.Add("Qtdd"        , typeof(int));
                while (dr.Read())
                {
                    DataRow Linha = dt.NewRow();
                    Linha["id_encomenda"] = dr["id_encomenda"];                    
                    Linha["Nome"]         = dr["Nome"];
                    Linha["Produto"]      = dr["Produto"];
                    Linha["Qtdd"]         = dr["Qtdd"];
                    dt.Rows.Add(Linha);
                }
                _Grid.DataSource         = dt;
                _Grid.Columns[0].Visible = false;
                Main.comando.Connection.Close();

            }
            catch (Exception )
            {
                MessageBox.Show("Em [CarregarGridEncomendas] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            CalcularRegistros();
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarGrid()
        {
            string str = "";        
            str += "select eco.id_encomenda, cli.nome as Nome , pro.nome as produto, eco.Qtdd from encomendas as eco";
            str += " left outer join clientes as cli  on cli.id_cliente = eco.id_cliente";
            str += " left outer join produtos as pro  on pro.id_produto = eco.id_produto";
            return str;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CalcularRegistros()
        {            
            //_lbl_Registros.Text = "Registros.: " + _Grid.Rows.Count.ToString();
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
            if(
                (_Grid.Rows.Count>1)&&
                MessageBox.Show(
                    "Deseja APAGAR o registro ?",
                    "Apagar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )==DialogResult.Yes)
            {
                int Id = -1;
                int linha = -1;
                linha = _Grid.SelectedRows[0].Index;
                Id = (int)_Grid["Id_encomenda", linha].Value;
                //------------ EXECUTAR A EXCLUSÃO DO REGISTRO ----------------
                try
                {
                    /* 
                    Main.Ligacao = new SqlConnection(Main.strCnx);
                    Main.expressaoSQL = MontarQuery_Exclusao(Id);
                    Main.comando = new SqlCommand(Main.expressaoSQL, Main.Ligacao);
                    Main.Ligacao.Open();
                    Main.comando.ExecuteNonQuery();
                    Main.Ligacao.Close();
                    */
                    Main.expressaoSQL = MontarQuery_Exclusao(Id);
                    Main.comando = new SqlCommand();
                    Main.comando.Connection  = Main.Ligacao;
                    Main.comando.CommandText = Main.expressaoSQL;
                    Main.comando.Connection.Open();
                    Main.comando.ExecuteNonQuery();
                    Main.comando.Connection.Close();
                    CarregarGridEncomendas();
                }
                catch (Exception)
                {
                    MessageBox.Show("Em [ApagarRegistros] Houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                        "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_Exclusao(int _Id)
        {
            string str = "";
            str += "DELETE FROM encomendas where Id_encomenda=" + _Id;
            return str;
        }
        //
        //--------------------------------------------------------------------
        //

        //         EVENTOS DOS OBJETOS\COMPONENTES
        //--------------------------------------------------------------------
        //
        private void _btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void frmEncomendas_Load(object sender, EventArgs e)
        {
            // construir o combo de produtos
            //_cmb_Produtos.Items.AddRange(produtos);
            CarregarClientes();
            CarregarProdutos();
            CarregarGridEncomendas();
        }
        //
        //--------------------------------------------------------------------
        //
        private void _btn_Gravar_Click(object sender, EventArgs e)
        {

            if(ValidarDados())
            {
                GravarDados();
            }
        }

        private void _btn_Apagar_Click(object sender, EventArgs e)
        {
            ApagarRegistros();
        }
        //
        //--------------------------------------------------------------------
        //
        private int RetornarIdProdutos()
        {
            int _id = -1;
            try
            {
                Main.expressaoSQL = "SELECT Id_Produto from produtos where Nome ='"
                     + _cmb_Produtos.Text + "'"; ;
                Main.comando             = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                    _id = (int)dr["Id_Produto"];
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Em [RetornarIdProdutos] Houve um erro. Verifique seu acesso ao banco de Dados",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cmb_Clientes.Focus();
            }
            Main.comando.Connection.Close();
            return _id;
        }
        //
        //--------------------------------------------------------------------
        //
        private void CarregarProdutos()
        {
            try
            {
                Main.expressaoSQL = MontarQuery_CarregarProdutos();
                Main.comando             = new SqlCommand();
                Main.comando.Connection  = Main.Ligacao;
                Main.comando.CommandText = Main.expressaoSQL;
                Main.comando.Connection.Open();
                SqlDataReader dr = Main.comando.ExecuteReader();
                while (dr.Read())
                {
                    _cmb_Produtos.Items.Add(dr["Nome"]);
                }
                Main.Ligacao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Em CarregarProdutos, houve um erro de Acesso ao Banco de Dados , Verifique seu acesso ao banco",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Main.Ligacao.Close();
        }
        //
        //--------------------------------------------------------------------
        //
        private string MontarQuery_CarregarProdutos()
        {
            return "SELECT Nome FROM Produtos order by nome";
        }

        private void _Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // FALTA IMPLEMENTAR OS METODOS QUE CARREGAM OS DADOS DE
            // CLIENTE E PRODUTO PARA ALTERAÇÃO
            //


            /*
            if (e.RowIndex == -1) return;
             gId    = (int)_Grid["id_cliente", e.RowIndex].Value;
            _txtNome.Text   = (string)_Grid["Nome", e.RowIndex].Value;
            _nup_Qtdd.Value = Convert.ToDouble(_Grid["Preco", e.RowIndex].Value);

            _txtMorada.Text = (string)_Grid["Morada", e.RowIndex].Value;
            _txtCEP.Text = (string)_Grid["cep", e.RowIndex].Value;
            _txtTelefone.Text = (string)_Grid["Telefone", e.RowIndex].Value;

            _btn_Gravar.Tag = 1;
            _txtNome.Focus();
            */

        }
        //
        //--------------------------------------------------------------------
        //

    }
}
