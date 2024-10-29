using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_API.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int ventaId { get; set; }
        public Venta venta { get; set; }
        public int medicamentoId { get; set; }
        public Medicamento medicamento { get; set; }
        public int Cantidad { get; set; }
        public double TotalPagar { get; set; }
    }
}