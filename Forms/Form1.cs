using Clientes.Shared.Models;
using Clientes.Shared.Repositories;
using Clientes_DESKTOP.Services;
using Clientes_DESKTOP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientes_DESKTOP
{
    public partial class Form1 : Form
    {   // Servicio que maneja la lógica de negocio de clientes
        private readonly ClienteService clientService;
        // Servicio encargado de importar clientes desde CSV o JSON
        private readonly ImportService importService;
        // Lista enlazada al DataGridView para reflejar cambios automáticamente
        private BindingList<Cliente> clients;
        public Form1()
        {
            InitializeComponent();
            // Crear repositorio y servicios
            var repo = new JsonClienteRepository();
            clientService = new ClienteService(repo);
            importService = new ImportService();
            // Eventos del DataGridView para validación y manejo de errores
            dgvClients.CellEndEdit += dgvClients_CellEndEdit;
            dgvClients.DataError += dgvClients_DataError;
            dgvClients.CellValidating += dgvClients_CellValidating;
            LoadClients(); // Cargar clientes al iniciar la aplicación
        }
        // Carga los clientes en el DataGridView
        private void LoadClients()
        {
            var list = clientService.GetClients();
            // BindingList permite que el DataGridView se actualice automáticamente
            clients = new BindingList<Cliente>(list);
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
           
        }
        // Importar clientes desde un archivo CSV
        private async void btnImportCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                progressBarImport.Value = 0;

                var clients = await Task.Run(() =>
                    importService.ImportCsv(dialog.FileName)
                );

                int total = clients.Count;
                int count = 0;

                foreach (var c in clients)
                {
                    clientService.CreateClient(c);

                    count++;
                    progressBarImport.Value = (count * 100) / total;

                    await Task.Delay(20);
                }

                LoadClients();

                MessageBox.Show("Importación CSV completada");
            }
        }
        // Importar clientes desde archivo JSON
        private async void btnImportJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                progressBarImport.Value = 0;

                var clients = await Task.Run(() =>
                    importService.ImportJson(dialog.FileName)
                );

                int total = clients.Count;
                int count = 0;

                foreach (var c in clients)
                {
                    clientService.CreateClient(c);

                    count++;
                    progressBarImport.Value = (count * 100) / total;

                    await Task.Delay(20);
                }

                LoadClients();

                MessageBox.Show("Importación JSON completada");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // clientService.Save();
            // base.OnFormClosing(e);
        }
        // Eliminar cliente seleccionado
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null || dgvClients.CurrentRow.IsNewRow)
                return;

            var client = (Cliente)dgvClients.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show(
                "¿Seguro que deseas eliminar este cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                // Eliminar cliente del servicio json
                clientService.DeleteClient(client);
                // Eliminar de la lista enlazada
                clients.Remove(client);
                // Guardar cambios en json
                clientService.Save();
                LoadClients();
            }
        }
        // Permite eliminar con la tecla Delete
        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(null, null);
            }
        }
        // Validación de datos cuando se edita una celda
        private void dgvClients_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var columnName = dgvClients.Columns[e.ColumnIndex].Name;

            string value = e.FormattedValue?.ToString();

            string error = null;

            switch (columnName)
            {
                case "DNI":

                    if (string.IsNullOrWhiteSpace(value))
                        error = "El DNI no puede estar vacío";

                    break;

                case "Email":

                    if (!ValidationHelper.EmailValid(value))
                        error = "Email inválido";

                    break;

                case "Telefono":

                    if (!ValidationHelper.PhoneValid(value))
                        error = "Teléfono inválido";

                    break;

                case "FechaNacimiento":

                    if (!DateTime.TryParse(value, out _))
                        error = "Fecha inválida";

                    break;
            }

            if (error != null)
            {
                e.Cancel = true;

                dgvClients.Rows[e.RowIndex].ErrorText = error;
                dgvClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightPink;

            }
            else
            {
                dgvClients.Rows[e.RowIndex].ErrorText = "";
                dgvClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

            }
        }
        // Se ejecuta cuando termina la edición de una celda
        private void dgvClients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var client = (Cliente)dgvClients.Rows[e.RowIndex].DataBoundItem;
            clientService.UpdateClient(client);
            clientService.Save();
        }
        // Maneja errores del DataGridView
        private void dgvClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
