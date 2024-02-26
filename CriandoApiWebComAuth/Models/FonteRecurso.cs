using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class FonteRecurso
    {
        public FonteRecurso()
        {
            CreditoAdicionals = new HashSet<CreditoAdicional>();
        }

        public int IdFonteRecursos { get; set; }
        public string NomeFonteRecursos { get; set; } = null!;

        public virtual ICollection<CreditoAdicional> CreditoAdicionals { get; set; }
    }
}
