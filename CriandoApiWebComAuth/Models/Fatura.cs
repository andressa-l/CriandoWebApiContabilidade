using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class Fatura
    {
        public Fatura()
        {
            Pagamentos = new HashSet<Pagamento>();
        }

        public int IdFatura { get; set; }
        public int? IdServico { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public bool StatusFatura { get; set; }

        public virtual Servico? IdServicoNavigation { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}
