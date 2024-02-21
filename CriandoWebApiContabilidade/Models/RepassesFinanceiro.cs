using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class RepassesFinanceiro
    {
        public RepassesFinanceiro()
        {
            DestinoRepasses = new HashSet<DestinoRepasse>();
            DotacaoOrcamentaria = new HashSet<DotacaoOrcamentarium>();
            OrigemRepasses = new HashSet<OrigemRepasse>();
        }

        public int IdRepasses { get; set; }
        public int EnteId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime DataRepasso { get; set; }
        public int IdOrigem { get; set; }
        public int IdDestino { get; set; }

        public virtual Ente Ente { get; set; } = null!;
        public virtual ICollection<DestinoRepasse> DestinoRepasses { get; set; }
        public virtual ICollection<DotacaoOrcamentarium> DotacaoOrcamentaria { get; set; }
        public virtual ICollection<OrigemRepasse> OrigemRepasses { get; set; }
    }
}
