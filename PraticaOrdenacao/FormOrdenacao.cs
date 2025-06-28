using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Pratica5
{
    public partial class FormOrdenacao : Form
    {

        int[] vet = new int[500]; // vetor interno para a animação

        public FormOrdenacao()
        {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < vet.Length; i++)
            {
                e.Graphics.DrawLine(Pens.BlueViolet, i, 299, i, 299 - vet[i]);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "Prática 5 2025/1 - Métodos de Ordenação\n\n" +
                "Desenvolvido por:\n72500964 - Otávio Tadeu Magalhães Ferreira\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Apenas para fins didáticos.",
                "Sobre o trabalho...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void iniciaAnimacao(Action a)
        {
            if (bgw.IsBusy != true)
            {
                //Escolhe a ordem de preenchimento do vetor

                if (Ordem.SelectedIndex == 0)
                {
                    Preenchimento.Aleatorio(vet, 300);
                    bgw.RunWorkerAsync(a);
                }
                else if (Ordem.SelectedIndex == 1)
                {
                    Preenchimento.Crescente(vet, 300);
                    bgw.RunWorkerAsync(a);
                }
                else if (Ordem.SelectedIndex == 2)
                {
                    Preenchimento.Decrescente(vet, 300);
                    bgw.RunWorkerAsync(a);
                }
            }
            else
            {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2025/1 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2025/1 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho]; // Tamanho escolhido pelo usuário
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Bolha(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Bolha",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void seleçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Seleção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void inserçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.Insercao(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Inserção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void shellsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.ShellSort(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Shell",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void heapsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.HeapSort(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Heap",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void quicksortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.quicksort(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Quick",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void mergesortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tamanho = int.Parse(Tamanho.Text);
            int[] vetor = new int[tamanho];
            if (Ordem.SelectedIndex == 0)
            {
                Preenchimento.Aleatorio(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 1)
            {
                Preenchimento.Crescente(vetor, tamanho);
            }
            else if (Ordem.SelectedIndex == 2)
            {
                Preenchimento.Decrescente(vetor, tamanho);
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrdenacaoEstatistica.mergesort(vetor);
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(this,
                  "Tamanho do vetor: " + tamanho.ToString("##,#0") +
                  "\nOrdenação inicial: " + Ordem.Text +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c.ToString("##,#0") +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t.ToString("##,#0"),
                  "Estatísticas do Método Merge",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        //Animação e estatísticas dos métodos de ordenação

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel));
        }

        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Selecao(vet, panel));
        }

        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Insercao(vet, panel));
        }

        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel));
        }

        private void heapsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel));
        }

        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.QuickSort(vet, 0, vet.Length - 1, panel));
        }

        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.MergeSort(vet, 0, vet.Length - 1, panel));
        }
    }
}
