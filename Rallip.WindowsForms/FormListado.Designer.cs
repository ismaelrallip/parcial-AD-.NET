namespace Rallip.WindowsForms
{
    partial class FormListado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbEstados = new ComboBox();
            btnFiltrar = new Button();
            dgvAlquileres = new DataGridView();
            btnAgregar = new Button();
            btnFinalizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).BeginInit();
            SuspendLayout();
            // 
            // cmbEstados
            // 
            cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstados.FormattingEnabled = true;
            cmbEstados.Location = new Point(200, 27);
            cmbEstados.Name = "cmbEstados";
            cmbEstados.Size = new Size(151, 28);
            cmbEstados.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(393, 27);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 29);
            btnFiltrar.TabIndex = 1;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvAlquileres
            // 
            dgvAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlquileres.Location = new Point(32, 81);
            dgvAlquileres.Name = "dgvAlquileres";
            dgvAlquileres.ReadOnly = true;
            dgvAlquileres.RowHeadersWidth = 51;
            dgvAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileres.Size = new Size(705, 271);
            dgvAlquileres.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(566, 387);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(148, 28);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(74, 387);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(148, 28);
            btnFinalizar.TabIndex = 4;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // FormListado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFinalizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvAlquileres);
            Controls.Add(btnFiltrar);
            Controls.Add(cmbEstados);
            Name = "FormListado";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbEstados;
        private Button btnFiltrar;
        private DataGridView dgvAlquileres;
        private Button btnAgregar;
        private Button btnFinalizar;
    }
}
