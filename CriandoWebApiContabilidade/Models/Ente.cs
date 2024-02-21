using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class Ente
    {
        public Ente()
        {
            CreditosAdicionais = new HashSet<CreditosAdicionai>();
            CronogramaFinanceiros = new HashSet<CronogramaFinanceiro>();
            CronogramaOrcamentarios = new HashSet<CronogramaOrcamentario>();
            Despesas = new HashSet<Despesa>();
            Receita = new HashSet<Receita>();
            RepassesFinanceiros = new HashSet<RepassesFinanceiro>();
        }

        public int EnteId { get; set; }
        public string NomeOrgao { get; set; } = null!;
        public string TipoEntidade { get; set; } = null!;

        public virtual ICollection<CreditosAdicionai> CreditosAdicionais { get; set; }
        public virtual ICollection<CronogramaFinanceiro> CronogramaFinanceiros { get; set; }
        public virtual ICollection<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; }
        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Receita> Receita { get; set; }
        public virtual ICollection<RepassesFinanceiro> RepassesFinanceiros { get; set; }
    }
}
