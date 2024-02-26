using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class CronogramaOrcamentario
    {
        public CronogramaOrcamentario()
        {
            CronogramaFinanceiros = new HashSet<CronogramaFinanceiro>();
        }

        public int IdCronogramaOrcamentario { get; set; }
        public int? IdRepasseFinanceiro { get; set; }
        public string PeriodoCronogramaOrcamentario { get; set; } = null!;
        public decimal LimiteOrcamento { get; set; }
        public int? IdUnidadeOrcamentaria { get; set; }
        public int? IdCategoriaEconomica { get; set; }
        public int? IdNaturezaDespesa { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual CategoriaEconomica? IdCategoriaEconomicaNavigation { get; set; }
        public virtual NaturezaDespesa? IdNaturezaDespesaNavigation { get; set; }
        public virtual RepasseFinanceiro? IdRepasseFinanceiroNavigation { get; set; }
        public virtual UnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }
        public virtual ICollection<CronogramaFinanceiro> CronogramaFinanceiros { get; set; }
    }
}
