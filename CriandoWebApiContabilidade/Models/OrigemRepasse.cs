using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class OrigemRepasse
    {
        public int IdOrigem { get; set; }
        public int IdRepasseOrigem { get; set; }
        public string NomeOrigemRepasse { get; set; } = null!;
        public int IdRepasses { get; set; }

        public virtual RepassesFinanceiro IdRepassesNavigation { get; set; } = null!;
    }
}
