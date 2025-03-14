using Dapper;
using Livraria.Interfaces.Repositories;
using Livraria.Models;
using Livraria.ViewModels;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace Livraria.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public LivroRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CreateAsync(Livro livro)
        {
            using var connection = Connection;

            var sql = @"INSERT INTO livro (titulo, editora, edicao, anoPublicacao) 
            VALUES (@titulo, @editora, @edicao, @anoPublicacao) 
            RETURNING Codl;";

            return await connection.QuerySingleAsync<int>(sql, livro);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = Connection;

            var sql = @"DELETE FROM livro WHERE Codl = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<LivroResponseViewModel>> GetAllAsync()
        {
            using var connection = Connection;

            var sql = @"
                 SELECT 
                    l.CodL, 
                    l.Titulo, 
                    l.Editora, 
                    l.Edicao, 
                    l.AnoPublicacao,

                    -- JSON dos assuntos
                    COALESCE(json_agg(DISTINCT jsonb_build_object('CodAs', a.CodAs, 'Descricao', a.Descricao)) FILTER (WHERE a.CodAs IS NOT NULL), '[]') AS AssuntosJson,

                    -- JSON dos autores
                    COALESCE(json_agg(DISTINCT jsonb_build_object('CodAu', au.CodAu, 'Nome', au.Nome)) FILTER (WHERE au.CodAu IS NOT NULL), '[]') AS AutoresJson,

                    -- JSON das formas de compra
                    COALESCE(json_agg(DISTINCT jsonb_build_object('CodFo', fc.CodFo, 'Descricao', fc.Descricao, 'Preco', lf.Preco)) FILTER (WHERE fc.CodFo IS NOT NULL), '[]') AS FormasCompraJson

                FROM Livro l
                LEFT JOIN LivroAssunto la ON l.CodL = la.LivroCodL
                LEFT JOIN Assunto a ON la.AssuntoCodAs = a.CodAs
                LEFT JOIN LivroAutor lau ON l.CodL = lau.LivroCodL
                LEFT JOIN Autor au ON lau.AutorCodAu = au.CodAu
                LEFT JOIN LivroFormaCompra lf ON l.CodL = lf.LivroCodL
                LEFT JOIN FormaCompra fc ON lf.FormaCompraCodFo = fc.CodFo

                GROUP BY l.CodL, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao
                ORDER BY l.CodL;

                ";

            var livrosRowModel = await connection.QueryAsync<LivroRawModel>(sql);

            // 🔹 Converte os JSONs para as listas de objetos
            var livros = livrosRowModel.Select(l => new LivroResponseViewModel
            {
                Codl = l.Codl,
                Titulo = l.Titulo,
                Editora = l.Editora,
                Edicao = l.Edicao,
                AnoPublicacao = l.AnoPublicacao,

                Assuntos = JsonConvert.DeserializeObject<IEnumerable<Assunto>>(l.AssuntosJson),
                Autores = JsonConvert.DeserializeObject<IEnumerable<Autor>>(l.AutoresJson),
                FormasCompra = JsonConvert.DeserializeObject<IEnumerable<FormaCompra>>(l.FormasCompraJson)
            });

            return livros;

        }

        public async Task<LivroResponseViewModel?> GetByIdAsync(int id)
        {
            //implementar a tabela e query para popular esse objeto
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Livro livro)
        {
            using var connection = Connection;

            var sql = @"UPDATE livro SET titulo = @titulo, editora = @editora, edicao = @edicao, anopublicacao = @anopublicacao WHERE Codl =  @Codl";

            return await connection.ExecuteAsync(sql, livro);
        }
    }
}
