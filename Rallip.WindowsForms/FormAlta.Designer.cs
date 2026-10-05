namespace Rallip.WindowsForms
{
    partial class FormAlta
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
            txtInquilino = new TextBox();
            txtMonto = new TextBox();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // txtInquilino
            // 
            txtInquilino.Location = new Point(200, 117);
            txtInquilino.Name = "txtInquilino";
            txtInquilino.Size = new Size(125, 27);
            txtInquilino.TabIndex = 0;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(200, 183);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(125, 27);
            txtMonto.TabIndex = 1;
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(200, 245);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(125, 27);
            dtpInicio.TabIndex = 2;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(200, 311);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(125, 27);
            dtpFin.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(480, 370);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormAlta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(txtMonto);
            Controls.Add(txtInquilino);
            Name = "FormAlta";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInquilino;
        private TextBox txtMonto;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Button btnGuardar;
    }
}