using RegistroClientes.Modelo;
using System.Drawing.Text;
using System.Windows.Forms;

namespace RegistroClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Mostrar(obtenerDatos());
        }

        private DatosClienteRepo obtenerDatos()
        {
            var datosCliente = new DatosClienteRepo();
            datosCliente.nombre = txtNombreCli.Text;
            datosCliente.correo = txtCorreoCli.Text;
            datosCliente.contrasenha = txtContraseCli.Text;
            datosCliente.telefono = txtTelefonoCli.Text;
            datosCliente.direccion = txtDireccionCli.Text;
            DateTime fecha;
            if (DateTime.TryParse(txtFechaNaciCli.Text, out fecha))
            {
                erroresMSJ.SetError(txtFechaNaciCli, ""); // Limpia el error si es válido
                datosCliente.fechaNaci = fecha;
            }
            else
            {
                // Manejar error si la fecha no es válida
                erroresMSJ.SetError(txtFechaNaciCli, "Fecha no válida");
            }


            if (radioSexoH.Checked)
            {
                datosCliente.sexo = "Hombre";
            }
            else if (radioSexoM.Checked)
            {
                datosCliente.sexo = "Mujer";
            }
            else if (radioSexoSin.Checked)
            {
                datosCliente.sexo = "No especificado";
            }
            else
            {
                datosCliente.sexo = "No ha seleccionado nada";
            }
            return datosCliente;
        }

        private void Mostrar(DatosClienteRepo datosCliente)
        {
            MessageBox.Show($"nombre {datosCliente.nombre}\n" +
                $"correo {datosCliente.correo}\n" +
                $"contrasenha {datosCliente.contrasenha}\n" +
                $"telefono {datosCliente.telefono}\n" +
                $"direccion {datosCliente.direccion}\n" +
                $"sexo {datosCliente.sexo}\n" +
                $"fecha {datosCliente.fechaNaci}\n");
        }
    }
}
