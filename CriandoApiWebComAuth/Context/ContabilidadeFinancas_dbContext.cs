using System;
using System.Collections.Generic;
using CriandoApiWebComAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace CriandoApiWebComAuth.Context
{
    public partial class ContabilidadeFinancas_dbContext : IdentityDbContext<IdentityUser> {
        public ContabilidadeFinancas_dbContext()
        {
        }

        public ContabilidadeFinancas_dbContext(DbContextOptions<ContabilidadeFinancas_dbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AcaoOrcamentarium> AcaoOrcamentaria { get; set; } = null!;
        public virtual DbSet<CategoriaEconomica> CategoriaEconomicas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CreditoAdicional> CreditoAdicionals { get; set; } = null!;
        public virtual DbSet<CronogramaFinanceiro> CronogramaFinanceiros { get; set; } = null!;
        public virtual DbSet<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; } = null!;
        public virtual DbSet<DestinoRepasse> DestinoRepasses { get; set; } = null!;
        public virtual DbSet<EnteBeneficiario> EnteBeneficiarios { get; set; } = null!;
        public virtual DbSet<Fatura> Faturas { get; set; } = null!;
        public virtual DbSet<FonteRecurso> FonteRecursos { get; set; } = null!;
        public virtual DbSet<NaturezaDespesa> NaturezaDespesas { get; set; } = null!;
        public virtual DbSet<OrigemRepasse> OrigemRepasses { get; set; } = null!;
        public virtual DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public virtual DbSet<Projeto> Projetos { get; set; } = null!;
        public virtual DbSet<RepasseFinanceiro> RepasseFinanceiros { get; set; } = null!;
        public virtual DbSet<Servico> Servicos { get; set; } = null!;
        public virtual DbSet<TipoCredito> TipoCreditos { get; set; } = null!;
        public virtual DbSet<TipoDespesa> TipoDespesas { get; set; } = null!;
        public virtual DbSet<UnidadeGestora> UnidadeGestoras { get; set; } = null!;
        public virtual DbSet<UnidadeOrcamentarium> UnidadeOrcamentaria { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AcaoOrcamentarium>(entity =>
            {
                entity.HasKey(e => e.IdAcaoOrcamentaria)
                    .HasName("PK__AcaoOrca__C79BDF80F2D51353");

                entity.HasIndex(e => e.NomeAcaoOrcamentaria, "UQ__AcaoOrca__8A8FF7CBFF3D052C")
                    .IsUnique();

                entity.Property(e => e.IdAcaoOrcamentaria).HasColumnName("id_acao_orcamentaria");

                entity.Property(e => e.NomeAcaoOrcamentaria)
                    .HasMaxLength(255)
                    .HasColumnName("nome_acao_orcamentaria");
            });

            modelBuilder.Entity<CategoriaEconomica>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaEconomica)
                    .HasName("PK__Categori__37925D0954E38291");

                entity.ToTable("CategoriaEconomica");

                entity.HasIndex(e => e.NomeCategoriaEconomica, "UQ__Categori__301DEA6EBEC0C709")
                    .IsUnique();

                entity.Property(e => e.IdCategoriaEconomica).HasColumnName("id_categoria_economica");

                entity.Property(e => e.NomeCategoriaEconomica)
                    .HasMaxLength(50)
                    .HasColumnName("nome_categoria_economica");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__677F38F52FF214B6");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.EmailCliente, "UQ__Cliente__A1DF279E089B041E")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email_cliente");

                entity.Property(e => e.EnderecoCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("endereco_cliente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_cliente");

                entity.Property(e => e.TelefoneCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefone_cliente");
            });

            modelBuilder.Entity<CreditoAdicional>(entity =>
            {
                entity.HasKey(e => e.IdCreditoAdicional)
                    .HasName("PK__CreditoA__79B2788EB271A8D7");

                entity.ToTable("CreditoAdicional");

                entity.HasIndex(e => e.DataDistribuicao, "idx_credito_adicional_data_distribuicao");

                entity.Property(e => e.IdCreditoAdicional).HasColumnName("id_credito_adicional");

                entity.Property(e => e.DataAprovacao)
                    .HasColumnType("date")
                    .HasColumnName("data_aprovacao");

                entity.Property(e => e.DataDistribuicao)
                    .HasColumnType("date")
                    .HasColumnName("data_distribuicao");

                entity.Property(e => e.DescricaoCreditoAdicional)
                    .HasMaxLength(255)
                    .HasColumnName("descricao_credito_adicional");

                entity.Property(e => e.IdAcaoOrcamentaria).HasColumnName("id_acao_orcamentaria");

                entity.Property(e => e.IdEnteBeneficiario).HasColumnName("id_ente_beneficiario");

                entity.Property(e => e.IdFonteRecursos).HasColumnName("id_fonte_recursos");

                entity.Property(e => e.IdPagamento).HasColumnName("id_pagamento");

                entity.Property(e => e.IdTipoCredito).HasColumnName("id_tipo_credito");

                entity.Property(e => e.ValorCreditoAdicional)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor_credito_adicional");

                entity.HasOne(d => d.IdAcaoOrcamentariaNavigation)
                    .WithMany(p => p.CreditoAdicionals)
                    .HasForeignKey(d => d.IdAcaoOrcamentaria)
                    .HasConstraintName("FK__CreditoAd__id_ac__693CA210");

                entity.HasOne(d => d.IdEnteBeneficiarioNavigation)
                    .WithMany(p => p.CreditoAdicionals)
                    .HasForeignKey(d => d.IdEnteBeneficiario)
                    .HasConstraintName("FK__CreditoAd__id_en__6754599E");

                entity.HasOne(d => d.IdFonteRecursosNavigation)
                    .WithMany(p => p.CreditoAdicionals)
                    .HasForeignKey(d => d.IdFonteRecursos)
                    .HasConstraintName("FK__CreditoAd__id_fo__6A30C649");

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany(p => p.CreditoAdicionals)
                    .HasForeignKey(d => d.IdPagamento)
                    .HasConstraintName("FK__CreditoAd__id_pa__66603565");

                entity.HasOne(d => d.IdTipoCreditoNavigation)
                    .WithMany(p => p.CreditoAdicionals)
                    .HasForeignKey(d => d.IdTipoCredito)
                    .HasConstraintName("FK__CreditoAd__id_ti__68487DD7");
            });

            modelBuilder.Entity<CronogramaFinanceiro>(entity =>
            {
                entity.HasKey(e => e.IdCronogramaFinanceiro)
                    .HasName("PK__Cronogra__52E0E12AF45566B0");

                entity.ToTable("CronogramaFinanceiro");

                entity.HasIndex(e => e.PeriodoCronogramaFinanceiro, "idx_cronograma_financeiro_periodo");

                entity.Property(e => e.IdCronogramaFinanceiro).HasColumnName("id_cronograma_financeiro");

                entity.Property(e => e.DataReferencia)
                    .HasColumnType("date")
                    .HasColumnName("data_referencia");

                entity.Property(e => e.IdCronogramaOrcamentario).HasColumnName("id_cronograma_orcamentario");

                entity.Property(e => e.IdTipoDespesa).HasColumnName("id_tipo_despesa");

                entity.Property(e => e.IdUnidadeGestora).HasColumnName("id_unidade_gestora");

                entity.Property(e => e.LimiteLiquidacoes)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("limite_liquidacoes");

                entity.Property(e => e.PeriodoCronogramaFinanceiro)
                    .HasMaxLength(50)
                    .HasColumnName("periodo_cronograma_financeiro");

                entity.HasOne(d => d.IdCronogramaOrcamentarioNavigation)
                    .WithMany(p => p.CronogramaFinanceiros)
                    .HasForeignKey(d => d.IdCronogramaOrcamentario)
                    .HasConstraintName("FK__Cronogram__id_cr__0C85DE4D");

                entity.HasOne(d => d.IdTipoDespesaNavigation)
                    .WithMany(p => p.CronogramaFinanceiros)
                    .HasForeignKey(d => d.IdTipoDespesa)
                    .HasConstraintName("FK__Cronogram__id_ti__0E6E26BF");

                entity.HasOne(d => d.IdUnidadeGestoraNavigation)
                    .WithMany(p => p.CronogramaFinanceiros)
                    .HasForeignKey(d => d.IdUnidadeGestora)
                    .HasConstraintName("FK__Cronogram__id_un__0D7A0286");
            });

            modelBuilder.Entity<CronogramaOrcamentario>(entity =>
            {
                entity.HasKey(e => e.IdCronogramaOrcamentario)
                    .HasName("PK__Cronogra__50B1B4F111F346CD");

                entity.ToTable("CronogramaOrcamentario");

                entity.HasIndex(e => e.PeriodoCronogramaOrcamentario, "idx_cronograma_orcamentario_periodo");

                entity.Property(e => e.IdCronogramaOrcamentario).HasColumnName("id_cronograma_orcamentario");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("data_atualizacao");

                entity.Property(e => e.IdCategoriaEconomica).HasColumnName("id_categoria_economica");

                entity.Property(e => e.IdNaturezaDespesa).HasColumnName("id_natureza_despesa");

                entity.Property(e => e.IdRepasseFinanceiro).HasColumnName("id_repasse_financeiro");

                entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("id_unidade_orcamentaria");

                entity.Property(e => e.LimiteOrcamento)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("limite_orcamento");

                entity.Property(e => e.PeriodoCronogramaOrcamentario)
                    .HasMaxLength(50)
                    .HasColumnName("periodo_cronograma_orcamentario");

                entity.HasOne(d => d.IdCategoriaEconomicaNavigation)
                    .WithMany(p => p.CronogramaOrcamentarios)
                    .HasForeignKey(d => d.IdCategoriaEconomica)
                    .HasConstraintName("FK__Cronogram__id_ca__02FC7413");

                entity.HasOne(d => d.IdNaturezaDespesaNavigation)
                    .WithMany(p => p.CronogramaOrcamentarios)
                    .HasForeignKey(d => d.IdNaturezaDespesa)
                    .HasConstraintName("FK__Cronogram__id_na__03F0984C");

                entity.HasOne(d => d.IdRepasseFinanceiroNavigation)
                    .WithMany(p => p.CronogramaOrcamentarios)
                    .HasForeignKey(d => d.IdRepasseFinanceiro)
                    .HasConstraintName("FK__Cronogram__id_re__01142BA1");

                entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation)
                    .WithMany(p => p.CronogramaOrcamentarios)
                    .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                    .HasConstraintName("FK__Cronogram__id_un__02084FDA");
            });

            modelBuilder.Entity<DestinoRepasse>(entity =>
            {
                entity.HasKey(e => e.IdDestinoRepasse)
                    .HasName("PK__DestinoR__7DF4EAA2A013F615");

                entity.ToTable("DestinoRepasse");

                entity.HasIndex(e => e.NomeDestinoRepasse, "UQ__DestinoR__572BB5052B0F7621")
                    .IsUnique();

                entity.Property(e => e.IdDestinoRepasse).HasColumnName("id_destino_repasse");

                entity.Property(e => e.NomeDestinoRepasse)
                    .HasMaxLength(100)
                    .HasColumnName("nome_destino_repasse");
            });

            modelBuilder.Entity<EnteBeneficiario>(entity =>
            {
                entity.HasKey(e => e.IdEnteBeneficiario)
                    .HasName("PK__EnteBene__7D1E2D2B2C7BB0CF");

                entity.ToTable("EnteBeneficiario");

                entity.HasIndex(e => e.NomeEnteBeneficiario, "UQ__EnteBene__6127379A9BB8C613")
                    .IsUnique();

                entity.Property(e => e.IdEnteBeneficiario).HasColumnName("id_ente_beneficiario");

                entity.Property(e => e.NomeEnteBeneficiario)
                    .HasMaxLength(100)
                    .HasColumnName("nome_ente_beneficiario");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.HasKey(e => e.IdFatura)
                    .HasName("PK__Fatura__F4902DCB48DF0313");

                entity.ToTable("Fatura");

                entity.HasIndex(e => e.DataVencimento, "idx_fatura_data_vencimento");

                entity.Property(e => e.IdFatura).HasColumnName("id_fatura");

                entity.Property(e => e.DataEmissao)
                    .HasColumnType("date")
                    .HasColumnName("data_emissao");

                entity.Property(e => e.DataVencimento)
                    .HasColumnType("date")
                    .HasColumnName("data_vencimento");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.StatusFatura).HasColumnName("status_fatura");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Faturas)
                    .HasForeignKey(d => d.IdServico)
                    .HasConstraintName("FK__Fatura__id_servi__534D60F1");
            });

            modelBuilder.Entity<FonteRecurso>(entity =>
            {
                entity.HasKey(e => e.IdFonteRecursos)
                    .HasName("PK__FonteRec__782360D86A7EE11A");

                entity.HasIndex(e => e.NomeFonteRecursos, "UQ__FonteRec__02AAF36B6DC751D7")
                    .IsUnique();

                entity.Property(e => e.IdFonteRecursos).HasColumnName("id_fonte_recursos");

                entity.Property(e => e.NomeFonteRecursos)
                    .HasMaxLength(50)
                    .HasColumnName("nome_fonte_recursos");
            });

            modelBuilder.Entity<NaturezaDespesa>(entity =>
            {
                entity.HasKey(e => e.IdNaturezaDespesa)
                    .HasName("PK__Natureza__68E222645138E531");

                entity.ToTable("NaturezaDespesa");

                entity.HasIndex(e => e.NomeNaturezaDespesa, "UQ__Natureza__50338DA49B3DB6E7")
                    .IsUnique();

                entity.Property(e => e.IdNaturezaDespesa).HasColumnName("id_natureza_despesa");

                entity.Property(e => e.NomeNaturezaDespesa)
                    .HasMaxLength(255)
                    .HasColumnName("nome_natureza_despesa");
            });

            modelBuilder.Entity<OrigemRepasse>(entity =>
            {
                entity.HasKey(e => e.IdOrigemRepasse)
                    .HasName("PK__OrigemRe__9599D5B19A13ED47");

                entity.ToTable("OrigemRepasse");

                entity.HasIndex(e => e.NomeOrigemRepasse, "UQ__OrigemRe__CFFB887529BAC006")
                    .IsUnique();

                entity.Property(e => e.IdOrigemRepasse).HasColumnName("id_origem_repasse");

                entity.Property(e => e.NomeOrigemRepasse)
                    .HasMaxLength(100)
                    .HasColumnName("nome_origem_repasse");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PK__Pagament__3A2D33F72BA6E8D5");

                entity.ToTable("Pagamento");

                entity.HasIndex(e => e.DataPagamento, "idx_pagamento_data_pagamento");

                entity.Property(e => e.IdPagamento).HasColumnName("id_pagamento");

                entity.Property(e => e.DataPagamento)
                    .HasColumnType("date")
                    .HasColumnName("data_pagamento");

                entity.Property(e => e.FormaPagamento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("forma_pagamento");

                entity.Property(e => e.IdFatura).HasColumnName("id_fatura");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdFaturaNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.IdFatura)
                    .HasConstraintName("FK__Pagamento__id_fa__571DF1D5");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__Projeto__274B9B6BCD381FCA");

                entity.ToTable("Projeto");

                entity.HasIndex(e => e.NomeProjeto, "idx_projeto_nome");

                entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.DataTermino)
                    .HasColumnType("date")
                    .HasColumnName("data_termino");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NomeProjeto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_projeto");

                entity.Property(e => e.StatusProjeto).HasColumnName("status_projeto");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Projeto__id_clie__4CA06362");
            });

            modelBuilder.Entity<RepasseFinanceiro>(entity =>
            {
                entity.HasKey(e => e.IdRepasseFinanceiro)
                    .HasName("PK__RepasseF__379C8103D936B5DA");

                entity.ToTable("RepasseFinanceiro");

                entity.HasIndex(e => e.DataEfetivacao, "idx_repasse_financeiro_data_efetivacao");

                entity.Property(e => e.IdRepasseFinanceiro).HasColumnName("id_repasse_financeiro");

                entity.Property(e => e.DataDistribuicao)
                    .HasColumnType("date")
                    .HasColumnName("data_distribuicao");

                entity.Property(e => e.DataEfetivacao)
                    .HasColumnType("date")
                    .HasColumnName("data_efetivacao");

                entity.Property(e => e.DescricaoRepasseFinanceiro)
                    .HasMaxLength(255)
                    .HasColumnName("descricao_repasse_financeiro");

                entity.Property(e => e.FinalidadeRepasseFinanceiro)
                    .HasMaxLength(255)
                    .HasColumnName("finalidade_repasse_financeiro");

                entity.Property(e => e.IdCreditoAdicional).HasColumnName("id_credito_adicional");

                entity.Property(e => e.IdDestinoRepasse).HasColumnName("id_destino_repasse");

                entity.Property(e => e.IdEnteBeneficiario).HasColumnName("id_ente_beneficiario");

                entity.Property(e => e.IdOrigemRepasse).HasColumnName("id_origem_repasse");

                entity.Property(e => e.ValorRepasseFinanceiro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor_repasse_financeiro");

                entity.HasOne(d => d.IdCreditoAdicionalNavigation)
                    .WithMany(p => p.RepasseFinanceiros)
                    .HasForeignKey(d => d.IdCreditoAdicional)
                    .HasConstraintName("FK__RepasseFi__id_cr__72C60C4A");

                entity.HasOne(d => d.IdDestinoRepasseNavigation)
                    .WithMany(p => p.RepasseFinanceiros)
                    .HasForeignKey(d => d.IdDestinoRepasse)
                    .HasConstraintName("FK__RepasseFi__id_de__75A278F5");

                entity.HasOne(d => d.IdEnteBeneficiarioNavigation)
                    .WithMany(p => p.RepasseFinanceiros)
                    .HasForeignKey(d => d.IdEnteBeneficiario)
                    .HasConstraintName("FK__RepasseFi__id_en__73BA3083");

                entity.HasOne(d => d.IdOrigemRepasseNavigation)
                    .WithMany(p => p.RepasseFinanceiros)
                    .HasForeignKey(d => d.IdOrigemRepasse)
                    .HasConstraintName("FK__RepasseFi__id_or__74AE54BC");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.IdServico)
                    .HasName("PK__Servico__D06FB5A25BCE7546");

                entity.ToTable("Servico");

                entity.HasIndex(e => e.DescricaoServico, "idx_servico_descricao");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.DescricaoServico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricao_servico");

                entity.Property(e => e.HorasTrabalhadas).HasColumnName("horas_trabalhadas");

                entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");

                entity.Property(e => e.ValorHora)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor_hora");

                entity.HasOne(d => d.IdProjetoNavigation)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.IdProjeto)
                    .HasConstraintName("FK__Servico__id_proj__5070F446");
            });

            modelBuilder.Entity<TipoCredito>(entity =>
            {
                entity.HasKey(e => e.IdTipoCredito)
                    .HasName("PK__TipoCred__E5C431A438263A39");

                entity.ToTable("TipoCredito");

                entity.HasIndex(e => e.NomeTipoCredito, "UQ__TipoCred__D624363BDD4C47D9")
                    .IsUnique();

                entity.Property(e => e.IdTipoCredito).HasColumnName("id_tipo_credito");

                entity.Property(e => e.NomeTipoCredito)
                    .HasMaxLength(50)
                    .HasColumnName("nome_tipo_credito");
            });

            modelBuilder.Entity<TipoDespesa>(entity =>
            {
                entity.HasKey(e => e.IdTipoDespesa)
                    .HasName("PK__TipoDesp__104D9A123C841FCC");

                entity.ToTable("TipoDespesa");

                entity.HasIndex(e => e.NomeTipoDespesa, "UQ__TipoDesp__D5FCCE1E2F742138")
                    .IsUnique();

                entity.Property(e => e.IdTipoDespesa).HasColumnName("id_tipo_despesa");

                entity.Property(e => e.NomeTipoDespesa)
                    .HasMaxLength(50)
                    .HasColumnName("nome_tipo_despesa");
            });

            modelBuilder.Entity<UnidadeGestora>(entity =>
            {
                entity.HasKey(e => e.IdUnidadeGestora)
                    .HasName("PK__UnidadeG__CF1D0B1FE6BF0290");

                entity.ToTable("UnidadeGestora");

                entity.HasIndex(e => e.NomeUnidadeGestora, "UQ__UnidadeG__FF8E3048D6E13ADA")
                    .IsUnique();

                entity.Property(e => e.IdUnidadeGestora).HasColumnName("id_unidade_gestora");

                entity.Property(e => e.NomeUnidadeGestora)
                    .HasMaxLength(100)
                    .HasColumnName("nome_unidade_gestora");
            });

            modelBuilder.Entity<UnidadeOrcamentarium>(entity =>
            {
                entity.HasKey(e => e.IdUnidadeOrcamentaria)
                    .HasName("PK__UnidadeO__FB73E58B9DB2E566");

                entity.HasIndex(e => e.NomeUnidadeOrcamentaria, "UQ__UnidadeO__4C9C56827A8B781A")
                    .IsUnique();

                entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("id_unidade_orcamentaria");

                entity.Property(e => e.NomeUnidadeOrcamentaria)
                    .HasMaxLength(100)
                    .HasColumnName("nome_unidade_orcamentaria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
