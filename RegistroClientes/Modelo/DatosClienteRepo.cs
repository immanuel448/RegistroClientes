// Modelo
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public bool EsValido(out Dictionary<string, List <string>> errores)
        {
            //validaciones --------------------------------------
            errores = new Dictionary<string, List<string>>();
            List<string> erroresGenerales = new List<string>();

            //nombre
            if (string.IsNullOrEmpty(nombre))
            {
                erroresGenerales.Add("El nombre es obligatorio.");
            }
            if (nombre.Length < 3)
            {
                erroresGenerales.Add("El nombre debe de tener mínimo 3 caracteres");
            }
            //se colocan en la lista para regresar
            if(erroresGenerales.Count > 0) errores["nombre"] = new List<string>(erroresGenerales);

            //correo
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(correo))
            {
                erroresGenerales.Add("El correo es obligatorio.");
            }
            else if (!correo.Contains("@") || !correo.Contains("."))
                erroresGenerales.Add("El correo no es válido.");
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["correo"] = new List<string>(erroresGenerales);

            //contraseña
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(contrasenha))
            {
                erroresGenerales.Add("La contraseña es obligatoria.");
            }
            if (contrasenha.Length < 6)
                erroresGenerales.Add("La contraseña debe tener al menos 6 caracteres.");
            if (!Regex.IsMatch(contrasenha, @"[A-Z]"))
                erroresGenerales.Add("Debe contener al menos una mayúscula.");
            if (!Regex.IsMatch(contrasenha, @"[a-z]"))
                erroresGenerales.Add("Debe contener al menos una minúscula.");
            if (!Regex.IsMatch(contrasenha, @"[0-9]"))
                erroresGenerales.Add("Debe contener al menos un número.");
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["contrasenha"] = new List<string>(erroresGenerales);

            //teléfono 
            erroresGenerales.Clear();
            string sinEspaciosTelefono = telefono.Replace(" ", "");
            if (string.IsNullOrEmpty(sinEspaciosTelefono) || !Regex.IsMatch(sinEspaciosTelefono, @"^\d{10}$"))
            {
                errores["telefono"] = new List<string>{"Teléfono debe tener 10 dígitos."};
            }

            //direccion
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(direccion))
            {
                erroresGenerales.Add("La dirección es obligatoria.");
            }
            if (direccion.Length >50)
            {
                erroresGenerales.Add("La dirección debe de contener menos de 50 caracteres.");
            }
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["direccion"] = new List<string>(erroresGenerales);

            //fecha de nacimiento
            erroresGenerales.Clear();
            if (fechaNaci == default || fechaNaci > DateTime.Now)
            {

                erroresGenerales.Add("Fecha de nacimiento inválida.");
            }
            else
            {
                //se calcula la edad
                var edad = DateTime.Now.Year - fechaNaci.Year;
                //se hace el ajuste exacto por mes
                if (fechaNaci > DateTime.Now.AddYears(-edad)) edad--;
                if (edad <= 0) erroresGenerales.Add("La edad debe ser mayor a 0.");
            }
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["fechaNaci"] = new List<string>(erroresGenerales);

            //sexo
            if (string.IsNullOrEmpty(sexo) || sexo == null)
                errores["sexo"] = new List<string> { "El sexo es obligatorio." };

            // si hay errores (false) donde se invocó este método van a obtener un diccionario con los errores
            return errores.Count == 0;
        }
    }
}