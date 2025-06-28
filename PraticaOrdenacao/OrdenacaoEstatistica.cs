using System.Threading;
using System.Windows.Forms;

namespace Pratica5
{
    class OrdenacaoEstatistica
    {
        public static long cont_c, cont_t;
        public static void Resetar()
        {
            cont_c = cont_t = 0;
        }
        public static void Bolha(int[] vet)
        {
            Resetar();
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                for (j = vet.Length - 1; j > i; j--)
                {
                    cont_c++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        cont_t++;
                    }
                }
            }
        }

        public static void Selecao(int[] vet)
        {
            Resetar();
            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    cont_c++;
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                cont_t++;
            }
        }

        public static void Insercao(int[] vet)
        {
            Resetar();
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                while (j >= 0)
                {
                    cont_c++;
                    if (temp < vet[j])
                    {
                        vet[j + 1] = vet[j];
                        j--;

                    }
                    else break;
                }
                vet[j + 1] = temp;
                cont_t++;
            }
        }

        public static void ShellSort(int[] vet)
        {
            Resetar();
            int i, j, x, n;
            int h = 1;
            n = vet.Length;
            do
            {
                h = h * 3 + 1;
            } while (h <= n);
            do
            {
                h /= 3;
                for (i = h; i < n; i++)
                {
                    x = vet[i];
                    j = i;

                    while (j > (h - 1))
                    {
                        cont_c++;
                        if (vet[j - h] > x)
                        {
                            vet[j] = vet[j - h];
                            j -= h;
                        }
                        else break;
                    }
                    vet[j] = x;
                    cont_t++;
                }
            } while (h != 1);
        }

        public static void quicksort(int[] vet)
        {
            Resetar();
            QuickSort(vet, 0, vet.Length - 1);
        }

        public static void QuickSort(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) { i++; cont_c++; }
                cont_c++;
                while (x < vet[j]) { j--; cont_c++; }
                cont_c++;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                    cont_t++;
                }
            } while (i <= j);
            if (esq < j) QuickSort(vet, esq, j);
            if (i < dir) QuickSort(vet, i, dir);
        }

        public static void HeapSort(int[] v)
        {
            constroiMaxHeap(v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {
                troca(v, i, 0);
                refaz(v, 0, --n);
            }
        }

        private static void constroiMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                refaz(v, i, v.Length);

        }

        private static void refaz(int[] vetor, int pos, int tamanhoDoVetor)
        {

            int max = 2 * pos + 1, right = max + 1;
            cont_c++;
            if (max < tamanhoDoVetor)
            {
                cont_c++;
                if (right < tamanhoDoVetor && vetor[max] < vetor[right])
                    max = right;

                cont_c++;
                if (vetor[max] > vetor[pos])
                {
                    troca(vetor, max, pos);
                    refaz(vetor, max, tamanhoDoVetor);
                }
            }
        }

        public static void troca(int[] v, int j, int aposJ)
        {
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
            cont_t++;
        }

        private static void Merge(int[] v, int i, int m, int j)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
            {
                temp[k - i] = v[k];
            }
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                cont_c++;
                if (temp[esq] <= v[dir])
                {
                    v[i++] = temp[esq++];
                    cont_t++;
                }
                else
                {
                    v[i++] = v[dir++];
                    cont_t++;
                }
            }
            while (esq < k)
                v[i++] = temp[esq++];
        }
        public static void MergeSort(int[] v, int i, int j)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                MergeSort(v, i, m);
                MergeSort(v, m + 1, j);
                Merge(v, i, m, j); // intercala v[i..m] e v[m+1..j] em v[i..j] 
            }
        }

        public static void mergesort(int[] vet)
        {
            Resetar();
            MergeSort(vet, 0, vet.Length - 1);
        }
    }
}
