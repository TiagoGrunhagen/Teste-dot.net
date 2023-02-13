using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace geradorDeMassa
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Operacao> operacoes = new List<Operacao>();

            for (int i = 0; i < 20000; i++) {
                Operacao operacao = new Operacao();
                operacao.id = i+1;


                Random randNum = new Random();
                int dia = randNum.Next(1, 32);
                int hora = randNum.Next(0, 24);
                int minuto = randNum.Next(0, 60);
                int segundo = randNum.Next(0, 60);

                DateTime data;
                data = new DateTime(2023, 1, dia, hora, minuto, segundo);

                operacao.dateTime = data;

                int TipOperacao = randNum.Next(0,2);
                if (TipOperacao == 0) {
                    operacao.tipoOperacao = 'C';
                }
                else
                    operacao.tipoOperacao = 'V';

                int ativo = randNum.Next(0, 10);
                switch (ativo)
                {
                    case 0:
                        operacao.ativo = "BBXC4";
                        break;
                    case 1:
                        operacao.ativo = "VAXE3";
                        break;
                    case 2:
                        operacao.ativo = "PEXR4";
                        break;
                    case 3:
                        operacao.ativo = "ITXB4";
                        break;
                    case 4:
                        operacao.ativo = "PEXR3";
                        break;
                    case 5:
                        operacao.ativo = "ABXV3";
                        break;
                    case 6:
                        operacao.ativo = "BBXS3";
                        break;
                    case 7:
                        operacao.ativo = "GGXR4";
                        break;
                    case 8:
                        operacao.ativo = "MGXU3";
                        break;
                    case 9:
                        operacao.ativo = "REXT3";
                        break;
                }


                int quantidade = randNum.Next(200, 4000);
                operacao.quantidade = quantidade;


                Double centavos = randNum.NextDouble();
                float valor = randNum.Next(1, 100);
                valor += (float)centavos;
                operacao.preco = Math.Round(valor, 2); ;


                int conta = randNum.Next(0, 200);
                conta += 4500;
                operacao.conta = conta;

                operacoes.Add(operacao);

            }

            var caminhoArquivo = @"C:\Users\Tiago\Desktop\massaOperacoes.json";
            var json = JsonConvert.SerializeObject(operacoes, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
        }

    }
}
