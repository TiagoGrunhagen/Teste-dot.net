using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Text;



namespace geradorDeMassa
{
    class Operacao
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
