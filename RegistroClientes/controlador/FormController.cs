// Controlador
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using RegistroClientes.Modelo;

namespace RegistroClientes.Controlador
{
    internal class FormController
    {
        //se crea un objeto de la vista, ya que el controlador interactúa directamente con esta capa
        private Form1 _vista;
        private readonly DatosClienteMetodos _repositorio;

        // Constructor de la clase
        public FormController(Form1 vista)
        {
            _vista = vista;
            _repositorio = new DatosClienteMetodos();
        }


        public void ValidarYProcesarDatos(DatosClienteMetodos datosDelFormulario)
        {
            if (datosDelFormulario.EsValido(out var erroresAlValidar))
            {
                //sin errores
                _vista.Mensaje("Se ha procesado correctamente.");
            }
            else
            {
                //con  errores
                var erroresDict = new Dictionary<Control, string>();

                foreach (var error in erroresAlValidar)
                {
                    //se concatenan TODOS los mensajes para cada ciclo
                    string mensajeUnido = string.Join("\n", error.Value);
                    switch (error.Key)
                    {
                        case "nombre":
                            erroresDict[_vista.txtNombreCli] = mensajeUnido;
                            break;
                        case "correo":
                            erroresDict[_vista.txtCorreoCli] = mensajeUnido;
                            break;
                        case "contrasenha":
                            erroresDict[_vista.txtContraseCli] = mensajeUnido;
                            break;
                        case "telefono":
                            erroresDict[_vista.txtTelefonoCli] = mensajeUnido;
                            break;
                        case "direccion":
                            erroresDict[_vista.txtDireccionCli] = mensajeUnido;
                            break;
                        case "fechaNaci":
                            erroresDict[_vista.txtFechaNaciCli] = mensajeUnido;
                            break;
                        case "sexo":
                            erroresDict[_vista.grupoSexo] = mensajeUnido;
                            break;
                    }
                }
                //se insertan los errores en las áreas correspondientes
                _vista.MostrarErrores(erroresDict);
            }
        }
    }
}
