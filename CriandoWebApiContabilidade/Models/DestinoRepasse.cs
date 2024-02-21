using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class DestinoRepasse
    {
        public int IdDestino { get; set; }
        public int IdRepasseDestino { get; set; }
        public string NomeDestinoRepasse { get; set; } = null!;
        public int IdRepasses { get; set; }

        public virtual RepassesFinanceiro IdRepassesNavigation { get; set; } = null!;
    }
}
