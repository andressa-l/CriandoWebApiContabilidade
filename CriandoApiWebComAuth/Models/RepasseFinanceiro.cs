using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class RepasseFinanceiro
    {
        public RepasseFinanceiro()
        {
            CronogramaOrcamentarios = new HashSet<CronogramaOrcamentario>();
        }

        public int IdRepasseFinanceiro { get; set; }
        public int? IdCreditoAdicional { get; set; }
        public string DescricaoRepasseFinanceiro { get; set; } = null!;
        public decimal ValorRepasseFinanceiro { get; set; }
        public DateTime DataDistribuicao { get; set; }
        public int? IdEnteBeneficiario { get; set; }
        public int? IdOrigemRepasse { get; set; }
        public int? IdDestinoRepasse { get; set; }
        public string FinalidadeRepasseFinanceiro { get; set; } = null!;
        public DateTime DataEfetivacao { get; set; }

        public virtual CreditoAdicional? IdCreditoAdicionalNavigation { get; set; }
        public virtual DestinoRepasse? IdDestinoRepasseNavigation { get; set; }
        public virtual EnteBeneficiario? IdEnteBeneficiarioNavigation { get; set; }
        public virtual OrigemRepasse? IdOrigemRepasseNavigation { get; set; }
        public virtual ICollection<CronogramaOrcamentario> CronogramaOrcamentarios { get; set; }
    }
}
