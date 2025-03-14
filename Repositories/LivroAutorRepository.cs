using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class LivroAutorRepository : ILivroAutorRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public LivroAutorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(LivroAutor livroAutor)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO livroautor (LivroCodL, AutorCodAu) 
            VALUES (@LivroCodL, @AutorCodAu)
            RETURNING LivroCodL;";

            return await connection.QuerySingleAsync<int>(sql, livroAutor);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM livroautor WHERE LivroCodL = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
