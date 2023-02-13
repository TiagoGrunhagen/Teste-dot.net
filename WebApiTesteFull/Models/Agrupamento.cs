using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Agrupamento
    {

        public string tipoAgrupamento { get; set; }

        public double somaDasQuantidades { get; set; }

        public float precoMedio { get; set; }

        public static implicit operator string(Agrupamento agrupamento)
        => $"{agrupamento.tipoAgrupamento}, {agrupamento.somaDasQuantidades.ToString()}, {agrupamento.precoMedio.ToString().Replace(',','.')}";
    }
}