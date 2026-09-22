using BackendPIM.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPIM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Tabelas do Banco de Dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<ConteudoDiversidade> ConteudosDiversidade { get; set; }
        public DbSet<ParticipacaoTreinamento> ParticipacoesTreinamentos { get; set; }
        public DbSet<RelatoDiscriminacao> RelatosDiscriminacao { get; set; }

        // Dados Iniciais de Teste (Data Seeding) com datas fixas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Garante que o banco de dados não aceite dois usuários com o mesmo e-mail
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();


            // data fixa para o EF Core não reclamar de valores dinâmicos
            var dataFixa = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Administrador Padrão
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "admin@conectalar.com",
                    SenhaHash = "admin123",
                    Perfil = PerfilUsuario.Administrador,
                    DataCriacao = dataFixa // <--- Data fixa aqui
                }
            );

            // Serviços de Manutenção Residencial
            modelBuilder.Entity<Servico>().HasData(
                new Servico { Id = 1, Titulo = "Instalação de Chuveiro Elétrico", Descricao = "Troca e instalação segura de chuveiros residenciais.", PrecoBase = 120.00m, DataCriacao = dataFixa },
                new Servico { Id = 2, Titulo = "Reparo de Vazamento em Torneira", Descricao = "Conserto de encanamentos e vazamentos hidráulicos.", PrecoBase = 90.00m, DataCriacao = dataFixa }
            );

            // Conteúdo de Responsabilidade Social (Leis 10.639 e 11.645)
            modelBuilder.Entity<ConteudoDiversidade>().HasData(
                new ConteudoDiversidade
                {
                    Id = 1,
                    Titulo = "Cultura Afro-Brasileira no Atendimento",
                    Descricao = "Treinamento corporativo sobre igualdade racial e aplicação da Lei 10.639/2003.",
                    Tipo = "Treinamento Corporativo",
                    Conteudo = "Este módulo ensina práticas de combate à discriminação no ambiente de prestação de serviços.",
                    DataPublicacao = dataFixa // <--- Data fixa aqui
                }
            );
        }

    }
}
