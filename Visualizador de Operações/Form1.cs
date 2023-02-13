using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visualizador_de_Operações.Classes;
using Visualizador_de_Operações.Sevices;

namespace Visualizador_de_Operações
{
    public partial class Form1 : Form
    {
        List<Operacao> operacoesCache;
        List<Agrupamento> ativosCache = new List<Agrupamento>();
        List<Agrupamento> tipoOperacaoCache = new List<Agrupamento>();
        List<Agrupamento> contaCache = new List<Agrupamento>();
        bool cacheAtivoPrepado, cacheTipoOperacaoPreparado, cacheContaPreparado;

        int visualizacaoAtual = 0; // 0 = tudo / 1 = Ativo / 2 = tipoOperacao / 3 = conta 
        Stopwatch sw = new Stopwatch();


        public Form1()
        {
            InitializeComponent();
            sw.Start();
            ReceberMassa();

        }


        private  async Task ReceberMassa() {
            OperacaoServices operacaoServices = new OperacaoServices();


            List<Operacao> operacoes = await operacaoServices.BuscarTudo();
            sw.Stop();

            dataGridView1.DataSource = operacoes;
            label1.Text = "Milissegundos de requisição API:" + sw.ElapsedMilliseconds.ToString();
            operacoesCache = operacoes;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e){}

        private void Form1_Load(object sender, EventArgs e){}


        private void mostrarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizacaoAtual = 0;
            dataGridView1.DataSource = operacoesCache;
            label1.Text = "Milissegundos de requisição API:" + 0;
        }

        private void ativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizacaoAtual = 1;
            if (cacheAtivoPrepado)
            {
                dataGridView1.DataSource = ativosCache;
                label1.Text = "Milissegundos de requisição API:" + 0;
            }
            else
            {
                sw.Restart();
                ReceberAgupamentoAtivo(1);
                
            }
        }

        private void tipoOperacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizacaoAtual = 2;
            if (cacheTipoOperacaoPreparado)
            {
                dataGridView1.DataSource = tipoOperacaoCache;
                label1.Text = "Milissegundos de requisição API:" + 0;
            }
            else
            {
                sw.Restart();
                ReceberAgupamentoAtivo(2);
            }
        }
        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizacaoAtual = 3;
            if (cacheContaPreparado)
            {
                dataGridView1.DataSource = contaCache;
                label1.Text = "Milissegundos de requisição API:" + 0;
            }
            else
            {
                sw.Restart();
                ReceberAgupamentoAtivo(3);
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacaoServices operacaoServices = new OperacaoServices();

            operacaoServices.Exportar(visualizacaoAtual, 2);// 2 = excel
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {


            OperacaoServices operacaoServices = new OperacaoServices();

            operacaoServices.Exportar(visualizacaoAtual, 1);// 0 = csv
        }





        private async Task ReceberAgupamentoAtivo(int tipoOperacao)
        {
            OperacaoServices operacaoServices = new OperacaoServices();


            List<Agrupamento> agrupamento = await operacaoServices.BuscarAgrupamento(tipoOperacao);
            sw.Stop();
            dataGridView1.DataSource = agrupamento;
            label1.Text = "Milissegundos de requisição API:" + sw.ElapsedMilliseconds.ToString();
            if (tipoOperacao == 1)
            {
                ativosCache = agrupamento;
                cacheAtivoPrepado = true;
            }
            else if (tipoOperacao == 2)
            {
                tipoOperacaoCache = agrupamento;
                cacheTipoOperacaoPreparado = true;
            }
            else
            {
                contaCache = agrupamento;
                cacheContaPreparado = true;
            }

        }
    }
}
