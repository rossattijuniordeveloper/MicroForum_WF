namespace ado02
{
    partial class frmClientes
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
            this._btn_Gravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtNome = new System.Windows.Forms.TextBox();
            this._txtMorada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtCEP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btn_Cancelar = new System.Windows.Forms.Button();
            this._btn_Sair = new System.Windows.Forms.Button();
            this._Grid = new System.Windows.Forms.DataGridView();
            this._lbl_Registros = new System.Windows.Forms.Label();
            this._btn_Apagar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._txtTelefone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _btn_Gravar
            // 
            this._btn_Gravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Gravar.Location = new System.Drawing.Point(512, 54);
            this._btn_Gravar.Name = "_btn_Gravar";
            this._btn_Gravar.Size = new System.Drawing.Size(57, 23);
            this._btn_Gravar.TabIndex = 5;
            this._btn_Gravar.Text = "Gravar";
            this._btn_Gravar.UseVisualStyleBackColor = true;
            this._btn_Gravar.Click += new System.EventHandler(this._btn_Gravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome.:";
            // 
            // _txtNome
            // 
            this._txtNome.Location = new System.Drawing.Point(84, 8);
            this._txtNome.MaxLength = 50;
            this._txtNome.Name = "_txtNome";
            this._txtNome.Size = new System.Drawing.Size(420, 20);
            this._txtNome.TabIndex = 0;
            // 
            // _txtMorada
            // 
            this._txtMorada.Location = new System.Drawing.Point(84, 34);
            this._txtMorada.MaxLength = 50;
            this._txtMorada.Name = "_txtMorada";
            this._txtMorada.Size = new System.Drawing.Size(420, 20);
            this._txtMorada.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Morada.:";
            // 
            // _txtCEP
            // 
            this._txtCEP.Location = new System.Drawing.Point(84, 60);
            this._txtCEP.MaxLength = 12;
            this._txtCEP.Name = "_txtCEP";
            this._txtCEP.Size = new System.Drawing.Size(420, 20);
            this._txtCEP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CEP.:";
            // 
            // _btn_Cancelar
            // 
            this._btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Cancelar.Location = new System.Drawing.Point(512, 12);
            this._btn_Cancelar.Name = "_btn_Cancelar";
            this._btn_Cancelar.Size = new System.Drawing.Size(57, 23);
            this._btn_Cancelar.TabIndex = 4;
            this._btn_Cancelar.Text = "Cancelar";
            this._btn_Cancelar.UseVisualStyleBackColor = true;
            this._btn_Cancelar.Click += new System.EventHandler(this._btn_Cancelar_Click);
            // 
            // _btn_Sair
            // 
            this._btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Sair.Location = new System.Drawing.Point(512, 489);
            this._btn_Sair.Name = "_btn_Sair";
            this._btn_Sair.Size = new System.Drawing.Size(57, 23);
            this._btn_Sair.TabIndex = 7;
            this._btn_Sair.Text = "Sair";
            this._btn_Sair.UseVisualStyleBackColor = true;
            this._btn_Sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // _Grid
            // 
            this._Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Grid.Location = new System.Drawing.Point(33, 127);
            this._Grid.Name = "_Grid";
            this._Grid.RowHeadersVisible = false;
            this._Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._Grid.Size = new System.Drawing.Size(471, 350);
            this._Grid.TabIndex = 7;
            this._Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Grid_CellDoubleClick);
            // 
            // _lbl_Registros
            // 
            this._lbl_Registros.AutoSize = true;
            this._lbl_Registros.Location = new System.Drawing.Point(19, 491);
            this._lbl_Registros.Name = "_lbl_Registros";
            this._lbl_Registros.Size = new System.Drawing.Size(75, 13);
            this._lbl_Registros.TabIndex = 17;
            this._lbl_Registros.Text = "Registros..: 00";
            // 
            // _btn_Apagar
            // 
            this._btn_Apagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Apagar.Enabled = false;
            this._btn_Apagar.Location = new System.Drawing.Point(512, 203);
            this._btn_Apagar.Name = "_btn_Apagar";
            this._btn_Apagar.Size = new System.Drawing.Size(57, 23);
            this._btn_Apagar.TabIndex = 6;
            this._btn_Apagar.Text = "Apagar";
            this._btn_Apagar.UseVisualStyleBackColor = true;
            this._btn_Apagar.Click += new System.EventHandler(this._btn_Apagar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Telefone.:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // _txtTelefone
            // 
            this._txtTelefone.Location = new System.Drawing.Point(84, 85);
            this._txtTelefone.MaxLength = 30;
            this._txtTelefone.Name = "_txtTelefone";
            this._txtTelefone.Size = new System.Drawing.Size(420, 20);
            this._txtTelefone.TabIndex = 3;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 513);
            this.Controls.Add(this._txtTelefone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._btn_Apagar);
            this.Controls.Add(this._lbl_Registros);
            this.Controls.Add(this._Grid);
            this.Controls.Add(this._btn_Sair);
            this.Controls.Add(this._btn_Cancelar);
            this.Controls.Add(this._txtCEP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtMorada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btn_Gravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário de Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btn_Gravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtNome;
        private System.Windows.Forms.TextBox _txtMorada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtCEP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btn_Cancelar;
        private System.Windows.Forms.Button _btn_Sair;
        private System.Windows.Forms.DataGridView _Grid;
        private System.Windows.Forms.Label _lbl_Registros;
        private System.Windows.Forms.Button _btn_Apagar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtTelefone;
    }
}