// Modelo
using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;


namespace RegistroClientes.Modelo
{
    public class DatosClienteMetodos : DatosClientes
    {

        internal DatosClienteMetodos(int id = 0, string nombre = "", string correo = "", string contrasenha = "", string telefono = "", string direccion = "", DateTime fechaNaci = default, string sexo = "", bool activo = false, string accion = "", string errores = null) : base (id, nombre, correo, contrasenha, telefono, direccion, fechaNaci, sexo, activo, accion, errores){}

        public bool EsValido(out Dictionary<string, List<string>> errores, string accion)
        {
            errores = new Dictionary<string, List<string>>();
            List<string> erroresGenerales = new List<string>();

            var accionesValidas = new[] { "Buscar", "Insertar", "Borrar", "Actualizar" };
            if (!accionesValidas.Contains(accion))
            {
                errores["accion"] = new List<string> { $"La acción '{accion}' no es válida." };
                return false;
            }

            // Validaciones según acción
            //id
            if (accion != "Insertar")
            {
                if (Id <= 0)
                {
                    errores["id"] = new List<string> { "El Id no es válido." };
                }
            }

            if (accion == "Insertar" || accion == "Actualizar")
            {
                //activo eeeee
                if (Activo == null)
                {
                    errores["activo"] = new List<string> { "Debe seleccionar una opción para el campo activo." };
                }

                // nombre
                if (string.IsNullOrEmpty(Nombre))
                {
                    erroresGenerales.Add("El nombre es obligatorio.");
                }
                if (!string.IsNullOrEmpty(Nombre) && Nombre.Length < 3)
                {
                    erroresGenerales.Add("El nombre debe tener mínimo 3 caracteres");
                }
                if (erroresGenerales.Count > 0) errores["nombre"] = new List<string>(erroresGenerales);

                // correo
                erroresGenerales.Clear();
                if (string.IsNullOrEmpty(Correo))
                {
                    erroresGenerales.Add("El correo es obligatorio.");
                }
                else if (!Correo.Contains("@") || !Correo.Contains("."))
                {
                    erroresGenerales.Add("El correo no es válido.");
                }
                if (erroresGenerales.Count > 0) errores["correo"] = new List<string>(erroresGenerales);

                // contraseña
                erroresGenerales.Clear();
                if (string.IsNullOrEmpty(Contrasenha))
                {
                    erroresGenerales.Add("La contraseña es obligatoria.");
                }
                if (!string.IsNullOrEmpty(Contrasenha))
                {
                    if (Contrasenha.Length < 6)
                        erroresGenerales.Add("Debe tener al menos 6 caracteres.");
                    if (!Regex.IsMatch(Contrasenha, @"[A-Z]"))
                        erroresGenerales.Add("Debe contener al menos una mayúscula.");
                    if (!Regex.IsMatch(Contrasenha, @"[a-z]"))
                        erroresGenerales.Add("Debe contener al menos una minúscula.");
                    if (!Regex.IsMatch(Contrasenha, @"[0-9]"))
                        erroresGenerales.Add("Debe contener al menos un número.");
                }
                if (erroresGenerales.Count > 0) errores["contrasenha"] = new List<string>(erroresGenerales);

                // teléfono
                erroresGenerales.Clear();
                string sinEspaciosTelefono = Telefono?.Replace(" ", "") ?? "";
                if (string.IsNullOrEmpty(sinEspaciosTelefono) || !Regex.IsMatch(sinEspaciosTelefono, @"^\d{10}$"))
                {
                    errores["telefono"] = new List<string> { "Teléfono debe tener 10 dígitos." };
                }

                // dirección
                erroresGenerales.Clear();
                if (string.IsNullOrEmpty(Direccion))
                {
                    erroresGenerales.Add("La dirección es obligatoria.");
                }
                if (!string.IsNullOrEmpty(Direccion) && Direccion.Length > 50)
                {
                    erroresGenerales.Add("La dirección debe tener menos de 50 caracteres.");
                }
                if (erroresGenerales.Count > 0) errores["direccion"] = new List<string>(erroresGenerales);

                // fecha de nacimiento
                erroresGenerales.Clear();
                if (FechaNaci == default || FechaNaci > DateTime.Now)
                {
                    erroresGenerales.Add("Fecha de nacimiento inválida.");
                }
                else
                {
                    var edad = DateTime.Now.Year - FechaNaci.Year;
                    if (FechaNaci > DateTime.Now.AddYears(-edad)) edad--;
                    if (edad <= 0) erroresGenerales.Add("La edad debe ser mayor a 0.");
                }
                if (erroresGenerales.Count > 0) errores["fechaNaci"] = new List<string>(erroresGenerales);

                // sexo
                if (string.IsNullOrEmpty(Sexo))
                {
                    errores["sexo"] = new List<string> { "El sexo es obligatorio." };
                }
            }
            return errores.Count == 0;
        }

