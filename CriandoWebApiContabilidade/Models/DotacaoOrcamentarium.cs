using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class DotacaoOrcamentarium
    {
        public int IdDotacaoOrcamentaria { get; set; }
        public int? IdRepasses { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime DataDistribuicao { get; set; }
        public int? IdDespesas { get; set; }
        public DateTime DataEmpenho { get; set; }
        public DateTime DataLiquidacao { get; set; }
        public DateTime DataPagamento { get; set; }

        public virtual Despesa? IdDespesasNavigation { get; set; }
        public virtual RepassesFinanceiro? IdRepassesNavigation { get; set; }
    }
}
