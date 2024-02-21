using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class Despesa
    {
        public Despesa()
        {
            DotacaoOrcamentaria = new HashSet<DotacaoOrcamentarium>();
        }

        public int IdDespesas { get; set; }
        public int EnteId { get; set; }
        public string Categoria { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime DataDespesa { get; set; }

        public virtual Ente Ente { get; set; } = null!;
        public virtual ICollection<DotacaoOrcamentarium> DotacaoOrcamentaria { get; set; }
    }
}
