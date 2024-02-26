using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class UnidadeOrcamentarium
    {
        public UnidadeOrcamentarium()
        {
            CronogramaOrcamentarios = new HashSet<CronogramaOrcamentario>();
        }

        public int IdUnidadeOrcamentaria { get; set; }
        public string NomeUnidadeOrcamentaria { get; set; } = null!;

        public virtual ICollection<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; }
    }
}
