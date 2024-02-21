using System;
using System.Collections.Generic;

namespace CriandoWebApiContabilidade.Models
{
    public partial class Receita
    {
        public int IdReceitas { get; set; }
        public int EnteId { get; set; }
        public string Categoria { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime DataReceita { get; set; }

        public virtual Ente Ente { get; set; } = null!;
    }
}
