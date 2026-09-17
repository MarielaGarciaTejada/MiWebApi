using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class FrmCalculadoraMcd : Form
    {
        // La URL de la API en Azure
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://api-calculadora-mcd-dfeefuhsgaazgpay.westus3-01.azurewebsites.net")
        };

        public FrmCalculadoraMcd()
        {
            InitializeComponent();
        }

        private async void FrmCalculadoraMcd_Load(object sender, EventArgs e)
        {
             await CargarHistorialAsync();
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDividendo.Text, out int dividendo) || !int.TryParse(txtDivisor.Text, out int divisor))
            {
                MessageBox.Show("Por favor ingresa dos números enteros válidos.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnCalcular.Enabled = false;
            try
            {
                var respuesta = await _client.GetAsync($"api/mcd?dividendo={dividendo}&divisor={divisor}");
                var contenido = await respuesta.Content.ReadAsStringAsync();

                if (respuesta.IsSuccessStatusCode)
                {
                    using var doc = JsonDocument.Parse(contenido);
                    int mcd = doc.RootElement.GetProperty("mcd").GetInt32();

                    lblResultado.Text = $"MCD: {contenido}";
                    await CargarHistorialAsync();
                }
                else
                {
                    lblResultado.Text = "Resultado: —";
                    MessageBox.Show(contenido, "Error al calcular", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCalcular.Enabled = true;
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            btnRefrescar.Enabled = false;
            try
            {
                await CargarHistorialAsync();
            }
            finally
            {
                btnRefrescar.Enabled = true;
            }
        }

        private async Task CargarHistorialAsync()
        {
            try
            {
                var historial = await _client.GetFromJsonAsync<List<HistorialCalculoDto>>("/api/historial");
                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar el historial: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // DTO del cliente actualizado con Dividendo y Divisor
    public class HistorialCalculoDto
    {
        public int Id { get; set; }
        public int Dividendo { get; set; }
        public int Divisor { get; set; }
        public int Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
