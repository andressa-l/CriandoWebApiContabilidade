using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class CronogramaFinanceiro
    {
        public int IdCronogramaFinanceiro { get; set; }
        public int? IdCronogramaOrcamentario { get; set; }
        public string PeriodoCronogramaFinanceiro { get; set; } = null!;
        public decimal LimiteLiquidacoes { get; set; }
        public int? IdUnidadeGestora { get; set; }
        public int? IdTipoDespesa { get; set; }
        public DateTime DataReferencia { get; set; }

        public virtual CronogramaOrcamentario? IdCronogramaOrcamentarioNavigation { get; set; }
        public virtual TipoDespesa? IdTipoDespesaNavigation { get; set; }
        public virtual UnidadeGestora? IdUnidadeGestoraNavigation { get; set; }
    }
}
