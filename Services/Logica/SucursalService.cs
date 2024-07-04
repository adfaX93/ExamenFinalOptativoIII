using Repository.Data.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class SucursalService : ISucursalRepository
    {
        private SucursalRepository sucursalRepository;
        public SucursalService(string connectionString)
        {
            sucursalRepository = new SucursalRepository(connectionString);
        }
        public bool add(SucursalModel sucursalModel)
        {
            return validarDatos(sucursalModel) ? sucursalRepository.add(sucursalModel): throw new Exception("Error en la validacion de datos");
        }

        public bool delete(int id)
        {
            return id > 0 ? sucursalRepository.delete(id) : false;
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return sucursalRepository.GetAll();
        }

        public bool update(SucursalModel sucursalModel)
        {
            return validarDatos(sucursalModel) ? sucursalRepository.update(sucursalModel) : throw new Exception("Error en la validacion de datos");
        }
        private bool validarDatos(SucursalModel sucursal)
        {
            if (sucursal == null)
                return false;
            if (string.IsNullOrEmpty(sucursal.Direccion) && sucursal.Direccion.Length < 10)
                return false;
            if (!esMailValido(sucursal.Mail))
                return false;

            return true;
        }
        private bool esMailValido(string email)
        {
            // Expresión regular para validar el email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
