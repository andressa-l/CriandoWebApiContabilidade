using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class DestinoRepasse
    {
        public DestinoRepasse()
        {
            RepasseFinanceiros = new HashSet<RepasseFinanceiro>();
        }

        public int IdDestinoRepasse { get; set; }
        public string NomeDestinoRepasse { get; set; } = null!;

        public virtual ICollection<RepasseFinanceiro> RepasseFinanceiros { get; set; }
    }
}
