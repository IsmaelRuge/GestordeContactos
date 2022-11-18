using GestordeContactos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosRepositorios
{
    public interface IContactoRepositorio
    {
        Task<bool> InsertarContacto(Contacto contacto);
        Task<bool> ActualizarContacto(Contacto contacto);
        Task EliminarContacto(int id);
        Task<IEnumerable<Contacto>> GetAll();
        Task<Contacto> GetDetalles(int id);
    }
}
