using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebAPI.Models
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


        public static implicit operator string(Operacao operacao)
            => $"{operacao.id.ToString()},{operacao.dateTime.ToString(format:"dd/MM/yyyy")},{operacao.tipoOperacao.ToString()},{operacao.ativo},{operacao.quantidade.ToString()},{operacao.preco.ToString().Replace(',', '.')},{operacao.conta.ToString()}";

        public List<Operacao> listaOperacao() {

            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/massaOperacoes.json");
            var json = File.ReadAllText(caminhoArquivo);
            var ListaOperacoes = JsonConvert.DeserializeObject<List<Operacao>>(json);


            return ListaOperacoes;
        }


    }




}