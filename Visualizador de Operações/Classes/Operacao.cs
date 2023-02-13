using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizador_de_Operações.Classes
{
    public class Operacao
    {
        public long id { get; set; }
        public DateTime dateTime { get; set; }
        public char tipoOperacao { get; set; }
        public string ativo { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public int conta { get; set; }
    }
}