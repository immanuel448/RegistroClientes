using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string sexo{ get; set; }
        public bool activo{ get; set; }
        public string comentarios { get; set; }

    }
}
