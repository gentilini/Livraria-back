using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class LivroAssuntoRepository : ILivroAssuntoRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public LivroAssuntoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(LivroAssunto livroAssunto)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO livroassunto (LivroCodL, AssuntoCodAs) 
            VALUES (@LivroCodL, @AssuntoCodAs)
            RETURNING LivroCodL;";

            return await connection.QuerySingleAsync<int>(sql, livroAssunto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM livroassunto WHERE LivroCodL = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
