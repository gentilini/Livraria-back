using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class FormaCompraRepository : IFormaCompraRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public FormaCompraRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<FormaCompra>> GetAllAsync()
        {
            using var connection = Connection;

            return await connection.QueryAsync<FormaCompra>("SELECT * FROM formacompra");
        }

        public async Task<FormaCompra?> GetByIdAsync(int id)
        {
            using var connection = Connection;

            return await connection.QueryFirstOrDefaultAsync<FormaCompra>("SELECT * FROM formacompra WHERE CodFo = @Id", new { Id = id });
        }
    }
}
