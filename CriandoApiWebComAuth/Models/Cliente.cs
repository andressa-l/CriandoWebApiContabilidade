using System;
using System.Collections.Generic;

namespace CriandoApiWebComAuth.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdCliente { get; set; }
        public string NomeCliente { get; set; } = null!;
        public string EnderecoCliente { get; set; } = null!;
        public string TelefoneCliente { get; set; } = null!;
        public string EmailCliente { get; set; } = null!;

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
