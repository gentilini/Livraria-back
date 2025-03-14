using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class LivrosPorAutorViewRepository : ILivrosPorAutorViewRepository
    {
        private readonly string _connectionString;

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public LivrosPorAutorViewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<LivrosPorAutorView>> GetAllAsync()
        {
            using var connection = Connection;

            return await connection.QueryAsync<LivrosPorAutorView>(
                @"
                SELECT
                    livro.titulo,
                    livro.edicao,
                    livro.editora,
                    livro.anopublicacao,
                    STRING_AGG(autor.nome, ' | ') AS nomeautor
                FROM
                    livro
                    INNER JOIN livroautor ON livroautor.livrocodl = livro.codl
                    INNER JOIN autor ON autor.codau = livroautor.autorcodau
                GROUP BY
                    livro.titulo,
                    livro.edicao,
                    livro.editora,
                    livro.anopublicacao;
                ");
        }
    }
}
