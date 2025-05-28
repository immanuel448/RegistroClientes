// Modelo
using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;


namespace RegistroClientes.Modelo
{
    internal class DatosClienteRepo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasenha { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNaci { get; set; }
        public string sexo { get; set; }
        public bool activo { get; set; }
        public string accion { get; set; }

        public bool EsValido(out Dictionary<string, List <string>> errores)
        {
            //validaciones --------------------------------------
            errores = new Dictionary<string, List<string>>();
            List<string> erroresGenerales = new List<string>();

            //id


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


        //esto iba en elmain eeeeeeeeeeeeeeeeeeeeeeeeee
        private static void Seleccionar(string CadenaConexion)
        {
            var idsParaBuscar = new List<int>() { 1, 2, 3, 4 };
            //se usa un método del objeto creado, devuelve un objeto que contiene los resultados
            var resultados = controller.SeleccionarDatos(CadenaConexion, idsParaBuscar);
            int contar = 1;
            //con esto se presentan los resultados
            foreach (var item in resultados)
            {
                if (item.Errores == null)
                {
                    Console.WriteLine($"\n-------------------- \n El dato número {contar++} es:\n ID: {item.Identificador} \n Nombre: {item.Nombre},\n Edad: {item.Edad},\n Activo: {item.Activo}");
                }
                else
                {
                    Console.WriteLine("!!! " + item.Errores);
                }
            }
        }

        //esto iba en elmain eeeeeeeeeeeeeeeeeeeeeeeeee

        private static void Insertar(string CadenaConexion, string nombreDato)
        {
            //devuelve un string
            var resultados = controller.InsertarDatos(CadenaConexion, nombreDato, 15, false);
            Console.WriteLine(resultados);
        }
        //esto iba en elmain eeeeeeeeeeeeeeeeeeeeeeeeee

        private static void Actualizar(string CadenaConexion)
        {
            //devuelve un string
            var resultados = controller.ActualizarDatos(CadenaConexion, "jeje", 50, 15);
            Console.WriteLine(resultados);
        }
        //esto iba en elmain eeeeeeeeeeeeeeeeeeeeeeeeee

        private static void Borrar(string CadenaConexion)
        {
            //devuelve un string
            var resultados = controller.BorrarDatos(CadenaConexion, 5);
            Console.WriteLine(resultados);
        }






        //método exclusivo para seleccionar datos de la BD
        public List<DatosMiTabla> Seleccionar(string datosBD, string instruccion, SqlParameter[] parametros)
        {
            var resultados = new List<DatosMiTabla>();
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
                                    int identificador = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                    string nombre = reader.IsDBNull(1) ? "vacío" : reader.GetString(1);
                                    int edad = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                    bool activo = reader.IsDBNull(3) ? false : reader.GetBoolean(3);
                                    resultados.Add(new DatosMiTabla(identificador, nombre, edad, activo));
                                }
                            }
                            else
                            {
                                resultados.Add(new DatosMiTabla(errores: "No se encontraron datos."));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new DatosMiTabla(errores: $"Error: {ex.Message}"));
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