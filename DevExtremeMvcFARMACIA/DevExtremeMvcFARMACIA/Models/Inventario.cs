using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtremeMvcFARMACIA.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public Medicamento Medicamento { get; set; }
        public int MedicamentoId { get; set; }
        public int ExistenciaInventario { get; set; }
    }
}