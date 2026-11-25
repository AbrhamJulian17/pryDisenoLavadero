namespace pryCalculoLavadero
{
    partial class frmLavados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLavados));
            btnLimpiar = new Button();
            btnCalcular = new Button();
            cboServicio = new ComboBox();
            rbNormal = new RadioButton();
            rbExpress = new RadioButton();
            lblCliente = new Label();
            lblPatente = new Label();
            lblServicio = new Label();
            lblVehiculos = new Label();
            gpbDatos = new GroupBox();
            chbClienteFrecuente = new CheckBox();
            gpbEntrega = new GroupBox();
            txtVehiculos = new TextBox();
            txtPatente = new TextBox();
            txtCliente = new TextBox();
            gpbImporte = new GroupBox();
            lblTotal = new Label();
            lblDescuento = new Label();
            lblRecargo = new Label();
            lblSubtotal = new Label();
            gpbDatos.SuspendLayout();
            gpbEntrega.SuspendLayout();
            gpbImporte.SuspendLayout();
            SuspendLayout();
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.PapayaWhip;
            btnLimpiar.Location = new Point(212, 324);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(152, 30);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.PapayaWhip;
            btnCalcular.Location = new Point(16, 324);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(149, 30);
            btnCalcular.TabIndex = 1;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            // 
            // cboServicio
            // 
            cboServicio.FormattingEnabled = true;
            cboServicio.Items.AddRange(new object[] { "Lavado con encerado", "Lavado Completo", "Lavado Exterior" });
            cboServicio.Location = new Point(156, 117);
            cboServicio.Name = "cboServicio";
            cboServicio.Size = new Size(190, 23);
            cboServicio.TabIndex = 2;
            // 
            // rbNormal
            // 
            rbNormal.AutoSize = true;
            rbNormal.Location = new Point(78, 31);
            rbNormal.Name = "rbNormal";
            rbNormal.Size = new Size(65, 19);
            rbNormal.TabIndex = 3;
            rbNormal.TabStop = true;
            rbNormal.Text = "Normal";
            rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbExpress
            // 
            rbExpress.AutoSize = true;
            rbExpress.Location = new Point(178, 31);
            rbExpress.Name = "rbExpress";
            rbExpress.Size = new Size(104, 19);
            rbExpress.TabIndex = 4;
            rbExpress.TabStop = true;
            rbExpress.Text = "Express (+25%)";
            rbExpress.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(31, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 5;
            lblCliente.Text = "Cliente:";
            // 
            // lblPatente
            // 
            lblPatente.AutoSize = true;
            lblPatente.Location = new Point(31, 75);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(50, 15);
            lblPatente.TabIndex = 6;
            lblPatente.Text = "Patente:";
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(31, 117);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(51, 15);
            lblServicio.TabIndex = 7;
            lblServicio.Text = "Servicio:";
            // 
            // lblVehiculos
            // 
            lblVehiculos.AutoSize = true;
            lblVehiculos.Location = new Point(31, 166);
            lblVehiculos.Name = "lblVehiculos";
            lblVehiculos.Size = new Size(95, 15);
            lblVehiculos.TabIndex = 8;
            lblVehiculos.Text = "Vehiculos (1 a 5):";
            // 
            // gpbDatos
            // 
            gpbDatos.Controls.Add(chbClienteFrecuente);
            gpbDatos.Controls.Add(gpbEntrega);
            gpbDatos.Controls.Add(txtVehiculos);
            gpbDatos.Controls.Add(btnLimpiar);
            gpbDatos.Controls.Add(btnCalcular);
            gpbDatos.Controls.Add(txtPatente);
            gpbDatos.Controls.Add(txtCliente);
            gpbDatos.Controls.Add(lblCliente);
            gpbDatos.Controls.Add(lblPatente);
            gpbDatos.Controls.Add(lblServicio);
            gpbDatos.Controls.Add(cboServicio);
            gpbDatos.Controls.Add(lblVehiculos);
            gpbDatos.Location = new Point(12, 12);
            gpbDatos.Name = "gpbDatos";
            gpbDatos.Size = new Size(382, 371);
            gpbDatos.TabIndex = 9;
            gpbDatos.TabStop = false;
            gpbDatos.Text = "Datos del lavado";
            // 
            // chbClienteFrecuente
            // 
            chbClienteFrecuente.AutoSize = true;
            chbClienteFrecuente.Location = new Point(31, 289);
            chbClienteFrecuente.Name = "chbClienteFrecuente";
            chbClienteFrecuente.Size = new Size(182, 19);
            chbClienteFrecuente.TabIndex = 15;
            chbClienteFrecuente.Text = "Cliente Frecuente ( 5%  Extra )";
            chbClienteFrecuente.UseVisualStyleBackColor = true;
            // 
            // gpbEntrega
            // 
            gpbEntrega.Controls.Add(rbNormal);
            gpbEntrega.Controls.Add(rbExpress);
            gpbEntrega.Location = new Point(16, 202);
            gpbEntrega.Name = "gpbEntrega";
            gpbEntrega.Size = new Size(348, 68);
            gpbEntrega.TabIndex = 14;
            gpbEntrega.TabStop = false;
            gpbEntrega.Text = "Entrega";
            // 
            // txtVehiculos
            // 
            txtVehiculos.Location = new Point(156, 163);
            txtVehiculos.Name = "txtVehiculos";
            txtVehiculos.Size = new Size(71, 23);
            txtVehiculos.TabIndex = 11;
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(156, 75);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(121, 23);
            txtPatente.TabIndex = 12;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(156, 29);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(190, 23);
            txtCliente.TabIndex = 13;
            // 
            // gpbImporte
            // 
            gpbImporte.Controls.Add(lblTotal);
            gpbImporte.Controls.Add(lblDescuento);
            gpbImporte.Controls.Add(lblRecargo);
            gpbImporte.Controls.Add(lblSubtotal);
            gpbImporte.Location = new Point(12, 389);
            gpbImporte.Name = "gpbImporte";
            gpbImporte.Size = new Size(382, 180);
            gpbImporte.TabIndex = 10;
            gpbImporte.TabStop = false;
            gpbImporte.Text = "Importe";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(31, 143);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total a pagar:";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(31, 106);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(66, 15);
            lblDescuento.TabIndex = 2;
            lblDescuento.Text = "Descuento:";
            // 
            // lblRecargo
            // 
            lblRecargo.AutoSize = true;
            lblRecargo.Location = new Point(31, 69);
            lblRecargo.Name = "lblRecargo";
            lblRecargo.Size = new Size(53, 15);
            lblRecargo.TabIndex = 1;
            lblRecargo.Text = "Recargo:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(31, 34);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(54, 15);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";
            // 
            // frmLavados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(406, 581);
            Controls.Add(gpbImporte);
            Controls.Add(gpbDatos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLavados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lavadero Los Andes - Calculo del servicio";
            gpbDatos.ResumeLayout(false);
            gpbDatos.PerformLayout();
            gpbEntrega.ResumeLayout(false);
            gpbEntrega.PerformLayout();
            gpbImporte.ResumeLayout(false);
            gpbImporte.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLimpiar;
        private Button btnCalcular;
        private ComboBox cboServicio;
        private RadioButton rbNormal;
        private RadioButton rbExpress;
        private Label lblCliente;
        private Label lblPatente;
        private Label lblServicio;
        private Label lblVehiculos;
        private GroupBox gpbDatos;
        private GroupBox gpbImporte;
        private TextBox txtVehiculos;
        private TextBox txtPatente;
        private TextBox txtCliente;
        private GroupBox gpbEntrega;
        private Label lblTotal;
        private Label lblDescuento;
        private Label lblRecargo;
        private Label lblSubtotal;
        private CheckBox chbClienteFrecuente;
    }
}