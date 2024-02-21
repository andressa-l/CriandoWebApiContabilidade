using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class CronogramaFinanceiro
    {
        public int IdCronogramaFinanceiro { get; set; }
        public int EnteId { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public decimal LimiteLiquidacoes { get; set; }

        public virtual Ente Ente { get; set; } = null!;
    }
}
