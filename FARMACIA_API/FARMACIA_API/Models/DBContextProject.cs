using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FARMACIA_API.Models
{
    public class DBContextProject:DbContext
    {
        public DBContextProject() : base("MyDbConnectionString")
        {

        }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Client> Cliente { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
       
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Venta> venta { get; set; }

    }
}