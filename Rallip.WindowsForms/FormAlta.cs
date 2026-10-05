using Rallip.API.Clients;
using Rallip.DTOs;
using System;
using System.Windows.Forms;

namespace Rallip.WindowsForms
{
    public partial class FormAlta : Form
    {
        private readonly AlquilerApiClient _apiClient;

        public FormAlta()
        {
            InitializeComponent();
            _apiClient = new AlquilerApiClient();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar el formato numérico y el rango en la interfaz gráfica
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto < 0 || monto > 1000000)
            {
                MessageBox.Show("El monto debe ser un número válido entre 0 y 1.000.000.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Corta la ejecución para no llamar a la API
            }

            var dto = new AlquilerDTO
            {
                Inquilino = txtInquilino.Text,
                MontoAlquiler = monto, // Asigna el valor validado
                FechaInicio = dtpInicio.Value,
                FechaFin = dtpFin.Value
            };

            var error = await _apiClient.AddAlquilerAsync(dto);

            if (error != null)
            {
                MessageBox.Show(error, "Error");
            }
            else
            {
                MessageBox.Show("Guardado exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}