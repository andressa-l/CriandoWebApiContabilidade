using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class NaturezaDespesa
    {
        public NaturezaDespesa()
        {
            CronogramaOrcamentarios = new HashSet<CronogramaOrcamentario>();
        }

        public int IdNaturezaDespesa { get; set; }
        public string NomeNaturezaDespesa { get; set; } = null!;

        public virtual ICollection<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; }
    }
}
