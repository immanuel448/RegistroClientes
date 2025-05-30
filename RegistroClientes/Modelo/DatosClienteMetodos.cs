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

        public bool EsValido(out Dictionary<string, List <string>> errores, bool pedirID = false)
        {
            //validaciones --------------------------------------
            errores = new Dictionary<string, List<string>>();
            List<string> erroresGenerales = new List<string>();

            //id
            if (pedirID == true)
            {
                if (Id <= 0)
                {
                    errores["id"] = new List<string> { "El Id no es válido." };
                }
                    return errores.Count == 0;
            }

            //nombre
            if (string.IsNullOrEmpty(Nombre))
            {
                erroresGenerales.Add("El nombre es obligatorio.");
            }
            if (Nombre.Length < 3)
            {
                erroresGenerales.Add("El nombre debe de tener mínimo 3 caracteres");
            }
            //se colocan en la lista para regresar
            if(erroresGenerales.Count > 0) errores["nombre"] = new List<string>(erroresGenerales);

            //correo
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(Correo))
            {
                erroresGenerales.Add("El correo es obligatorio.");
            }
            else if (!Correo.Contains("@") || !Correo.Contains("."))
                erroresGenerales.Add("El correo no es válido.");
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["correo"] = new List<string>(erroresGenerales);

            //contraseña
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(Contrasenha))
            {
                erroresGenerales.Add("La contraseña es obligatoria.");
            }
            if (Contrasenha.Length < 6)
                erroresGenerales.Add("La contraseña debe tener al menos 6 caracteres.");
            if (!Regex.IsMatch(Contrasenha, @"[A-Z]"))
                erroresGenerales.Add("Debe contener al menos una mayúscula.");
            if (!Regex.IsMatch(Contrasenha, @"[a-z]"))
                erroresGenerales.Add("Debe contener al menos una minúscula.");
            if (!Regex.IsMatch(Contrasenha, @"[0-9]"))
                erroresGenerales.Add("Debe contener al menos un número.");
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["contrasenha"] = new List<string>(erroresGenerales);

            //teléfono 
            erroresGenerales.Clear();
            string sinEspaciosTelefono = Telefono.Replace(" ", "");
            if (string.IsNullOrEmpty(sinEspaciosTelefono) || !Regex.IsMatch(sinEspaciosTelefono, @"^\d{10}$"))
            {
                errores["telefono"] = new List<string>{"Teléfono debe tener 10 dígitos."};
            }

            //direccion
            erroresGenerales.Clear();
            if (string.IsNullOrEmpty(Direccion))
            {
                erroresGenerales.Add("La dirección es obligatoria.");
            }
            if (Direccion.Length >50)
            {
                erroresGenerales.Add("La dirección debe de contener menos de 50 caracteres.");
            }
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["direccion"] = new List<string>(erroresGenerales);

            //fecha de nacimiento
            erroresGenerales.Clear();
            if (FechaNaci == default || FechaNaci > DateTime.Now)
            {
                erroresGenerales.Add("Fecha de nacimiento inválida.");
            }
            else
            {
                //se calcula la edad
                var edad = DateTime.Now.Year - FechaNaci.Year;
                //se hace el ajuste exacto por mes
                if (FechaNaci > DateTime.Now.AddYears(-edad)) edad--;
                if (edad <= 0) erroresGenerales.Add("La edad debe ser mayor a 0.");
            }
            //se colocan en la lista para regresar
            if (erroresGenerales.Count > 0) errores["fechaNaci"] = new List<string>(erroresGenerales);

            //sexo
            if (string.IsNullOrEmpty(Sexo) || Sexo == null)
                errores["sexo"] = new List<string> { "El sexo es obligatorio." };

            // si hay errores (false) donde se invocó este método van a obtener un diccionario con los errores
            return errores.Count == 0;
        }

        public string datosBD()
        {
            // Construir configuración para leer appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            // Obtener cadena de conexión desde el archivo
            return configuration.GetConnectionString("MiConexionSQL");
        }



        //eeeeeeeeeeeeeeeeeeeee-----------------------------------------------
        //método exclusivo para seleccionar datos de la BD
        //eeeeeeeeeeeee no tengo certeza con la clase que se devuelve èsta es el padre

        public List<DatosClienteMetodos> Seleccionar(string datosBD, string instruccion, SqlParameter[] parametros)
        {
            var resultados = new List<DatosClienteMetodos>();
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
                                    //hay que cambiar todos los datos
                                    int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                    string nombre = reader.IsDBNull(1) ? "vacío" : reader.GetString(1);
                                    string correo = reader.IsDBNull(2) ? "vacío" : reader.GetString(2);
                                    string contrasenha = reader.IsDBNull(3) ? "vacío" : reader.GetString(3);
                                    string telefono= reader.IsDBNull(4) ? "vacío" : reader.GetString(4);
                                    string direccion = reader.IsDBNull(5) ? "vacío" : reader.GetString(5);
                                    DateTime fechaNacimiento = reader.IsDBNull(6) ? default : reader.GetDateTime(6);
                                    string sexo = reader.IsDBNull(7) ? "vacío" : reader.GetString(7);
                                    bool activo = reader.IsDBNull(8) ? false : reader.GetBoolean(8);

                                }
                            }
                            else
                            {
                                resultados.Add(new DatosClienteMetodos(errores: "No se encontraron datos."));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new DatosClienteMetodos(errores: $"Error: {ex.Message}"));
            }

            return resultados;
        }

        //Método común para Create, Update y Delete
        public string Modificar_guardar(string accion, string datosBD, string instruccion, SqlParameter[] parametros)
        {
            string descripcion = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(datosBD))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(instruccion, conexion))
                    {
                        comando.Parameters.AddRange(parametros);

                        int resultadoConsulta = comando.ExecuteNonQuery();

                        return resultadoConsulta > 0 ? $"Éxito al {accion}" : $"No realizó ninguna acción al intentar {accion}";
                    }
                }
            }
            catch (Exception ex)
            {
                descripcion = $"Error: {ex.Message}";
            }
            return descripcion;
        }
    }
}