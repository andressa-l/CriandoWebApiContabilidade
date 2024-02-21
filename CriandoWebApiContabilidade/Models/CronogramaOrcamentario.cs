using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class CronogramaOrcamentario
    {
        public int IdCronogramaOrcamentario { get; set; }
        public int EnteId { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public decimal LimiteOrcamento { get; set; }

        public virtual Ente Ente { get; set; } = null!;
    }
}
