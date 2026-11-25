using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace pryCalculoLavadero
{
    public partial class frmLavados : Form
    {

        private readonly CultureInfo formato = new CultureInfo("es-AR");

        private readonly List<Lavado> lavados = new List<Lavado>();


        private readonly Button btnRegistrar = new Button();
        private readonly ListView lsvLavados = new ListView();
        private readonly Label lblRecExterior = new Label();
        private readonly Label lblRecCompleto = new Label();
        private readonly Label lblRecEncerado = new Label();
        private readonly Label lblRecNormal = new Label();
        private readonly Label lblRecExpress = new Label();
        private readonly Label lblRecTotal = new Label();
        private readonly Label lblConsultaPatente = new Label();
        private readonly TextBox txtConsultaPatente = new TextBox();
        private readonly Button btnConsultar = new Button();
        private readonly ListView lsvConsulta = new ListView();
        private readonly Label lblConsultaCant = new Label();

        public frmLavados()
        {
            InitializeComponent();
            CrearControlesExtra();
            CargarServicios();
            LimpiarImporte();
            ActualizarRecaudacion();
            ConfigurarEventos();
        }



        private void CrearControlesExtra()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            txtPatente.CharacterCasing = CharacterCasing.Upper;


            int ancho = (gpbDatos.ClientSize.Width - 24 - 16) / 3;
            btnCalcular.SetBounds(12, btnCalcular.Top, ancho, btnCalcular.Height);
            btnRegistrar.Text = "Registrar";
            btnRegistrar.SetBounds(12 + ancho + 8, btnCalcular.Top, ancho, btnCalcular.Height);
            btnLimpiar.SetBounds(12 + 2 * (ancho + 8), btnCalcular.Top, ancho, btnCalcular.Height);
            gpbDatos.Controls.Add(btnRegistrar);
            btnCalcular.TabIndex = 20;
            btnRegistrar.TabIndex = 21;
            btnLimpiar.TabIndex = 22;


            int izq = Math.Max(gpbDatos.Right, gpbImporte.Right) + 12;
            int anchoDer = 520;
            ClientSize = new Size(izq + anchoDer + 12, Math.Max(gpbImporte.Bottom, 562) + 12);


            GroupBox gpbLavados = CrearGrupo("Lavados del día", izq, 12, anchoDer, 190);
            ConfigurarLista(lsvLavados);
            lsvLavados.Dock = DockStyle.Fill;
            gpbLavados.Controls.Add(lsvLavados);


            GroupBox gpbRecaudacion = CrearGrupo("Recaudación", izq, 212, anchoDer, 140);
            ConfigurarLabel(new Label(), "Por servicio", 12, 22, gpbRecaudacion);
            ConfigurarLabel(lblRecExterior, "", 12, 44, gpbRecaudacion);
            ConfigurarLabel(lblRecCompleto, "", 12, 66, gpbRecaudacion);
            ConfigurarLabel(lblRecEncerado, "", 12, 88, gpbRecaudacion);
            ConfigurarLabel(new Label(), "Por tipo de entrega", 270, 22, gpbRecaudacion);
            ConfigurarLabel(lblRecNormal, "", 270, 44, gpbRecaudacion);
            ConfigurarLabel(lblRecExpress, "", 270, 66, gpbRecaudacion);
            ConfigurarLabel(lblRecTotal, "", 12, 112, gpbRecaudacion);
            lblRecTotal.Font = new Font(Font, FontStyle.Bold);


            GroupBox gpbConsulta = CrearGrupo("Consulta por patente", izq, 362, anchoDer, 200);
            ConfigurarLabel(lblConsultaPatente, "Patente:", 12, 29, gpbConsulta);
            txtConsultaPatente.SetBounds(75, 25, 110, 23);
            txtConsultaPatente.MaxLength = 7;
            txtConsultaPatente.CharacterCasing = CharacterCasing.Upper;
            gpbConsulta.Controls.Add(txtConsultaPatente);
            btnConsultar.Text = "Consultar";
            btnConsultar.SetBounds(195, 23, 90, 27);
            gpbConsulta.Controls.Add(btnConsultar);
            ConfigurarLista(lsvConsulta);
            lsvConsulta.SetBounds(12, 58, anchoDer - 24, 106);
            gpbConsulta.Controls.Add(lsvConsulta);
            ConfigurarLabel(lblConsultaCant, "", 12, 172, gpbConsulta);
        }

        private GroupBox CrearGrupo(string titulo, int x, int y, int ancho, int alto)
        {
            GroupBox grupo = new GroupBox();
            grupo.Text = titulo;
            grupo.SetBounds(x, y, ancho, alto);
            Controls.Add(grupo);
            return grupo;
        }

        private void ConfigurarLabel(Label label, string texto, int x, int y, Control padre)
        {
            label.Text = texto;
            label.AutoSize = true;
            label.Location = new Point(x, y);
            padre.Controls.Add(label);
        }

        private void ConfigurarLista(ListView lista)
        {
            lista.View = View.Details;
            lista.FullRowSelect = true;
            lista.GridLines = true;
            lista.Columns.Add("Cliente", 85);
            lista.Columns.Add("Patente", 65);
            lista.Columns.Add("Servicio", 110);
            lista.Columns.Add("Cant.", 40);
            lista.Columns.Add("Entrega", 60);
            lista.Columns.Add("Frec.", 40);
            lista.Columns.Add("Total", 80);
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

            txtPatente.KeyPress -= txtPatente_KeyPress;
            txtPatente.KeyPress += txtPatente_KeyPress;
            txtVehiculos.KeyPress -= txtVehiculos_KeyPress;
            txtVehiculos.KeyPress += txtVehiculos_KeyPress;
            btnCalcular.Click -= btnCalcular_Click;
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click -= btnLimpiar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            txtConsultaPatente.KeyPress += txtPatente_KeyPress;
            btnRegistrar.Click += btnRegistrar_Click;
            btnConsultar.Click += btnConsultar_Click;
        }


        private void txtPatente_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtVehiculos_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }



        private void btnCalcular_Click(object? sender, EventArgs e)
        {
            CalcularLavado();
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            Lavado? lavado = CalcularLavado();
            if (lavado == null)
                return;

            lavados.Add(lavado);
            lsvLavados.Items.Add(CrearFila(lavado));
            ActualizarRecaudacion();

            MessageBox.Show("Lavado registrado. Total a pagar: " + Moneda(lavado.Total),
                "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            string patente = txtConsultaPatente.Text.Trim().ToUpper();
            if (patente.Length < 6 || patente.Length > 7)
            {
                MostrarError("Ingresá una patente de 6 o 7 caracteres.", txtConsultaPatente);
                return;
            }

            lsvConsulta.Items.Clear();
            int veces = 0;
            foreach (Lavado lavado in lavados)
            {
                if (lavado.Patente == patente)
                {
                    lsvConsulta.Items.Add(CrearFila(lavado));
                    veces++;
                }
            }

            if (veces == 0)
                lblConsultaCant.Text = "No hay lavados registrados para esa patente.";
            else
                lblConsultaCant.Text = "Lavados de esta patente: " + veces;
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private Lavado? CalcularLavado()
        {
    
            if (txtCliente.Text.Trim() == "")
            {
                MostrarError("Ingresá el nombre del cliente.", txtCliente);
                return null;
            }

            int largoPatente = txtPatente.Text.Trim().Length;
            if (largoPatente < 6 || largoPatente > 7)
            {
                MostrarError("La patente debe tener 6 o 7 caracteres.", txtPatente);
                return null;
            }

            if (cboServicio.SelectedIndex == -1)
            {
                MostrarError("Seleccioná un servicio.", cboServicio);
                return null;
            }

            if (txtVehiculos.Text.Trim() == "")
            {
                MostrarError("Ingresá la cantidad de vehículos.", txtVehiculos);
                return null;
            }

            int cantidad;
            if (!int.TryParse(txtVehiculos.Text, out cantidad) || cantidad < 1 || cantidad > 5)
            {
                MostrarError("La cantidad de vehículos debe estar entre 1 y 5.", txtVehiculos);
                return null;
            }

            if (!rbNormal.Checked && !rbExpress.Checked)
            {
                MostrarError("Seleccioná el tipo de entrega.", rbNormal);
                return null;
            }


            string servicio = cboServicio.SelectedItem!.ToString()!;
            decimal subtotal = ObtenerPrecio(servicio) * cantidad;


            decimal recargo = 0;
            if (rbExpress.Checked)
                recargo = subtotal * 0.25m;


            int porcDescuento = 0;
            if (cantidad >= 4)
                porcDescuento = 15;
            else if (cantidad >= 2)
                porcDescuento = 10;

            if (chbClienteFrecuente.Checked)
                porcDescuento += 5;

            decimal descuento = subtotal * porcDescuento / 100m;
            decimal total = subtotal + recargo - descuento;


            lblSubtotal.Text = "Subtotal: " + Moneda(subtotal);
            lblRecargo.Text = "Recargo: " + Moneda(recargo);
            lblDescuento.Text = "Descuento: " + porcDescuento + " % (" + Moneda(descuento) + ")";
            lblTotal.Text = "Total a pagar: " + Moneda(total);

            return new Lavado
            {
                Cliente = txtCliente.Text.Trim(),
                Patente = txtPatente.Text.Trim().ToUpper(),
                Servicio = servicio,
                Cantidad = cantidad,
                Entrega = rbExpress.Checked ? "Express" : "Normal",
                Frecuente = chbClienteFrecuente.Checked,
                Subtotal = subtotal,
                Recargo = recargo,
                PorcDescuento = porcDescuento,
                Descuento = descuento,
                Total = total
            };
        }


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



        private void ActualizarRecaudacion()
        {
            decimal exterior = 0, completo = 0, encerado = 0, normal = 0, express = 0;

            foreach (Lavado lavado in lavados)
            {
                switch (lavado.Servicio)
                {
                    case "Lavado exterior": exterior += lavado.Total; break;
                    case "Lavado completo": completo += lavado.Total; break;
                    case "Lavado con encerado": encerado += lavado.Total; break;
                }

                if (lavado.Entrega == "Express")
                    express += lavado.Total;
                else
                    normal += lavado.Total;
            }

            lblRecExterior.Text = "Lavado exterior: " + Moneda(exterior);
            lblRecCompleto.Text = "Lavado completo: " + Moneda(completo);
            lblRecEncerado.Text = "Lavado con encerado: " + Moneda(encerado);
            lblRecNormal.Text = "Entrega normal: " + Moneda(normal);
            lblRecExpress.Text = "Entrega express: " + Moneda(express);
            lblRecTotal.Text = "Recaudación total: " + Moneda(normal + express);
        }

 

        private string Moneda(decimal valor)
        {
            return "$ " + valor.ToString("N2", formato);
        }

        private ListViewItem CrearFila(Lavado lavado)
        {
            return new ListViewItem(new string[]
            {
                lavado.Cliente,
                lavado.Patente,
                lavado.Servicio,
                lavado.Cantidad.ToString(),
                lavado.Entrega,
                lavado.Frecuente ? "Sí" : "No",
                Moneda(lavado.Total)
            });
        }

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void LimpiarImporte()
        {
            lblSubtotal.Text = "Subtotal:";
            lblRecargo.Text = "Recargo:";
            lblDescuento.Text = "Descuento:";
            lblTotal.Text = "Total a pagar:";
        }


        private void LimpiarFormulario()
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
    }


    public class Lavado
    {
        public string Cliente { get; set; } = "";
        public string Patente { get; set; } = "";
        public string Servicio { get; set; } = "";
        public int Cantidad { get; set; }
        public string Entrega { get; set; } = "";
        public bool Frecuente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Recargo { get; set; }
        public int PorcDescuento { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}