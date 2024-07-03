using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Proveedor
{
    public class ProveedorModel
    {
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; } 
    }
}
