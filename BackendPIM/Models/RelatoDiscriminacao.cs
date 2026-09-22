namespace BackendPIM.Models
{
    public class RelatoDiscriminacao
    {
        public int Id { get; set; }
        public string DescricaoFatos { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; } = DateTime.Now;

        // Status do atendimento: "Recebido", "Em Análise", "Resolvido"
        public string Status { get; set; } = "Recebido";


        // --- RELACIONAMENTO (Opcional para Anonimato) ---

        // Pode ser nulo se o usuário quiser fazer uma denúncia anônima
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
