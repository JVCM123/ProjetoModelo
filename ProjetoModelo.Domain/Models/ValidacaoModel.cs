using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Domain.Models
{
    public class ValidacaoModel
    {
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }
    }
}
