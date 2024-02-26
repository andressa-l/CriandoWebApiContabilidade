using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class Pagamento
    {
        public Pagamento()
        {
            CreditoAdicionals = new HashSet<CreditoAdicional>();
        }

        public int IdPagamento { get; set; }
        public int? IdFatura { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; } = null!;

        public virtual Fatura? IdFaturaNavigation { get; set; }
        public virtual ICollection<CreditoAdicional> CreditoAdicionals { get; set; }
    }
}
