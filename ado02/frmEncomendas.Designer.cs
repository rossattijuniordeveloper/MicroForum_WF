namespace ado02
{
    partial class frmEncomendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._btn_Sair = new System.Windows.Forms.Button();
            this._btn_Cancelar = new System.Windows.Forms.Button();
            this._btn_Gravar = new System.Windows.Forms.Button();
            this._cmb_Clientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cmb_Produtos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._nup_Qtdd = new System.Windows.Forms.NumericUpDown();
            this._Grid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this._btn_Apagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._nup_Qtdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clientes";
            // 
            // _btn_Sair
            // 
            this._btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Sair.Location = new System.Drawing.Point(593, 415);
            this._btn_Sair.Name = "_btn_Sair";
            this._btn_Sair.Size = new System.Drawing.Size(57, 23);
            this._btn_Sair.TabIndex = 9;
            this._btn_Sair.Text = "Sair";
            this._btn_Sair.UseVisualStyleBackColor = true;
            this._btn_Sair.Click += new System.EventHandler(this._btn_Sair_Click);
            // 
            // _btn_Cancelar
            // 
            this._btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Cancelar.Location = new System.Drawing.Point(593, 12);
            this._btn_Cancelar.Name = "_btn_Cancelar";
            this._btn_Cancelar.Size = new System.Drawing.Size(57, 23);
            this._btn_Cancelar.TabIndex = 4;
            this._btn_Cancelar.Text = "Cancelar";
            this._btn_Cancelar.UseVisualStyleBackColor = true;
            this._btn_Cancelar.Click += new System.EventHandler(this._btn_Cancelar_Click);
            // 
            // _btn_Gravar
            // 
            this._btn_Gravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Gravar.Location = new System.Drawing.Point(595, 52);
            this._btn_Gravar.Name = "_btn_Gravar";
            this._btn_Gravar.Size = new System.Drawing.Size(57, 23);
            this._btn_Gravar.TabIndex = 3;
            this._btn_Gravar.Text = "Gravar";
            this._btn_Gravar.UseVisualStyleBackColor = true;
            this._btn_Gravar.Click += new System.EventHandler(this._btn_Gravar_Click);
            // 
            // _cmb_Clientes
            // 
            this._cmb_Clientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmb_Clientes.FormattingEnabled = true;
            this._cmb_Clientes.Location = new System.Drawing.Point(6, 32);
            this._cmb_Clientes.Name = "_cmb_Clientes";
            this._cmb_Clientes.Size = new System.Drawing.Size(271, 21);
            this._cmb_Clientes.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Produtos";
            // 
            // _cmb_Produtos
            // 
            this._cmb_Produtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmb_Produtos.FormattingEnabled = true;
            this._cmb_Produtos.Location = new System.Drawing.Point(283, 32);
            this._cmb_Produtos.Name = "_cmb_Produtos";
            this._cmb_Produtos.Size = new System.Drawing.Size(216, 21);
            this._cmb_Produtos.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Quantidade";
            // 
            // _nup_Qtdd
            // 
            this._nup_Qtdd.Location = new System.Drawing.Point(523, 32);
            this._nup_Qtdd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this._nup_Qtdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nup_Qtdd.Name = "_nup_Qtdd";
            this._nup_Qtdd.Size = new System.Drawing.Size(59, 20);
            this._nup_Qtdd.TabIndex = 2;
            this._nup_Qtdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _Grid
            // 
            this._Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Grid.Location = new System.Drawing.Point(9, 86);
            this._Grid.Name = "_Grid";
            this._Grid.RowHeadersVisible = false;
            this._Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._Grid.Size = new System.Drawing.Size(573, 312);
            this._Grid.TabIndex = 15;
            this._Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Grid_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Encomendas Registradas";
            // 
            // _btn_Apagar
            // 
            this._btn_Apagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Apagar.Enabled = false;
            this._btn_Apagar.Location = new System.Drawing.Point(593, 145);
            this._btn_Apagar.Name = "_btn_Apagar";
            this._btn_Apagar.Size = new System.Drawing.Size(57, 23);
            this._btn_Apagar.TabIndex = 18;
            this._btn_Apagar.Text = "Apagar";
            this._btn_Apagar.UseVisualStyleBackColor = true;
            this._btn_Apagar.Click += new System.EventHandler(this._btn_Apagar_Click);
            // 
            // frmEncomendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this._btn_Apagar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._Grid);
            this.Controls.Add(this._nup_Qtdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._cmb_Produtos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmb_Clientes);
            this.Controls.Add(this._btn_Sair);
            this.Controls.Add(this._btn_Cancelar);
            this.Controls.Add(this._btn_Gravar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEncomendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário de Encomendas";
            this.Load += new System.EventHandler(this.frmEncomendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this._nup_Qtdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btn_Sair;
        private System.Windows.Forms.Button _btn_Cancelar;
        private System.Windows.Forms.Button _btn_Gravar;
        private System.Windows.Forms.ComboBox _cmb_Clientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmb_Produtos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _nup_Qtdd;
        private System.Windows.Forms.DataGridView _Grid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btn_Apagar;
    }
}