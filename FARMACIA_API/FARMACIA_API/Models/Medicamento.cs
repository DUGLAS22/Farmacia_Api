using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_API.Models
{
    public class Medicamento
    {
        public  int Id { get; set; }
        public string Presentacion { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        
        public int Existencia { get; set; }
        public int proveedorId { get; set; }
        public Proveedor proveedor { get; set; }
        
    }
}