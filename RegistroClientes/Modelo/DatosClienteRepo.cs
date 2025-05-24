using System;
using System.Collections.Generic;

namespace RegistroClientes.Modelo
{
    internal class DatosClienteRepo
    {
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasenha { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNaci { get; set; }
        public string sexo { get; set; }
        public bool activo { get; set; }
        public string comentarios { get; set; }



        // Métodos de validación para las propiedades
        public bool EsValido(out List<string> errores)
        {
            errores = new List<string>();

            // Validaciones corregidas con las propiedades correctas

            // Nombre
            if (string.IsNullOrEmpty(nombre)) errores.Add("El nombre es obligatorio.");
            else if (nombre.Length < 3) errores.Add("El nombre debe tener al menos 3 caracteres.");

            // Correo
            if (string.IsNullOrEmpty(correo)) errores.Add("El correo es obligatorio.");
            else if (!correo.Contains("@")) errores.Add("El correo no es válido.");
            else if (!correo.Contains(".")) errores.Add("El correo debe contener un dominio válido.");

            // Contraseña
            if (string.IsNullOrEmpty(contrasenha))
            {
                errores.Add("La contraseña es obligatoria.");
            }
            else
            {
                try
                {
                    if (contrasenha.Length < 6)
                        errores.Add("La contraseña debe tener al menos 6 caracteres.");

                    else if (!System.Text.RegularExpressions.Regex.IsMatch(contrasenha, @"[A-Z]"))
                        errores.Add("La contraseña debe contener al menos una letra mayúscula.");

                    else if (!System.Text.RegularExpressions.Regex.IsMatch(contrasenha, @"[a-z]"))
                        errores.Add("La contraseña debe contener al menos una letra minúscula.");

                    else if (!System.Text.RegularExpressions.Regex.IsMatch(contrasenha, @"[0-9]"))
                        errores.Add("La contraseña debe contener al menos un número.");
                }
                catch (Exception ex)
                {
                    // Log de la excepción para ver si algo más está fallando
                    errores.Add($"Error al validar la contraseña: {ex.Message}");
                }
            }


            // Teléfono
            if (string.IsNullOrEmpty(telefono)) errores.Add("El teléfono es obligatorio.");
            else if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$")) // Validación simple para números de 10 dígitos
                errores.Add("El teléfono debe tener 10 dígitos numéricos.");

            // Dirección
            if (string.IsNullOrEmpty(direccion)) errores.Add("La dirección es obligatoria.");

            // Fecha de Nacimiento
            if (fechaNaci == default(DateTime)) errores.Add("La fecha de nacimiento es inválida.");
            else
            {
                var edad = DateTime.Now.Year - fechaNaci.Year;
                if (fechaNaci > DateTime.Now.AddYears(-edad)) edad--; // Ajusta si la fecha de nacimiento aún no ha pasado este año
                if (edad <= 0) errores.Add("La edad debe ser mayor a 0.");
                if (fechaNaci > DateTime.Now) errores.Add("La fecha de nacimiento no puede ser en el futuro.");
            }

            // Sexo
            if (string.IsNullOrEmpty(sexo)) errores.Add("El sexo es obligatorio.");

            // Devuelve verdadero si no hay errores
            return errores.Count == 0;
        }

    }
}
