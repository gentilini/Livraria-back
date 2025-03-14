using Livraria.Models;

namespace Livraria.ViewModels
{
    public class LivroRequestViewModel
    {
        public Livro Livro { get; set; }
    }

    public class Livro
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public IEnumerable<int> Assuntos { get; set; }
        public IEnumerable<int> Autores { get; set; }
        public IEnumerable<Preco> Precos { get; set; }
    }
}
