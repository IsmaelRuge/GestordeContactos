using GestordeContactos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestordeContactos.Client.Services
{
    public interface IContactoService
    {
        Task GuardarContacto(Contacto contacto);
        Task EliminarContacto(int id);
        Task<IEnumerable<Contacto>> GetAll();
        Task<Contacto> GetDetalles(int id);
    }
}
