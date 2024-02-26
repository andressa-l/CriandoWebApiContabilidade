using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class CategoriaEconomica
    {
        public CategoriaEconomica()
        {
            CronogramaOrcamentarios = new HashSet<CronogramaOrcamentario>();
        }

        public int IdCategoriaEconomica { get; set; }
        public string NomeCategoriaEconomica { get; set; } = null!;

        public virtual ICollection<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; }
    }
}
