using System;
using System.Globalization;
using System.Windows.Forms;

namespace pryCalculoLavadero
{
    public partial class frmLavados : Form
    {
        // Formato argentino: siempre sale 42.000,00 sin importar la región de la PC
        private readonly CultureInfo formato = new CultureInfo("es-AR");

        public frmLavados()
        {
            InitializeComponent();
            CargarServicios();
            ConfigurarEventos();
            LimpiarImporte();
        }

        private void CargarServicios()
        {

            cboServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboServicio.Items.Clear();
            cboServicio.Items.AddRange(new object[]
            {
        "Lavado exterior", "Lavado completo", "Lavado con encerado"
            });
        
        }

        private void ConfigurarEventos()
        {
            // Se quitan antes de agregarse para no duplicarlos si ya están en el Designer
            txtPatente.KeyPress -= txtPatente_KeyPress;
            txtPatente.KeyPress += txtPatente_KeyPress;
            txtVehiculos.KeyPress -= txtVehiculos_KeyPress;
            txtVehiculos.KeyPress += txtVehiculos_KeyPress;
            btnCalcular.Click -= btnCalcular_Click;
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click -= btnLimpiar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
        }

        // 2.1 Patente: solo letras, dígitos y retroceso
        private void txtPatente_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // 2.1 Cantidad: solo dígitos y retroceso
        private void txtVehiculos_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnCalcular_Click(object? sender, EventArgs e)
        {
            // 2.2 Validaciones: ante un error, mensaje + foco + no calcular
            if (txtCliente.Text.Trim() == "")
            {
                MostrarError("Ingresá el nombre del cliente.", txtCliente);
                return;
            }

            int largoPatente = txtPatente.Text.Trim().Length;
            if (largoPatente < 6 || largoPatente > 7)
            {
                MostrarError("La patente debe tener 6 o 7 caracteres.", txtPatente);
                return;
            }

            if (cboServicio.SelectedIndex == -1)
            {
                MostrarError("Seleccioná un servicio.", cboServicio);
                return;
            }

            if (txtVehiculos.Text.Trim() == "")
            {
                MostrarError("Ingresá la cantidad de vehículos.", txtVehiculos);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtVehiculos.Text, out cantidad) || cantidad < 1 || cantidad > 5)
            {
                MostrarError("La cantidad de vehículos debe estar entre 1 y 5.", txtVehiculos);
                return;
            }

            if (!rbNormal.Checked && !rbExpress.Checked)
            {
                MostrarError("Seleccioná el tipo de entrega.", rbNormal);
                return;
            }

            // 2.3 Precio por vehículo
            decimal precio = ObtenerPrecio(cboServicio.SelectedItem!.ToString()!);
            decimal subtotal = precio * cantidad;

            // 2.4 Recargo por entrega express (25 % del subtotal)
            decimal recargo = 0;
            if (rbExpress.Checked)
                recargo = subtotal * 0.25m;

            // 2.4 Descuento por cantidad, más 5 si es cliente frecuente
            int porcDescuento = 0;
            if (cantidad >= 4)
                porcDescuento = 15;
            else if (cantidad >= 2)
                porcDescuento = 10;

            if (chbClienteFrecuente.Checked)
                porcDescuento += 5;

            decimal descuento = subtotal * porcDescuento / 100m;
            decimal total = subtotal + recargo - descuento;

            lblSubtotal.Text = "Subtotal: $ " + subtotal.ToString("N2", formato);
            lblRecargo.Text = "Recargo: $ " + recargo.ToString("N2", formato);
            lblDescuento.Text = "Descuento: " + porcDescuento + " % ($ " + descuento.ToString("N2", formato) + ")";
            lblTotal.Text = "Total a pagar: $ " + total.ToString("N2", formato);
        }

        // 2.3 Precio según el servicio (switch)
        private decimal ObtenerPrecio(string servicio)
        {
            switch (servicio)
            {
                case "Lavado exterior": return 8000;
                case "Lavado completo": return 14000;
                case "Lavado con encerado": return 20000;
                default: return 0;
            }
        }

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            txtCliente.Clear();
            txtPatente.Clear();
            txtVehiculos.Clear();
            cboServicio.SelectedIndex = -1;
            rbNormal.Checked = false;
            rbExpress.Checked = false;
            chbClienteFrecuente.Checked = false;
            LimpiarImporte();
            txtCliente.Focus();
        }

        private void frmLavados_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarImporte()
        {
            lblSubtotal.Text = "Subtotal:";
            lblRecargo.Text = "Recargo:";
            lblDescuento.Text = "Descuento:";
            lblTotal.Text = "Total a pagar:";
        }

    }
}