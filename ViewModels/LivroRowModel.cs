namespace Livraria.ViewModels
{
    public class LivroRawModel
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        // Campos vindos como JSON
        public string AssuntosJson { get; set; }
        public string AutoresJson { get; set; }
        public string FormasCompraJson { get; set; }
    }
}
