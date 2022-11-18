using Dapper;
using GestordeContactos.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosRepositorios
{
    public class ContactoRepositorio : IContactoRepositorio
    {
        private readonly IDbConnection _dbConnection;

        public ContactoRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> ActualizarContacto(Contacto contacto)
        {
            try
            {
                var sql = @" UPDATE Contactos
                                SET Nombre = @Nombre,
                                    Apellido = @Apellido,
                                    Celular = @Celular, 
                                    Dirección = @Dirección
                              WHERE Id = @Id ";

                var result = await _dbConnection.ExecuteAsync(
                             sql, new
                             {
                                 contacto.Nombre,
                                 contacto.Apellido,
                                 contacto.Celular,
                                 contacto.Dirección,
                                 contacto.Id
                             });

                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task EliminarContacto(int id)
        {
            var sql = @"DELETE FROM WHERE Id = @Id";

            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contacto>> GetAll()
        {
            var sql = @" SELECT * FROM ContactosDB";

            return await _dbConnection.QueryAsync<Contacto>(sql, new { });
        }

        public async Task<Contacto> GetDetalles(int id)
        {
            var sql = @" SELECT * FROM ContactosDB WHERE Id = @Id";

            return await _dbConnection.QueryFirstAsync<Contacto>(
                sql, new { Id = id });
        }

        public async Task<bool> InsertarContacto(Contacto contacto)
        {
            try
            {
                var sql = @" INSERT INTO Contactos(Nombre, Apellido, Celular, Dirección)
                             VALUES (@Nombre, @Apellido, @Celular, @Dirección)";

                var result = await _dbConnection.ExecuteAsync(
                             sql, new
                             {
                                 contacto.Nombre,
                                 contacto.Apellido,
                                 contacto.Celular,
                                 contacto.Dirección
                             });

                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
