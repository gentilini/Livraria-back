using Livraria.Models;

namespace Livraria.ViewModels
{
    public class LivroResponseViewModel
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public IEnumerable<Assunto> Assuntos { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
        public IEnumerable<FormaCompra> FormasCompra { get; set; }
    }
}
