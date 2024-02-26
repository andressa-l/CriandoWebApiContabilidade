using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class EnteBeneficiario
    {
        public EnteBeneficiario()
        {
            CreditoAdicionals = new HashSet<CreditoAdicional>();
            RepasseFinanceiros = new HashSet<RepasseFinanceiro>();
        }

        public int IdEnteBeneficiario { get; set; }
        public string NomeEnteBeneficiario { get; set; } = null!;

        public virtual ICollection<CreditoAdicional> CreditoAdicionals { get; set; }
        public virtual ICollection<RepasseFinanceiro> RepasseFinanceiros { get; set; }
    }
}
