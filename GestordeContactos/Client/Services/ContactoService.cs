using GestordeContactos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GestordeContactos.Client.Services
{
    public class ContactoService : IContactoService
    {
        private readonly HttpClient _httpClient;

        public ContactoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task EliminarContacto(int id)
        {
            await _httpClient.DeleteAsync($"api/Contactos/{id}");
        }

        public async Task<IEnumerable<Contacto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contacto>>($"api/Contactos");
        }

        public async Task<Contacto> GetDetalles(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contacto>($"api/Contactos/{id}");
        }

        public async Task GuardarContacto(Contacto contacto)
        {
            if (contacto.Id == 0)
                await _httpClient.PostAsJsonAsync<Contacto>($"api/Contactos", contacto);
            else
                await _httpClient.PutAsJsonAsync<Contacto>($"api/Contactos/{contacto.Id}", contacto);
        }
    }
}
