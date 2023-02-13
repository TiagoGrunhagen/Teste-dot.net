using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;



namespace WebAPI.Controllers
{
    public class OperacoesController : ApiController
    {

        public IEnumerable<Operacao> Get() { // Mostrar tudo

            Operacao operacao = new Operacao();
            return operacao.listaOperacao();
        }

        public IEnumerable<Agrupamento> Get(int id)
        {
            Operacao operacao = new Operacao();

            if (id == 1) //Agrupar por ativo
            {
                List<Agrupamento> ativos = new List<Agrupamento>();
                List<Operacao> operacoes = operacao.listaOperacao();

                var operacoesArupadas = operacoes.GroupBy(oper => oper.ativo); //Agrupa por ativo
                foreach (var group in operacoesArupadas) //Para cada Ativo
                {
                    Agrupamento ativo = new Agrupamento();
                    ativo.tipoAgrupamento = group.Key;  //Ativo
                    int somaQuantidades = 0;
                    int qtdOperacoes = 0;
                    float precoOperado = 0;
                    foreach (var oper in group) //Para cada operacao realizada com este ativo prepara as váriaveis para o calculo do preço médio e a soa das quantidades
                    {
                        somaQuantidades += oper.quantidade;
                        qtdOperacoes++;

                        precoOperado += (float)(oper.quantidade * oper.preco);
                    }
                    ativo.somaDasQuantidades = somaQuantidades;
                    ativo.precoMedio = precoOperado / somaQuantidades;
                    ativo.precoMedio = (float)Math.Round(ativo.precoMedio, 2);
             
                    ativos.Add(ativo);

                }

                return ativos;
            }
            else if (id == 2) //Agrupar por tipo da operação
            {
                List<Agrupamento> tiposOperacao = new List<Agrupamento>();
                List<Operacao> operacoes = operacao.listaOperacao();

                var operacoesArupadas = operacoes.GroupBy(oper => oper.tipoOperacao); //Agrupa por tipoOperacao
                foreach (var group in operacoesArupadas) //Para cada tipoOperacao (2)
                {
                    Agrupamento tipoOperacao = new Agrupamento();
                    tipoOperacao.tipoAgrupamento = group.Key.ToString();  //tipoOperacao
                    int somaQuantidades = 0;
                    int qtdOperacoes = 0;
                    float precoOperado = 0;
                    foreach (var oper in group) //Para cada operacao realizada com este tipo de operacao prepara as váriaveis para o calculo do preço médio e a soa das quantidades
                    {
                        somaQuantidades += oper.quantidade;
                        qtdOperacoes++;

                        precoOperado += (float)(oper.quantidade * oper.preco);
                    }
                    tipoOperacao.somaDasQuantidades = somaQuantidades;
                    tipoOperacao.precoMedio = precoOperado / somaQuantidades;
                    tipoOperacao.precoMedio = (float)Math.Round(tipoOperacao.precoMedio, 2);

                    tiposOperacao.Add(tipoOperacao);
                }

                return tiposOperacao;
            }
            else if (id == 3) //Agrupar por conta
            {
                List<Agrupamento> contas = new List<Agrupamento>();
                List<Operacao> operacoes = operacao.listaOperacao();

                var operacoesArupadas = operacoes.GroupBy(oper => oper.conta); //Agrupa por conta
                foreach (var group in operacoesArupadas) //Para cada conta
                {
                    Agrupamento conta = new Agrupamento();
                    conta.tipoAgrupamento = group.Key.ToString();  //conta
                    int somaQuantidades = 0;
                    int qtdOperacoes = 0;
                    float precoOperado = 0;
                    foreach (var oper in group) //Para cada operacao realizada com essa conta prepara as váriaveis para o calculo do preço médio e a soa das quantidades
                    {
                        somaQuantidades += oper.quantidade;
                        qtdOperacoes++;

                        precoOperado += (float)(oper.quantidade * oper.preco);
                    }
                    conta.somaDasQuantidades = somaQuantidades;
                    conta.precoMedio = precoOperado / somaQuantidades;
                    conta.precoMedio = (float)Math.Round(conta.precoMedio, 2);

                    contas.Add(conta);
                }

                return contas;
            }
            else
                return null;

        }


    }
}
 