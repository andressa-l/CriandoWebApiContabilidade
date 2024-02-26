using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class AcaoOrcamentarium
    {
        public AcaoOrcamentarium()
        {
            CreditoAdicionals = new HashSet<CreditoAdicional>();
        }

        public int IdAcaoOrcamentaria { get; set; }
        public string NomeAcaoOrcamentaria { get; set; } = null!;

        public virtual ICollection<CreditoAdicional> CreditoAdicionals { get; set; }
    }
}
