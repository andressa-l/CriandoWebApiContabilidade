using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CriandoWebApiContabilidade.Models
{
    public partial class db_contabilidade_3tecnosContext : DbContext
    {
        public db_contabilidade_3tecnosContext()
        {
        }

        public db_contabilidade_3tecnosContext(DbContextOptions<db_contabilidade_3tecnosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditosAdicionai> CreditosAdicionais { get; set; } = null!;
        public virtual DbSet<CronogramaFinanceiro> CronogramaFinanceiros { get; set; } = null!;
        public virtual DbSet<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; } = null!;
        public virtual DbSet<Despesa> Despesas { get; set; } = null!;
        public virtual DbSet<DestinoRepasse> DestinoRepasses { get; set; } = null!;
        public virtual DbSet<DotacaoOrcamentarium> DotacaoOrcamentaria { get; set; } = null!;
        public virtual DbSet<Ente> Entes { get; set; } = null!;
        public virtual DbSet<OrigemRepasse> OrigemRepasses { get; set; } = null!;
        public virtual DbSet<Receita> Receitas { get; set; } = null!;
        public virtual DbSet<RepassesFinanceiro> RepassesFinanceiros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditosAdicionai>(entity =>
            {
                entity.HasKey(e => e.IdCreditosAdicionais)
                    .HasName("creditos_id_creditos_adicionais_pk");

                entity.Property(e => e.IdCreditosAdicionais).HasColumnName("id_creditos_adicionais");

                entity.Property(e => e.DataAdicao)
                    .HasColumnType("date")
                    .HasColumnName("data_adicao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.TipoCredito)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_credito");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.CreditosAdicionais)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_creditos_adicionais");
            });

            modelBuilder.Entity<CronogramaFinanceiro>(entity =>
            {
                entity.HasKey(e => e.IdCronogramaFinanceiro)
                    .HasName("pk_cronograma_financeiro");

                entity.ToTable("CronogramaFinanceiro");

                entity.Property(e => e.IdCronogramaFinanceiro).HasColumnName("id_cronograma_financeiro");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.LimiteLiquidacoes)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("limite_liquidacoes");

                entity.Property(e => e.PeriodoFim)
                    .HasColumnType("date")
                    .HasColumnName("periodo_fim");

                entity.Property(e => e.PeriodoInicio)
                    .HasColumnType("date")
                    .HasColumnName("periodo_inicio");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.CronogramaFinanceiros)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cronograma_financeiro");
            });

            modelBuilder.Entity<CronogramaOrcamentario>(entity =>
            {
                entity.HasKey(e => e.IdCronogramaOrcamentario)
                    .HasName("pk_cronograma_orcamentario");

                entity.ToTable("CronogramaOrcamentario");

                entity.Property(e => e.IdCronogramaOrcamentario).HasColumnName("id_cronograma_orcamentario");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.LimiteOrcamento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("limite_orcamento");

                entity.Property(e => e.PeriodoFim)
                    .HasColumnType("date")
                    .HasColumnName("periodo_fim");

                entity.Property(e => e.PeriodoInicio)
                    .HasColumnType("date")
                    .HasColumnName("periodo_inicio");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.CronogramaOrcamentarios)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cronograma_orcamentario_entes");
            });

            modelBuilder.Entity<Despesa>(entity =>
            {
                entity.HasKey(e => e.IdDespesas)
                    .HasName("pk_despesas");

                entity.Property(e => e.IdDespesas).HasColumnName("id_despesas");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.DataDespesa)
                    .HasColumnType("date")
                    .HasColumnName("data_despesa");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.Despesas)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_despesas");
            });

            modelBuilder.Entity<DestinoRepasse>(entity =>
            {
                entity.HasKey(e => e.IdDestino)
                    .HasName("destino_id_destino_repasse_pk");

                entity.ToTable("DestinoRepasse");

                entity.HasIndex(e => e.NomeDestinoRepasse, "UQ__DestinoR__572BB50509B74339")
                    .IsUnique();

                entity.Property(e => e.IdDestino)
                    .ValueGeneratedNever()
                    .HasColumnName("id_destino");

                entity.Property(e => e.IdRepasseDestino).HasColumnName("id_repasse_destino");

                entity.Property(e => e.IdRepasses).HasColumnName("id_repasses");

                entity.Property(e => e.NomeDestinoRepasse)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome_destino_repasse");

                entity.HasOne(d => d.IdRepassesNavigation)
                    .WithMany(p => p.DestinoRepasses)
                    .HasForeignKey(d => d.IdRepasses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("financeiro_destino_repasse_fk");
            });

            modelBuilder.Entity<DotacaoOrcamentarium>(entity =>
            {
                entity.HasKey(e => e.IdDotacaoOrcamentaria)
                    .HasName("PK__DotacaoO__4FD20D4FA13BC362");

                entity.Property(e => e.IdDotacaoOrcamentaria).HasColumnName("id_dotacao_orcamentaria");

                entity.Property(e => e.DataDistribuicao)
                    .HasColumnType("date")
                    .HasColumnName("data_distribuicao");

                entity.Property(e => e.DataEmpenho)
                    .HasColumnType("date")
                    .HasColumnName("data_empenho");

                entity.Property(e => e.DataLiquidacao)
                    .HasColumnType("date")
                    .HasColumnName("data_liquidacao");

                entity.Property(e => e.DataPagamento)
                    .HasColumnType("date")
                    .HasColumnName("data_pagamento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdDespesas).HasColumnName("id_despesas");

                entity.Property(e => e.IdRepasses).HasColumnName("id_repasses");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdDespesasNavigation)
                    .WithMany(p => p.DotacaoOrcamentaria)
                    .HasForeignKey(d => d.IdDespesas)
                    .HasConstraintName("FK__DotacaoOr__id_de__5441852A");

                entity.HasOne(d => d.IdRepassesNavigation)
                    .WithMany(p => p.DotacaoOrcamentaria)
                    .HasForeignKey(d => d.IdRepasses)
                    .HasConstraintName("FK__DotacaoOr__id_re__534D60F1");
            });

            modelBuilder.Entity<Ente>(entity =>
            {
                entity.HasIndex(e => e.NomeOrgao, "UQ__Entes__607A4B68BB3F932A")
                    .IsUnique();

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.NomeOrgao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_orgao");

                entity.Property(e => e.TipoEntidade)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_entidade");
            });

            modelBuilder.Entity<OrigemRepasse>(entity =>
            {
                entity.HasKey(e => e.IdOrigem)
                    .HasName("origem_repasse_id_origem_pk");

                entity.ToTable("OrigemRepasse");

                entity.HasIndex(e => e.NomeOrigemRepasse, "UQ__OrigemRe__CFFB88758B0CC661")
                    .IsUnique();

                entity.Property(e => e.IdOrigem)
                    .ValueGeneratedNever()
                    .HasColumnName("id_origem");

                entity.Property(e => e.IdRepasseOrigem).HasColumnName("id_repasse_origem");

                entity.Property(e => e.IdRepasses).HasColumnName("id_repasses");

                entity.Property(e => e.NomeOrigemRepasse)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome_origem_repasse");

                entity.HasOne(d => d.IdRepassesNavigation)
                    .WithMany(p => p.OrigemRepasses)
                    .HasForeignKey(d => d.IdRepasses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("financeiro_origem_repasse_fk");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.IdReceitas)
                    .HasName("pk_id_receitas");

                entity.Property(e => e.IdReceitas).HasColumnName("id_receitas");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.DataReceita)
                    .HasColumnType("date")
                    .HasColumnName("data_receita");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.Receita)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_receitas");
            });

            modelBuilder.Entity<RepassesFinanceiro>(entity =>
            {
                entity.HasKey(e => e.IdRepasses)
                    .HasName("pk_repasses_id_repasse");

                entity.Property(e => e.IdRepasses)
                    .ValueGeneratedNever()
                    .HasColumnName("id_repasses");

                entity.Property(e => e.DataRepasso)
                    .HasColumnType("date")
                    .HasColumnName("data_repasso");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.EnteId).HasColumnName("ente_id");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.IdOrigem).HasColumnName("id_origem");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Ente)
                    .WithMany(p => p.RepassesFinanceiros)
                    .HasForeignKey(d => d.EnteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_repasses_financeiros");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
