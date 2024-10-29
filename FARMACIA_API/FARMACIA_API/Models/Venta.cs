using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_API.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int clienteId { get; set; }
        public Client cliente { get; set; }
        public int empleadoId { get; set; }
        public Empleado empleado { get; set; }
    }
}