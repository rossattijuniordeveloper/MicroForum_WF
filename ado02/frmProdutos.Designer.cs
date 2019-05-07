namespace ado02
{
    partial class frmProdutos
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
            this._txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Grid = new System.Windows.Forms.DataGridView();
            this._btn_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._NuDo_Preco = new System.Windows.Forms.NumericUpDown();
            this._btn_Sair = new System.Windows.Forms.Button();
            this._btn_Gravar = new System.Windows.Forms.Button();
            this._lbl_Registros = new System.Windows.Forms.Label();
            this._btn_Apagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._NuDo_Preco)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNome
            // 
            this._txtNome.Location = new System.Drawing.Point(57, 12);
            this._txtNome.MaxLength = 50;
            this._txtNome.Name = "_txtNome";
            this._txtNome.Size = new System.Drawing.Size(420, 20);
            this._txtNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome.:";
            // 
            // _Grid
            // 
            this._Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Grid.Location = new System.Drawing.Point(57, 59);
            this._Grid.Name = "_Grid";
            this._Grid.RowHeadersVisible = false;
            this._Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._Grid.Size = new System.Drawing.Size(420, 330);
            this._Grid.TabIndex = 8;
            this._Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Grid_CellDoubleClick);
            // 
            // _btn_Cancelar
            // 
            this._btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Cancelar.Location = new System.Drawing.Point(483, 6);
            this._btn_Cancelar.Name = "_btn_Cancelar";
            this._btn_Cancelar.Size = new System.Drawing.Size(57, 23);
            this._btn_Cancelar.TabIndex = 2;
            this._btn_Cancelar.Text = "Cancelar";
            this._btn_Cancelar.UseVisualStyleBackColor = true;
            this._btn_Cancelar.Click += new System.EventHandler(this._btn_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Preço.:";
            // 
            // _NuDo_Preco
            // 
            this._NuDo_Preco.Location = new System.Drawing.Point(57, 33);
            this._NuDo_Preco.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this._NuDo_Preco.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._NuDo_Preco.Name = "_NuDo_Preco";
            this._NuDo_Preco.Size = new System.Drawing.Size(120, 20);
            this._NuDo_Preco.TabIndex = 1;
            this._NuDo_Preco.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _btn_Sair
            // 
            this._btn_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Sair.Location = new System.Drawing.Point(483, 396);
            this._btn_Sair.Name = "_btn_Sair";
            this._btn_Sair.Size = new System.Drawing.Size(57, 23);
            this._btn_Sair.TabIndex = 5;
            this._btn_Sair.Text = "Sair";
            this._btn_Sair.UseVisualStyleBackColor = true;
            this._btn_Sair.Click += new System.EventHandler(this._btn_Sair_Click);
            // 
            // _btn_Gravar
            // 
            this._btn_Gravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Gravar.Location = new System.Drawing.Point(483, 59);
            this._btn_Gravar.Name = "_btn_Gravar";
            this._btn_Gravar.Size = new System.Drawing.Size(57, 23);
            this._btn_Gravar.TabIndex = 3;
            this._btn_Gravar.Text = "Gravar";
            this._btn_Gravar.UseVisualStyleBackColor = true;
            this._btn_Gravar.Click += new System.EventHandler(this._btn_Gravar_Click);
            // 
            // _lbl_Registros
            // 
            this._lbl_Registros.AutoSize = true;
            this._lbl_Registros.Location = new System.Drawing.Point(54, 406);
            this._lbl_Registros.Name = "_lbl_Registros";
            this._lbl_Registros.Size = new System.Drawing.Size(75, 13);
            this._lbl_Registros.TabIndex = 18;
            this._lbl_Registros.Text = "Registros..: 00";
            // 
            // _btn_Apagar
            // 
            this._btn_Apagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Apagar.Enabled = false;
            this._btn_Apagar.Location = new System.Drawing.Point(483, 191);
            this._btn_Apagar.Name = "_btn_Apagar";
            this._btn_Apagar.Size = new System.Drawing.Size(57, 23);
            this._btn_Apagar.TabIndex = 4;
            this._btn_Apagar.Text = "Apagar";
            this._btn_Apagar.UseVisualStyleBackColor = true;
            this._btn_Apagar.Click += new System.EventHandler(this._btn_Apagar_Click);
            // 
            // frmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 428);
            this.Controls.Add(this._btn_Apagar);
            this.Controls.Add(this._lbl_Registros);
            this.Controls.Add(this._btn_Gravar);
            this.Controls.Add(this._btn_Sair);
            this.Controls.Add(this._NuDo_Preco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btn_Cancelar);
            this.Controls.Add(this._Grid);
            this.Controls.Add(this._txtNome);
            this.Controls.Add(this.label1);
            this.Name = "frmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário de Produtos";
            this.Load += new System.EventHandler(this.frmProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._NuDo_Preco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView _Grid;
        private System.Windows.Forms.Button _btn_Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _NuDo_Preco;
        private System.Windows.Forms.Button _btn_Sair;
        private System.Windows.Forms.Button _btn_Gravar;
        private System.Windows.Forms.Label _lbl_Registros;
        private System.Windows.Forms.Button _btn_Apagar;
    }
}