using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_API.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public Medicamento medicamento { get; set; }
        public int medicamentoId { get; set; }
        public int ExistenciaInventario { get; set; }
    }
}