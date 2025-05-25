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

        public bool EsValido(out Dictionary<string, string> errores)
        {
            errores = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(nombre))
                errores["nombre"] = "El nombre es obligatorio.";
            else if (nombre.Length < 3)
                errores["nombre"] = "El nombre debe tener al menos 3 caracteres.";

            if (string.IsNullOrEmpty(correo))
                errores["correo"] = "El correo es obligatorio.";
            else if (!correo.Contains("@") || !correo.Contains("."))
                errores["correo"] = "El correo no es válido.";

            if (string.IsNullOrEmpty(contrasenha))
                errores["contrasenha"] = "La contraseña es obligatoria.";
            else
            {
                if (contrasenha.Length < 6)
                    errores["contrasenha"] = "La contraseña debe tener al menos 6 caracteres.";
                else if (!Regex.IsMatch(contrasenha, @"[A-Z]"))
                    errores["contrasenha"] = "Debe contener al menos una mayúscula.";
                else if (!Regex.IsMatch(contrasenha, @"[a-z]"))
                    errores["contrasenha"] = "Debe contener al menos una minúscula.";
                else if (!Regex.IsMatch(contrasenha, @"[0-9]"))
                    errores["contrasenha"] = "Debe contener al menos un número.";
            }

            if (string.IsNullOrEmpty(telefono) || !Regex.IsMatch(telefono, @"^\d{10}$"))
                errores["telefono"] = "Teléfono debe tener 10 dígitos.";

            if (string.IsNullOrEmpty(direccion))
                errores["direccion"] = "La dirección es obligatoria.";

            if (fechaNaci == default || fechaNaci > DateTime.Now)
                errores["fechaNaci"] = "Fecha de nacimiento inválida.";
            else
            {
                var edad = DateTime.Now.Year - fechaNaci.Year;
                if (fechaNaci > DateTime.Now.AddYears(-edad)) edad--;
                if (edad <= 0) errores["fechaNaci"] = "Edad debe ser mayor a 0.";
            }

            if (string.IsNullOrEmpty(sexo) || sexo == "No ha seleccionado nada")
                errores["sexo"] = "El sexo es obligatorio.";

            return errores.Count == 0;
        }
    }
}