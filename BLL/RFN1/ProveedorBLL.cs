using BE;
using BE.RFN1;
using DAL;
using DAL.RFN1;
using System;
using System.Collections.Generic;

namespace BLL.RFN1
{
    public class ProveedorBLL
    {
        private readonly ProveedorDAL _proveedorDAL;

        public ProveedorBLL()
        {
            _proveedorDAL = new ProveedorDAL();
        }

        public List<Proveedor> Listar()
        {
            return _proveedorDAL.Listar();
        }

        public int Guardar(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new ArgumentNullException(nameof(proveedor), "El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial))
                throw new Exception("La Razón Social del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(proveedor.Cuit))
                throw new Exception("El CUIT del proveedor es obligatorio.");

            return _proveedorDAL.Guardar(proveedor);
        }
    }
}