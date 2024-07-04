using Repository.Data.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ProveedorService : IProveedorRepository
    {
        private ProveedorRepository proveedorRepository;
        public ProveedorService(string connectionString)
        {
            proveedorRepository = new ProveedorRepository(connectionString);
        }
        public bool add(ProveedorModel proveedorModel)
        {
            return validarDatos(proveedorModel) ? proveedorRepository.add(proveedorModel) : throw new Exception("Error en la validacion de datos");
        }

        public bool delete(int id)
        {
            return id > 0 ? proveedorRepository.delete(id) : false;
        }

        public IEnumerable<ProveedorModel> GetAll()
        {
            return proveedorRepository.GetAll();
        }

        public bool update(ProveedorModel proveedorModel)
        {
            return validarDatos(proveedorModel) ? proveedorRepository.update(proveedorModel) : throw new Exception("Error en la valiacion de datos");
        }
        private bool validarDatos(ProveedorModel proveedor)
        {
            if(proveedor == null)
                return false;
            if(string.IsNullOrEmpty(proveedor.RazonSocial) && proveedor.RazonSocial.Length < 3)
                return false;
            if(string.IsNullOrEmpty(proveedor.TipoDocumento) && proveedor.TipoDocumento.Length <3)
                return false;
            if(string.IsNullOrEmpty(proveedor.NumeroDocumento) && proveedor.NumeroDocumento.Length < 3)
                return false;
            if(!esNumero(proveedor.Celular) && proveedor.Celular.Length <10)
                return false;

            return true;
        }
        private bool esNumero(string nro)
        {
            return nro.All(char.IsDigit);
        }
    }
}
