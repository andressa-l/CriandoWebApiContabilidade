using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class TipoCredito
    {
        public TipoCredito()
        {
            CreditoAdicionals = new HashSet<CreditoAdicional>();
        }

        public int IdTipoCredito { get; set; }
        public string NomeTipoCredito { get; set; } = null!;

        public virtual ICollection<CreditoAdicional> CreditoAdicionals { get; set; }
    }
}
