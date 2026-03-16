namespace Clientes_DESKTOP
{
    partial class Form1
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
            this.btnImportJson = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportJson
            // 
            this.btnImportJson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportJson.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportJson.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnImportJson.Location = new System.Drawing.Point(155, 68);
            this.btnImportJson.Name = "btnImportJson";
            this.btnImportJson.Size = new System.Drawing.Size(121, 34);
            this.btnImportJson.TabIndex = 0;
            this.btnImportJson.Text = "Importar JSON";
            this.btnImportJson.UseVisualStyleBackColor = true;
            this.btnImportJson.Click += new System.EventHandler(this.btnImportJson_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(28, 108);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(639, 191);
            this.dgvClients.TabIndex = 1;
            this.dgvClients.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellEndEdit);
            this.dgvClients.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvClients_CellValidating);
            this.dgvClients.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvClients_DataError);
            // 
            // progressBarImport
            // 
            this.progressBarImport.Location = new System.Drawing.Point(28, 305);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(639, 11);
            this.progressBarImport.TabIndex = 2;
            // 
            // btnImportCsv
            // 
            this.btnImportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportCsv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCsv.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnImportCsv.Location = new System.Drawing.Point(28, 68);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(121, 34);
            this.btnImportCsv.TabIndex = 3;
            this.btnImportCsv.Text = "Importar CSV";
            this.btnImportCsv.UseVisualStyleBackColor = true;
            this.btnImportCsv.Click += new System.EventHandler(this.btnImportCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gestión de Clientes";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(546, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar cliente";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 329);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportCsv);
            this.Controls.Add(this.progressBarImport);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnImportJson);
            this.Name = "Form1";
            this.Text = "Gestión de Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportJson;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.ProgressBar progressBarImport;
        private System.Windows.Forms.Button btnImportCsv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
    }
}

