namespace BackendPIM.Models
{
    public class ConteudoDiversidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        // Ex: "Artigo", "Vídeo", "Treinamento Corporativo"
        public string Tipo { get; set; } = string.Empty;

        // Conteúdo em texto ou link externo para o treinamento
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}
