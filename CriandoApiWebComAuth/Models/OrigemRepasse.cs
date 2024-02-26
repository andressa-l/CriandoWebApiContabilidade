using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class OrigemRepasse
    {
        public OrigemRepasse()
        {
            RepasseFinanceiros = new HashSet<RepasseFinanceiro>();
        }

        public int IdOrigemRepasse { get; set; }
        public string NomeOrigemRepasse { get; set; } = null!;

        public virtual ICollection<RepasseFinanceiro> RepasseFinanceiros { get; set; }
    }
}
