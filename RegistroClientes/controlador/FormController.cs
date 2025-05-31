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

        public void RellenarVista(DatosClienteMetodos datosRecibidos)
        {
            if (datosRecibidos.Errores == null)
            {
                _vista.txtID.Text = datosRecibidos.Id.ToString();
                _vista.txtNombreCli.Text = datosRecibidos.Nombre.ToString();
                _vista.txtCorreoCli.Text = datosRecibidos.Correo.ToString();
                _vista.txtContraseCli.Text = datosRecibidos.Contrasenha.ToString();
                _vista.txtTelefonoCli.Text = datosRecibidos.Telefono.ToString();
                _vista.txtDireccionCli.Text = datosRecibidos.Direccion.ToString();
                _vista.txtFechaNaciCli.Text = datosRecibidos.FechaNaci.ToString();
                if (datosRecibidos.Sexo == "Hombre")
                {
                    _vista.radioSexoH.Checked = true;
                }
                else if (datosRecibidos.Sexo == "Mujer")
                {
                    _vista.radioSexoM.Checked = true;
                }
                else if (datosRecibidos.Sexo == "Sin Espe")
                {
                    _vista.radioSexoSin.Checked = true;
                }
                _vista.Mensaje($"El dato {datosRecibidos.Id} ha sido encontrado con éxito");
            }
            else
            {
                _vista.Mensaje(datosRecibidos.Errores);
            }
        }

        public void ValidarYProcesarDatos(DatosClienteMetodos datosDelFormulario)
        {
            // 1. Validación
            if (!datosDelFormulario.EsValido(out var erroresAlValidar, datosDelFormulario.Accion))
            {
                var erroresDict = new Dictionary<Control, string>();

                foreach (var error in erroresAlValidar)
                {
                    string mensajeUnido = string.Join("\n", error.Value);
                    switch (error.Key)
                    {
                        case "id":
                            erroresDict[_vista.txtID] = mensajeUnido;
                            _vista.Mensaje("1");
                            break;
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
                //en este if hay errores
                _vista.MostrarErrores(erroresDict);
                return; // detener ejecución si hay errores
            }

            // 2. Procesamiento según acción
            List<SqlParameter> parametros = new List<SqlParameter>();
            string instruccion = "";

            switch (datosDelFormulario.Accion)
            {
                case "Buscar":
                    instruccion = "SELECT * FROM Clientes WHERE id = @id";
                    parametros.Add(new SqlParameter("@id", datosDelFormulario.Id));

                    var resultadoBD = datosDelFormulario.Seleccionar(
                        datosDelFormulario.datosBD(),
                        instruccion,
                        parametros.ToArray()
                    );

                    RellenarVista(resultadoBD);
                    break;

                case "Insertar":
                    instruccion = "INSERT INTO Clientes (nombre, correo, contrasenha, telefono, direccion, fechaNaci, sexo, activo) " +
                                  "VALUES (@nombre, @correo, @contrasenha, @telefono, @direccion, @fechaNaci, @sexo, @activo)";

                    parametros.Add(new SqlParameter("@nombre", datosDelFormulario.Nombre));
                    parametros.Add(new SqlParameter("@correo", datosDelFormulario.Correo));
                    parametros.Add(new SqlParameter("@contrasenha", datosDelFormulario.Contrasenha));
                    parametros.Add(new SqlParameter("@telefono", datosDelFormulario.Telefono));
                    parametros.Add(new SqlParameter("@direccion", datosDelFormulario.Direccion));
                    parametros.Add(new SqlParameter("@fechaNaci", datosDelFormulario.FechaNaci));
                    parametros.Add(new SqlParameter("@sexo", datosDelFormulario.Sexo));
                    parametros.Add(new SqlParameter("@activo", datosDelFormulario.Activo));

                    string stringResultadoBD = datosDelFormulario.Modificar_guardar(
                        "Insertar",
                        datosDelFormulario.datosBD(),
                        instruccion,
                        parametros.ToArray()
                    );

                    _vista.Mensaje(stringResultadoBD);
                    break;
            }
        }




        //eeeeeeeeeeeeeeeee añadido
        // Método auxiliar devuelve un array de objetos SqlParameter
        private SqlParameter[] CrearParametros(string[] nombresParametros, object[] valores)
        {
            if (nombresParametros.Length != valores.Length)
                throw new ArgumentException("El número de nombres de parámetros no coincide con el número de valores.");

            //en este array se van a colocar objets de SqlParameter
            var parametros = new SqlParameter[nombresParametros.Length];
            for (int i = 0; i < nombresParametros.Length; i++)
            {
                //la estructura es "new SqlParameter(@nombre", "El nombre");"
                parametros[i] = new SqlParameter(nombresParametros[i], valores[i]);
            }
            return parametros;
        }

        // Método que ejecuta Insertar, Actualizar o Borrar dependiendo de la operación
        private string EjecutarOperacion(string nombreOperacion, string cadenaConexion, string instruccion, string[] nombresParametros, object[] valores)
        {
            try
            {
                var parametros = CrearParametros(nombresParametros, valores);
                return _repositorio.Modificar_guardar(nombreOperacion, cadenaConexion, instruccion, parametros);
            }
            catch (Exception ex)
            {
                return $"Error en la operación {nombreOperacion}: {ex.Message}";
            }
        }


        // Seleccionar Datos, aquí no se usa el método "EjecutarOperacion"
        /*
        public List<DatosClienteMetodos> SeleccionarDatos(string cadenaConexion, List<int> identificadores)
        {
            try
            {
                //si no hay parametros, se termina
                if (identificadores == null || identificadores.Count == 0)
                {
                    return new List<DatosClienteMetodos>();
                }

                // LINQ, Crea nombre de los parámetros estructura "@id..."
                var nombresParametros = identificadores.Select(i => "@id" + i).ToList();
                //aquí se hace uso de LINQ,se ocupa pasar un array de objets
                var valores = identificadores.Cast<object>().ToArray();

                // Crear instrucción SQL, "string.Join" une todos los elementos de la lista
                string instruccion = $"SELECT * FROM miTabla WHERE id IN ({string.Join(", ", nombresParametros)})";

                return _repositorio.Seleccionar(cadenaConexion, instruccion, CrearParametros(nombresParametros.ToArray(), valores));

            }
            catch (Exception ex)
            {
                var resultados = new List<DatosClienteMetodos>();
                resultados.Add(new DatosClienteMetodos(errores: $"Error al seleccionar {ex.Message}"));
                return resultados;
            }
        }*/

        // Insertar Datos
        public string InsertarDatos(string cadenaConexion, string nombre, int edad, bool activo)
        {
            string instruccion = "INSERT INTO miTabla (nombre, edad, activo) VALUES (@nombre, @edad, @activo)";

            string[] nombresParametros = { "@nombre", "@edad", "@activo" };
            object[] valores = { nombre, edad, activo };

            return EjecutarOperacion("Insertar", cadenaConexion, instruccion, nombresParametros, valores);
        }

        // Actualizar Datos
        public string ActualizarDatos(string cadenaConexion, string nombre, int edad, int id)
        {
            string instruccion = "UPDATE miTabla SET nombre = @nombre, edad = @edad WHERE id = @id";

            string[] nombresParametros = { "@nombre", "@edad", "@id" };
            object[] valores = { nombre, edad, id };

            return EjecutarOperacion("Actualizar", cadenaConexion, instruccion, nombresParametros, valores);
        }

        // Borrar Datos
        public string BorrarDatos(string cadenaConexion, int id)
        {
            string instruccion = "DELETE FROM miTabla WHERE id = @id";

            string[] nombresParametros = { "@id" };
            object[] valores = { id };

            return EjecutarOperacion("Borrar", cadenaConexion, instruccion, nombresParametros, valores);
        }
    }
}
