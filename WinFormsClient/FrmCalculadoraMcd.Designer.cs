namespace WinFormsClient
{
    partial class FrmCalculadoraMcd
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
            txtDividendo = new TextBox();
            lblDividendo = new Label();
            lblDivisor = new Label();
            txtDivisor = new TextBox();
            btnCalcular = new Button();
            lblResultado = new Label();
            lblh = new Label();
            btnRefrescar = new Button();
            dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // txtDividendo
            // 
            txtDividendo.Location = new Point(110, 27);
            txtDividendo.Name = "txtDividendo";
            txtDividendo.Size = new Size(100, 23);
            txtDividendo.TabIndex = 0;
            // 
            // lblDividendo
            // 
            lblDividendo.AutoSize = true;
            lblDividendo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblDividendo.Location = new Point(23, 33);
            lblDividendo.Name = "lblDividendo";
            lblDividendo.Size = new Size(69, 17);
            lblDividendo.TabIndex = 1;
            lblDividendo.Text = "Dividendo";
            // 
            // lblDivisor
            // 
            lblDivisor.AutoSize = true;
            lblDivisor.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblDivisor.Location = new Point(26, 65);
            lblDivisor.Name = "lblDivisor";
            lblDivisor.Size = new Size(49, 17);
            lblDivisor.TabIndex = 2;
            lblDivisor.Text = "Divisor";
            // 
            // txtDivisor
            // 
            txtDivisor.Location = new Point(110, 60);
            txtDivisor.Name = "txtDivisor";
            txtDivisor.Size = new Size(100, 23);
            txtDivisor.TabIndex = 3;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.RoyalBlue;
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.Black;
            btnCalcular.Location = new Point(113, 113);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 28);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblResultado.Location = new Point(23, 162);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(88, 17);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "Resultado: —";
            // 
            // lblh
            // 
            lblh.AutoSize = true;
            lblh.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblh.Location = new Point(23, 204);
            lblh.Name = "lblh";
            lblh.Size = new Size(192, 25);
            lblh.TabIndex = 6;
            lblh.Text = "Historial de Cálculos";
            // 
            // btnRefrescar
            // 
            btnRefrescar.BackColor = Color.Cyan;
            btnRefrescar.Cursor = Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderSize = 0;
            btnRefrescar.FlatStyle = FlatStyle.Flat;
            btnRefrescar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefrescar.ForeColor = Color.Black;
            btnRefrescar.Location = new Point(31, 232);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(75, 28);
            btnRefrescar.TabIndex = 7;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(12, 288);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.Size = new Size(507, 163);
            dgvHistorial.TabIndex = 8;
            // 
            // FrmCalculadoraMcd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 463);
            Controls.Add(dgvHistorial);
            Controls.Add(btnRefrescar);
            Controls.Add(lblh);
            Controls.Add(lblResultado);
            Controls.Add(btnCalcular);
            Controls.Add(txtDivisor);
            Controls.Add(lblDivisor);
            Controls.Add(lblDividendo);
            Controls.Add(txtDividendo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCalculadoraMcd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora MCD";
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDividendo;
        private TextBox txtDivisor;
        private Label lblDividendo;
        private Label lblDivisor;
        private Label lblh;
        private Label lblResultado;
        private Button btnCalcular;
        private Button btnRefrescar;
        private DataGridView dgvHistorial;


        /*
        private TextBox txtDividendo;

<<<<<<< TODO: cambio sin combinar del proyecto "WinFormsClient", Antes:
        private Label label1;
    }
=======
        private Label lblDividendo;
        private Label label2;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
    }
>>>>>>> Después
        private Label lblDividendo;
        private Label lblDivisor;
        private TextBox txtDivisor;
        private Label lblh;
        private Button btnRefrescar;
        private DataGridView dgvHistorial;
        private object lblResultado;
        private object btnCalcular;
        */
    }
}
