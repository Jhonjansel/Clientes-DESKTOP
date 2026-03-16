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
    {
        private readonly ClienteService clientService;
        private readonly ImportService importService;
        private BindingList<Cliente> clients;
        public Form1()
        {
            InitializeComponent();
            var repo = new JsonClienteRepository();
            clientService = new ClienteService(repo);
            importService = new ImportService();
            dgvClients.CellEndEdit += dgvClients_CellEndEdit;
            dgvClients.DataError += dgvClients_DataError;
            dgvClients.CellValidating += dgvClients_CellValidating;
            LoadClients();
        }

        private void LoadClients()
        {
            var list = clientService.GetClients();
            clients = new BindingList<Cliente>(list);
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
           
        }

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

                clientService.DeleteClient(client);

                clients.Remove(client);

                clientService.Save();
                LoadClients();
            }
        }

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(null, null);
            }
        }

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

        private void dgvClients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var client = (Cliente)dgvClients.Rows[e.RowIndex].DataBoundItem;
            clientService.UpdateClient(client);
            clientService.Save();
        }

        private void dgvClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
