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
            txtID.TextChanged += TxtID_TextChanged;//revisa cambios en este elemento
            TxtID_TextChanged(txtID, EventArgs.Empty); // Llamada manual para evaluar estado inicial
            radioNo.CheckedChanged += RadioNo_CheckedChanged;//revisa cambios en este elemento
            _controller = new FormController(this);  // Inicializamos el controlador
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // buuu!!!
        }


        // Evento que se ejecuta cuando el texto en txtID cambia
        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            // Sender debe ser un control, no null
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

        private void RadioNo_CheckedChanged(object sender, EventArgs e)
        {
            // Solo actuar si el botón fue marcado (no cuando se desmarca)
            if (radioNo.Checked)
            {
                var confirmacion = MessageBox.Show(
                    "¿Estás seguro de que deseas marcar este registro como inactivo?",
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.No)
                {
                    // Revertir la selección si el usuario cancela
                    radioNo.Checked = false;
                    radioSi.Checked = true;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this, true);
            //ocupa id y accion
            var datosCliente = obtenerDatos("Buscar");  // Obtener los datos del formulario
            _controller.ValidarYProcesarDatos(datosCliente);  // Pasamos los datos al controlador para validación y ejecutar la consulta
            //se inhabilita el botón del id después de encontrar datos
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje de confirmación antes de borrar
            var confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas borrar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No)
            {
                // Si el usuario cancela, no se hace nada
                return;
            }

            LimpiarFormulario(this, true);
            //ocupa id y accion
            var datosCliente = obtenerDatos("Borrar");  // Obtener los datos del formulario
            _controller.ValidarYProcesarDatos(datosCliente);  // Pasamos los datos al controlador para validación y ejecutar la consulta
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //debe devolver el id con el que se insertaron los datos
            txtID.Text = "";
            var datosCliente = obtenerDatos("Insertar");  // Obtener los datos del formulario
            _controller.ValidarYProcesarDatos(datosCliente);
            //desactivar text de id 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var datosCliente = obtenerDatos("Actualizar");  // Obtener los datos del formulario
            _controller.ValidarYProcesarDatos(datosCliente);  // Pasamos los datos al controlador para validación y ejecutar la consulta
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this);
        }

        // Se obtiene los datos y se guardan en la clase del modelo
        private DatosClienteMetodos obtenerDatos(string accion)
        {
            erroresMSJ.Clear();
            var datosCliente = new DatosClienteMetodos();
            datosCliente.Accion = accion; //se debe colocar este dato al entrar a este método

            // sólo se ocupa para buscar y para borrar
            if (datosCliente.Accion == "Buscar" || datosCliente.Accion == "Borrar" || datosCliente.Accion == "Actualizar")
            {
                int id;
                if (int.TryParse(txtID.Text, out id) && id > 0)
                {
                    datosCliente.Id = id;
                    //se obtiene el dato
                }
                else
                {
                    erroresMSJ.SetError(txtID, "El ID ingresado debe ser número positivo.");
                }

                if (datosCliente.Accion != "Actualizar")
                {
                    //solo con "Actualizar" continúa
                    return datosCliente;
                }
            }

            datosCliente.Nombre = txtNombreCli.Text;
            datosCliente.Correo = txtCorreoCli.Text;
            datosCliente.Contrasenha = txtContraseCli.Text;
            datosCliente.Telefono = txtTelefonoCli.Text;
            datosCliente.Direccion = txtDireccionCli.Text;
            //fecha nacimiento
            DateTime fecha;
            if (DateTime.TryParse(txtFechaNaciCli.Text, out fecha))
            {
                datosCliente.FechaNaci = fecha;
            }
            //sexo
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

            //activo eeeee
            if (radioSi.Checked)
            {
                datosCliente.Activo = true;
            }
            else if (radioNo.Checked)
            {
                datosCliente.Activo = false;
            }
            else
            {
                datosCliente.Activo = null;
            }

            //Acción
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
                $"activo {datosCliente.Activo}\n" +
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

        public void LimpiarFormulario(Control control, bool omitirID = false)
        {
            erroresMSJ.Clear();
            txtID.Enabled = true;

            foreach (Control c in control.Controls)
            {
                // Si es el TextBox que quieres conservar, lo saltas
                if (c == txtID && omitirID)
                    continue;

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

                // Llamada recursiva si tiene hijos
                if (c.HasChildren)
                    LimpiarFormulario(c, omitirID);
            }
        }
    }
}
