using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class CreditosAdicionai
    {
        public int IdCreditosAdicionais { get; set; }
        public int EnteId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime DataAdicao { get; set; }
        public string TipoCredito { get; set; } = null!;

        public virtual Ente Ente { get; set; } = null!;
    }
}
