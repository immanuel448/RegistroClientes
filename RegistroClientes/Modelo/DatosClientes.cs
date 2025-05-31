using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroClientes.Modelo
{
    public class DatosClientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenha { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNaci { get; set; }
        public string Sexo { get; set; }
        public bool Activo { get; set; }
        public string Accion { get; set; }
        public string Errores { get; set; }

        public DatosClientes(int id = 0, string nombre = "", string correo = "", string contrasenha = "", string telefono = "", string direccion = "", DateTime fechaNaci = default, string sexo = "", bool activo = false, string accion = null, string errores = null)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Contrasenha= contrasenha;
            Telefono= telefono;
            Direccion= direccion;
            FechaNaci = fechaNaci;
            Sexo = sexo;
            Activo = activo;
            Accion = accion;
            Errores = errores;
        }
    }
}
