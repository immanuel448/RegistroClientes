using System;
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
            List<string> errores;

            // Validamos los datos utilizando la lógica que está en el Modelo
            if (data.EsValido(out errores))
            {
                // Si los datos son válidos, muestra un mensaje de éxito
                _vista.Mensaje("Se ha procesado correctamente.");
            }
            else
            {
                // Creamos el diccionario de errores asociados a los controles
                var erroresDict = new Dictionary<Control, string>();

                // Recorrer los errores y asociarlos con el control correspondiente
                foreach (var error in errores)
                {
                    // Asociamos cada error con el control correcto
                    if (error.Equals("El nombre es obligatorio."))
                        erroresDict.Add(_vista.txtNombreCli, error);
                    else if (error.Equals("El correo es obligatorio.") || error.Equals("El correo no es válido."))
                        erroresDict.Add(_vista.txtCorreoCli, error);
                    else if (error.Equals("La fecha de nacimiento es inválida.") || error.Equals("La edad debe ser mayor a 0.") || error.Equals("La fecha de nacimiento no puede ser en el futuro."))
                        erroresDict.Add(_vista.txtFechaNaciCli, error);
                    else if (error.Equals("El sexo es obligatorio."))
                        erroresDict.Add(_vista.radioSexoH, error); // Aquí también se podría poner el control de los radio buttons o el grupo en la vista
                    else if (error.Equals("La contraseña es obligatoria.") || error.Equals("La contraseña debe tener al menos 6 caracteres.") ||
                             error.Equals("La contraseña debe contener al menos una letra mayúscula.") ||
                             error.Equals("La contraseña debe contener al menos una letra minúscula.") ||
                             error.Equals("La contraseña debe contener al menos un número."))
                        erroresDict.Add(_vista.txtContraseCli, error);
                    else if (error.Equals("El teléfono es obligatorio.") || error.Equals("El teléfono debe tener 10 dígitos numéricos."))
                        erroresDict.Add(_vista.txtTelefonoCli, error);
                    else if (error.Equals("La dirección es obligatoria."))
                        erroresDict.Add(_vista.txtDireccionCli, error);
                }

                // Pasamos el diccionario a la vista para que el ErrorProvider pueda mostrar los errores
                _vista.MostrarErrores(erroresDict);
            }
        }
    }
}
