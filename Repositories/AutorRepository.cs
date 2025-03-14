using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public AutorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(Autor autor)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO autor (nome) 
            VALUES (@nome) 
            RETURNING CodAu;";

            return await connection.QuerySingleAsync<int>(sql, autor);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM autor WHERE CodAu = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            using var connection = Connection;

            return await connection.QueryAsync<Autor>("SELECT * FROM autor");
        }

        public async Task<Autor?> GetByIdAsync(int id)
        {
            using var connection = Connection;

            return await connection.QueryFirstOrDefaultAsync<Autor>("SELECT * FROM autor WHERE CodAu = @Id", new { Id = id });
        }

        public async Task<int> UpdateAsync(Autor autor)
        {
            using var connection = Connection;

            var sql = @"UPDATE autor SET nome = @nome WHERE CodAu =  @CodAu";

            return await connection.ExecuteAsync(sql, autor);
        }
    }
}
