using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtremeMvcFARMACIA.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
    }
}