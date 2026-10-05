using Rallip.API.Clients;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Rallip.WindowsForms
{
    public partial class FormListado : Form
    {
        private readonly AlquilerApiClient _apiClient;

        public FormListado()
        {
            InitializeComponent();
            _apiClient = new AlquilerApiClient();

            // Configuración inicial de la lista
            cmbEstados.Items.Add("Activo"); 
            cmbEstados.Items.Add("Finalizado"); 
            cmbEstados.SelectedIndex = 0;
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                var estado = cmbEstados.SelectedItem.ToString();
                var datos = await _apiClient.GetAlquileresAsync(estado);
                dgvAlquileres.DataSource = datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formAlta = new FormAlta();
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                btnFiltrar.PerformClick(); // Actualiza la grilla tras agregar
            }
        }

        private async void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow != null)
            {
                var id = (int)dgvAlquileres.CurrentRow.Cells["Id"].Value;

                try
                {
                    await _apiClient.FinalizarAlquilerAsync(id); 
                    MessageBox.Show("Alquiler finalizado con éxito.");
                    btnFiltrar.PerformClick(); // Actualiza la grilla
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al finalizar: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro de la grilla primero.");
            }
        }
    }
}