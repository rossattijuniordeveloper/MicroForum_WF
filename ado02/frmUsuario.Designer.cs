namespace ado02
{
    partial class frmUsuario
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
            this._btn_Cancelar = new System.Windows.Forms.Button();
            this._btn_Gravar = new System.Windows.Forms.Button();
            this._btn_Apagar = new System.Windows.Forms.Button();
            this._btn_Sair = new System.Windows.Forms.Button();
            this._Grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNome
            // 
            this._txtNome.Location = new System.Drawing.Point(49, 12);
            this._txtNome.MaxLength = 50;
            this._txtNome.Name = "_txtNome";
            this._txtNome.Size = new System.Drawing.Size(420, 20);
            this._txtNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome.:";
            // 
            // _btn_Cancelar
            // 
            this._btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Cancelar.Location = new System.Drawing.Point(490, 9);
            this._btn_Cancelar.Name = "_btn_Cancelar";
            this._btn_Cancelar.Size = new System.Drawing.Size(57, 23);
            this._btn_Cancelar.TabIndex = 1;
            this._btn_Cancelar.Text = "Cancelar";
            this._btn_Cancelar.UseVisualStyleBackColor = true;
            this._btn_Cancelar.Click += new System.EventHandler(this._btn_Cancelar_Click);
            // 
            // _btn_Gravar
            // 
            this._btn_Gravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Gravar.Location = new System.Drawing.Point(490, 64);
            this._btn_Gravar.Name = "_btn_Gravar";
            this._btn_Gravar.Size = new System.Drawing.Size(57, 23);
            this._btn_Gravar.TabIndex = 2;
            this._btn_Gravar.Text = "Gravar";
            this._btn_Gravar.UseVisualStyleBackColor = true;
            this._btn_Gravar.Click += new System.EventHandler(this._btn_Gravar_Click);
            // 
            // _btn_Apagar
            // 
            this._btn_Apagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Apagar.Enabled = false;
            this._btn_Apagar.Location = new System.Drawing.Point(490, 242);
            this._btn_Apagar.Name = "_btn_Apagar";
            this._btn_Apagar.Size = new System.Drawing.Size(57, 23);
            this._btn_Apagar.TabIndex = 3;
            this._btn_Apagar.Text = "Apagar";
            this._btn_Apagar.UseVisualStyleBackColor = true;
            this._btn_Apagar.Click += new System.EventHandler(this._btn_Apagar_Click);
            // 
            // _btn_Sair
            // 
            this._btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btn_Sair.Location = new System.Drawing.Point(514, 487);
            this._btn_Sair.Name = "_btn_Sair";
            this._btn_Sair.Size = new System.Drawing.Size(57, 23);
            this._btn_Sair.TabIndex = 4;
            this._btn_Sair.Text = "Sair";
            this._btn_Sair.UseVisualStyleBackColor = true;
            this._btn_Sair.Click += new System.EventHandler(this._btn_Sair_Click);
            // 
            // _Grid
            // 
            this._Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Grid.Location = new System.Drawing.Point(6, 38);
            this._Grid.Name = "_Grid";
            this._Grid.RowHeadersVisible = false;
            this._Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._Grid.Size = new System.Drawing.Size(463, 441);
            this._Grid.TabIndex = 8;
            this._Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Grid_CellDoubleClick);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 513);
            this.Controls.Add(this._Grid);
            this.Controls.Add(this._btn_Sair);
            this.Controls.Add(this._btn_Apagar);
            this.Controls.Add(this._btn_Gravar);
            this.Controls.Add(this._btn_Cancelar);
            this.Controls.Add(this._txtNome);
            this.Controls.Add(this.label1);
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulário de Usuários";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btn_Cancelar;
        private System.Windows.Forms.Button _btn_Gravar;
        private System.Windows.Forms.Button _btn_Apagar;
        private System.Windows.Forms.Button _btn_Sair;
        private System.Windows.Forms.DataGridView _Grid;
    }
}