        public string datosBD()
        {
            try
            {
                // Construir configuración para leer appsettings.json
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                IConfiguration configuration = builder.Build();

                // Obtener cadena de conexión desde el archivo
                return configuration.GetConnectionString("MiConexionSQL");

            }
            catch (Exception ex)
            {
                return "Error con los datos para conectar con la BD";
            }
        }

        //métodos para interactuar con la BD -----------------------------------------------
        //método exclusivo para seleccionar datos de la BD
        public DatosClienteMetodos Seleccionar(string datosBD, string instruccion, SqlParameter[] parametros)
        {
            var resultados = new DatosClienteMetodos();
            try
            {
                using (SqlConnection conexion = new SqlConnection(datosBD))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(instruccion, conexion))
                    {
                        comando.Parameters.AddRange(parametros);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    //se guardan los datos
                                    resultados.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                    resultados.Nombre = reader.IsDBNull(1) ? "vacío" : reader.GetString(1);
                                    resultados.Correo = reader.IsDBNull(2) ? "vacío" : reader.GetString(2);
                                    resultados.Contrasenha = reader.IsDBNull(3) ? "vacío" : reader.GetString(3);
                                    resultados.Telefono = reader.IsDBNull(4) ? "vacío" : reader.GetString(4);
                                    resultados.Direccion = reader.IsDBNull(5) ? "vacío" : reader.GetString(5);
                                    resultados.FechaNaci = reader.IsDBNull(6) ? default : reader.GetDateTime(6);
                                    resultados.Sexo = reader.IsDBNull(7) ? "vacío" : reader.GetString(7);
                                    //eeee
                                    resultados.Activo = reader.IsDBNull(8) ? false : reader.GetBoolean(8);
                                }
                            }
                            else
                            {
                                resultados.Errores = "No se encontraron datos.";
                            }  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Errores = $"Error (Buscar/Seleccionar): {ex.Message}";
            }
            return resultados;
        }

        //Método común para Create, Update y Delete
        public string Modificar_guardar(string accion, string datosBD, string instruccion, SqlParameter[] parametros)
        {
            string errores = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(datosBD))
                {
                    conexion.Open();

                    // Si es Insertar, se agrega la instrucción para obtener el ID generado
                    if (accion == "Insertar")
                        instruccion += "; SELECT SCOPE_IDENTITY();";

                    using (SqlCommand comando = new SqlCommand(instruccion, conexion))
                    {
                        comando.Parameters.AddRange(parametros);
                            
                        if (accion == "Insertar")
                        {
                            //para insertar devuelve el Id que le corresponde al nuevo campo
                            object idGenerado = comando.ExecuteScalar();
                            return idGenerado != null ? $"{idGenerado}" : "No se pudo obtener el ID insertado.";
                        }
                        else
                        {
                            //para borrar, actualizar
                            int resultadoConsulta = comando.ExecuteNonQuery();
                            return resultadoConsulta > 0
                                ? $"Éxito al {accion.ToLower()}"
                                : $"No realizó ninguna acción al intentar {accion.ToLower()}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               errores = $"Error: {ex.Message}";
            }
            return errores;
        }
    }
}