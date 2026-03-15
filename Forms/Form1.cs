using Clientes_DESKTOP.Repositories;
using Clientes_DESKTOP.Services;
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

        private readonly ClienteService clienteService;
        private readonly ImportService importService;
        public Form1()
        {
            InitializeComponent();
            var repo = new JsonClienteRepository();
            clienteService = new ClienteService(repo);
            importService = new ImportService();

            LoadClientes();
        }

        private void LoadClientes()
        {
            dataGridView1.DataSource = clienteService.ObtenerClientes();
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var clientes = importService.ImportCsv(dialog.FileName);

                foreach (var c in clientes)
                    clienteService.CrearCliente(c);

                LoadClientes();
            }
        }

        private async void btnImportJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                progressBarImport.Value = 0;

                var clientes = await Task.Run(() =>
                    importService.ImportJson(dialog.FileName)
                );

                int total = clientes.Count;
                int count = 0;

                foreach (var c in clientes)
                {
                    clienteService.CrearCliente(c);

                    count++;
                    progressBarImport.Value = (count * 100) / total;

                    await Task.Delay(20);
                }

                LoadClientes();

                MessageBox.Show("Importación JSON completada");
            }
        }

    }
}
