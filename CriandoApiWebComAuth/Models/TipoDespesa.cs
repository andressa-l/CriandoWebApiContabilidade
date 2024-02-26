using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class TipoDespesa
    {
        public TipoDespesa()
        {
            CronogramaFinanceiros = new HashSet<CronogramaFinanceiro>();
        }

        public int IdTipoDespesa { get; set; }
        public string NomeTipoDespesa { get; set; } = null!;

        public virtual ICollection<CronogramaFinanceiro> CronogramaFinanceiros { get; set; }
    }
}
