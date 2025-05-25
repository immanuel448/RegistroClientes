// Controlador
using System.Collections.Generic;
using System.Windows.Forms;
using RegistroClientes.Modelo;

namespace RegistroClientes.Controlador
{
    internal class FormController
    {
        private Form1 _vista;

        public FormController(Form1 vista)
        {
            _vista = vista;
        }

        public void ValidarYProcesarDatos(DatosClienteRepo data)
        {
            if (data.EsValido(out var errores))
            {
                _vista.Mensaje("Se ha procesado correctamente.");
            }
            else
            {
                var erroresDict = new Dictionary<Control, string>();

                foreach (var error in errores)
                {
                    switch (error.Key)
                    {
                        case "nombre":
                            erroresDict[_vista.txtNombreCli] = error.Value;
                            break;
                        case "correo":
                            erroresDict[_vista.txtCorreoCli] = error.Value;
                            break;
                        case "contrasenha":
                            erroresDict[_vista.txtContraseCli] = error.Value;
                            break;
                        case "telefono":
                            erroresDict[_vista.txtTelefonoCli] = error.Value;
                            break;
                        case "direccion":
                            erroresDict[_vista.txtDireccionCli] = error.Value;
                            break;
                        case "fechaNaci":
                            erroresDict[_vista.txtFechaNaciCli] = error.Value;
                            break;
                        case "sexo":
                            erroresDict[_vista.grupoSexo] = error.Value;
                            break;
                    }
                }

                _vista.MostrarErrores(erroresDict);
            }
        }
    }
}
