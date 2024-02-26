using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class CreditoAdicional
    {
        public CreditoAdicional()
        {
            RepasseFinanceiros = new HashSet<RepasseFinanceiro>();
        }

        public int IdCreditoAdicional { get; set; }
        public int? IdPagamento { get; set; }
        public string DescricaoCreditoAdicional { get; set; } = null!;
        public decimal ValorCreditoAdicional { get; set; }
        public DateTime DataDistribuicao { get; set; }
        public int? IdEnteBeneficiario { get; set; }
        public int? IdTipoCredito { get; set; }
        public int? IdAcaoOrcamentaria { get; set; }
        public int? IdFonteRecursos { get; set; }
        public DateTime DataAprovacao { get; set; }

        public virtual AcaoOrcamentarium? IdAcaoOrcamentariaNavigation { get; set; }
        public virtual EnteBeneficiario? IdEnteBeneficiarioNavigation { get; set; }
        public virtual FonteRecurso? IdFonteRecursosNavigation { get; set; }
        public virtual Pagamento? IdPagamentoNavigation { get; set; }
        public virtual TipoCredito? IdTipoCreditoNavigation { get; set; }
        public virtual ICollection<RepasseFinanceiro> RepasseFinanceiros { get; set; }
    }
}
