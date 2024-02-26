using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class UnidadeGestora
    {
        public UnidadeGestora()
        {
            CronogramaFinanceiros = new HashSet<CronogramaFinanceiro>();
        }

        public int IdUnidadeGestora { get; set; }
        public string NomeUnidadeGestora { get; set; } = null!;

        public virtual ICollection<CronogramaFinanceiro> CronogramaFinanceiros { get; set; }
    }
}
