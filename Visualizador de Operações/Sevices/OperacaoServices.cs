using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Visualizador_de_Operações.Classes;
using Microsoft.Office.Interop.Excel;


namespace Visualizador_de_Operações.Sevices
{
    class OperacaoServices
    {
        public async Task<List<Operacao>> BuscarTudo() {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44375/api/operacoes/");
            var jsonString = await response.Content.ReadAsStringAsync();

            List<Operacao> jsonObject = JsonConvert.DeserializeObject<List<Operacao>>(jsonString);

            return jsonObject;
        }


        public async Task<List<Agrupamento>> BuscarAgrupamento(int tipoAgrupamento)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/operacoes/{tipoAgrupamento}");
            var jsonString = await response.Content.ReadAsStringAsync();

            List<Agrupamento> jsonObject = JsonConvert.DeserializeObject<List<Agrupamento>>(jsonString);

            return jsonObject;
        }

        public async void Exportar(int tipoAgrupamento, int tipoExportacao)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/exportacoes/{tipoAgrupamento}");
            var json = await response.Content.ReadAsStringAsync();
            var myList = JsonConvert.DeserializeObject<List<string>>(json);

            if (tipoExportacao == 1)
            {
                if (tipoAgrupamento == 0)
                    File.WriteAllLines(@".\tudo.csv", myList);
                else if (tipoAgrupamento == 1)
                    File.WriteAllLines(@".\ativo.csv", myList);
                else if (tipoAgrupamento == 2)
                    File.WriteAllLines(@".\tipoOperacao.csv", myList);
                else if (tipoAgrupamento == 3)
                    File.WriteAllLines(@".\conta.csv", myList);
            }
            else {
                Application app = new Application();
                app.Visible = true;

                Workbook wb = app.Workbooks.Add(1);
                Worksheet ws = (Worksheet)wb.Worksheets[1];
                if (tipoAgrupamento == 0)
                {
                    ws.Cells[1, 1] = "id";
                    ws.Cells[1, 2] = "Data";
                    ws.Cells[1, 3] = "Tipo Operacao";
                    ws.Cells[1, 4] = "Ativo";
                    ws.Cells[1, 5] = "Quantidade";
                    ws.Cells[1, 6] = "Preco";
                    ws.Cells[1, 7] = "Conta";
                }
                else {
                    ws.Cells[1, 1] = "Agrupamento";
                    ws.Cells[1, 2] = "Soma Das Quantidades";
                    ws.Cells[1, 3] = "Preço Médio";
                }
                int linha = 2, coluna = 1;
                foreach (var linhaString in myList)
                {
                    coluna = 1;
                    string[] colunas = linhaString.Split(',');
                    foreach (var atributo in colunas) {
                        ws.Cells[linha, coluna] = atributo;
                        coluna++;

                    }
                    linha++;
                }

            }



        }
    }
}
