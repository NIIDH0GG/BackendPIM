namespace BackendPIM.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }   // Data e hora em que o serviço de manutenção será realizado


        // Status: "Pendente", "Confirmado", "Em Execução", "Concluído", "Cancelado"
        public string Status { get; set; } = "Pendente";


        // --- RELACIONAMENTOS (Chaves Estrangeiras) ---

        // Quem pediu o serviço?
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Quem vai realizar o serviço?
        public int ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }

        // Qual serviço será feito?
        public int ServicoId { get; set; }
        public Servico? Servico { get; set; }
    }
}
