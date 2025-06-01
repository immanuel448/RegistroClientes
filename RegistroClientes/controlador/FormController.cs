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
            string stringResultadoBD = "";

            switch (datosDelFormulario.Accion)
            {
                case "Buscar":
                    instruccion = "SELECT * FROM Clientes WHERE id = @id AND activo = 1";
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
                    //parametros.Add(new SqlParameter("@activo", datosDelFormulario.Activo));

                    stringResultadoBD = datosDelFormulario.Modificar_guardar(
                        "Insertar",
                        datosDelFormulario.datosBD(),
                        instruccion,
                        parametros.ToArray()
                    );

                    _vista.Mensaje(stringResultadoBD);
                    break;

                case "Actualizar":

                    instruccion = "UPDATE Clientes SET nombre = @nombre, correo = @correo, contrasenha = @contrasenha, telefono = @telefono, direccion = @direccion, fechaNaci = @fechaNaci, sexo =@sexo, activo = @activo WHERE id = @id";

                    parametros.Add(new SqlParameter("@nombre", datosDelFormulario.Nombre));
                    parametros.Add(new SqlParameter("@correo", datosDelFormulario.Correo));
                    parametros.Add(new SqlParameter("@contrasenha", datosDelFormulario.Contrasenha));
                    parametros.Add(new SqlParameter("@telefono", datosDelFormulario.Telefono));
                    parametros.Add(new SqlParameter("@direccion", datosDelFormulario.Direccion));
                    parametros.Add(new SqlParameter("@fechaNaci", datosDelFormulario.FechaNaci));
                    parametros.Add(new SqlParameter("@sexo", datosDelFormulario.Sexo));
                    parametros.Add(new SqlParameter("@activo", datosDelFormulario.Activo));
                    parametros.Add(new SqlParameter("@id", datosDelFormulario.Id));

                    stringResultadoBD = datosDelFormulario.Modificar_guardar(
                        "Actualizar",
                        datosDelFormulario.datosBD(),
                        instruccion,
                        parametros.ToArray());
                    _vista.Mensaje(stringResultadoBD);
                    break;

                case "Borrar":

                    instruccion = "UPDATE Clientes SET activo = 0 WHERE id = @id";

                    parametros.Add(new SqlParameter("@id", datosDelFormulario.Id));

                    stringResultadoBD = datosDelFormulario.Modificar_guardar(
                        "Borrar",
                        datosDelFormulario.datosBD(),
                        instruccion,
                        parametros.ToArray());
                    _vista.Mensaje(stringResultadoBD);
                    _vista.LimpiarFormulario(_vista);
                    break;
            }
        }
    }
}
