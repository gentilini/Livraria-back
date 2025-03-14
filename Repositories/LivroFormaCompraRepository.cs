using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class LivroFormaCompraRepository : ILivroFormaCompraRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public LivroFormaCompraRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(LivroFormaCompra livroFormaCompra)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO livroformacompra (LivroCodL, FormaCompraCodFo, Preco) 
            VALUES (@LivroCodL, @FormaCompraCodFo, @Preco)
            RETURNING LivroCodL;";

            return await connection.QuerySingleAsync<int>(sql, livroFormaCompra);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM livroformacompra WHERE LivroCodL = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
