using RegistroClientes.Controlador;
using RegistroClientes.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegistroClientes
{
    public partial class Form1 : Form
    {
        private FormController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new FormController(this);  // Inicializamos el controlador
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar configuraciones adicionales si lo necesitas
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var datosCliente = obtenerDatos();  // Obtener los datos del formulario
            //Mostrar(datosCliente);//eeee pruebita
            _controller.ValidarYProcesarDatos(datosCliente);  // Pasamos los datos al controlador para validación
        }

        // Se obtiene los datos y se guardan en la clase del modelo
        private DatosClienteRepo obtenerDatos()
        {
            erroresMSJ.Clear();

            var datosCliente = new DatosClienteRepo();
            datosCliente.nombre = txtNombreCli.Text;
            datosCliente.correo = txtCorreoCli.Text;
            datosCliente.contrasenha = txtContraseCli.Text;
            datosCliente.telefono = txtTelefonoCli.Text;
            datosCliente.direccion = txtDireccionCli.Text;

            DateTime fecha;
            if (DateTime.TryParse(txtFechaNaciCli.Text, out fecha))
            {
                datosCliente.fechaNaci = fecha;
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
                datosCliente.sexo = null;
            }

            return datosCliente;
        }

        //eeeeee este método es una pruebita
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

        // Método para mostrar errores con el ErrorProvider
        public void MostrarErrores(Dictionary<Control, string> errores)
        {
            erroresMSJ.Clear();  // Limpiamos los errores previos

            foreach (var error in errores)
            {
                // Mostramos el error en el control correspondiente
                erroresMSJ.SetError(error.Key, error.Value);
            }
        }

        public void Mensaje(string mensajeRecibido)
        {
            MessageBox.Show(mensajeRecibido);
        }
    }
}
