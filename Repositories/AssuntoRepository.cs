using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public AssuntoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(Assunto assunto)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO assunto (descricao) 
            VALUES (@descricao) 
            RETURNING CodAs;";

            return await connection.QuerySingleAsync<int>(sql, assunto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM assunto WHERE CodAs = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Assunto>> GetAllAsync()
        {
            using var connection = Connection;

            return await connection.QueryAsync<Assunto>("SELECT * FROM assunto");
        }

        public async Task<Assunto?> GetByIdAsync(int id)
        {
            using var connection = Connection;

            return await connection.QueryFirstOrDefaultAsync<Assunto>("SELECT * FROM assunto WHERE CodAs = @Id", new { Id = id });
        }

        public async Task<int> UpdateAsync(Assunto assunto)
        {
            using var connection = Connection;

            var sql = @"UPDATE assunto SET descricao = @descricao WHERE CodAs =  @CodAs";

            return await connection.ExecuteAsync(sql, assunto);
        }
    }
}
