using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class Servico
    {
        public Servico()
        {
            Faturas = new HashSet<Fatura>();
        }

        public int IdServico { get; set; }
        public int? IdProjeto { get; set; }
        public string DescricaoServico { get; set; } = null!;
        public short HorasTrabalhadas { get; set; }
        public decimal ValorHora { get; set; }

        public virtual Projeto? IdProjetoNavigation { get; set; }
        public virtual ICollection<Fatura> Faturas { get; set; }
    }
}
