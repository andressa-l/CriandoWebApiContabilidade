using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class Projeto
    {
        public Projeto()
        {
            Servicos = new HashSet<Servico>();
        }

        public int IdProjeto { get; set; }
        public int? IdCliente { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public decimal Valor { get; set; }
        public bool StatusProjeto { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
