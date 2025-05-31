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
            txtID.TextChanged += TxtID_TextChanged;
            _controller = new FormController(this);  // Inicializamos el controlador
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar configuraciones adicionales si lo necesitas
        }


        // Evento que se ejecuta cuando el texto en txtID cambia eeeee no funciona
        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            // Asegúrate de que sender sea un control y no sea null
            if (sender is TextBox)
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    btnBuscar.Enabled = true;
                    btnBorrar.Enabled = true;
                }
                else
                {
                    btnBuscar.Enabled = false;
                    btnBorrar.Enabled = false;
                }
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //ocupa id y accion
            var datosCliente = new DatosClienteMetodos();
            datosCliente.Accion = "Buscar";  // Obtener los datos del formulario
            int id;
            if (int.TryParse(txtID.Text, out id))
            {
                datosCliente.Id = id;
                //se obtiene el dato
            }
            else
            {
                erroresMSJ.SetError(txtID, "El ID ingresado debe ser número positivo.");
            }
            _controller.ValidarYProcesarDatos(datosCliente);
            //eeee se debe de inhabilitar el botón de id despué de encotnrar datos
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var datosCliente = obtenerDatos("Insertar");  // Obtener los datos del formulario
            Mostrar(datosCliente);
            _controller.ValidarYProcesarDatos(datosCliente);  // Pasamos los datos al controlador para validación
            //desactivar boton de id 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var datosCliente = obtenerDatos("Actualizar");  // Obtener los datos del formulario
            Mostrar(datosCliente);//eeee pruebita
            _controller.RellenarVista(datosCliente);  // Pasamos los datos al controlador para validación
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        // Se obtiene los datos y se guardan en la clase del modelo
        private DatosClienteMetodos obtenerDatos(string accion)
        {
            erroresMSJ.Clear();
            var datosCliente = new DatosClienteMetodos();

            //no siempre se ocupa el id
            if (datosCliente.Accion == "Buscar" || datosCliente.Accion == "Borrar")
            {
                int id;
                if (int.TryParse(txtID.Text, out id))
                {
                    datosCliente.Id = id;
                    //se obtiene el dato
                }
                else
                {
                    erroresMSJ.SetError(txtID, "El ID ingresado debe ser número positivo.");
                }
            }

            datosCliente.Nombre = txtNombreCli.Text;
            datosCliente.Correo = txtCorreoCli.Text;
            datosCliente.Contrasenha = txtContraseCli.Text;
            datosCliente.Telefono = txtTelefonoCli.Text;
            datosCliente.Direccion = txtDireccionCli.Text;

            DateTime fecha;
            if (DateTime.TryParse(txtFechaNaciCli.Text, out fecha))
            {
                datosCliente.FechaNaci = fecha;
            }

            if (radioSexoH.Checked)
            {
                datosCliente.Sexo = "Hombre";
            }
            else if (radioSexoM.Checked)
            {
                datosCliente.Sexo = "Mujer";
            }
            else if (radioSexoSin.Checked)
            {
                datosCliente.Sexo = "Sin Espe";
            }
            else
            {
                datosCliente.Sexo = null;
            }
            datosCliente.Accion = accion;

            return datosCliente;
        }

        //eeeeee este método es una pruebita
        private void Mostrar(DatosClientes datosCliente)
        {
            MessageBox.Show($"id {datosCliente.Id}\n" +
                $"nombre {datosCliente.Nombre}\n" +
                $"correo {datosCliente.Correo}\n" +
                $"contrasenha {datosCliente.Contrasenha}\n" +
                $"telefono {datosCliente.Telefono}\n" +
                $"direccion {datosCliente.Direccion}\n" +
                $"sexo {datosCliente.Sexo}\n" +
                $"fecha {datosCliente.FechaNaci}\n" +
                $"accion {datosCliente.Accion}\n");
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

        // Método para limpiar todos los controles, genérico
        private void LimpiarControles(Control control)
        {
            erroresMSJ.Clear();
            foreach (Control c in control.Controls)
            {
                if (c is TextBox txt)
                    txt.Clear();
                else if (c is ComboBox combo)
                    combo.SelectedIndex = -1;
                else if (c is CheckBox check)
                    check.Checked = false;
                else if (c is RadioButton radio)
                    radio.Checked = false;
                else if (c is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;

                // Si el control tiene controles hijos (como un Panel o GroupBox)
                if (c.HasChildren)
                    LimpiarControles(c);
            }
        }
    }
}
