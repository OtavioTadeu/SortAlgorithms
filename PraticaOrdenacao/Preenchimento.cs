using System;

namespace Pratica5
{
    class Preenchimento
    {
        public static void Aleatorio(int[] vet, int limite)
        {
            Random r = new Random();
            for (int i = 0; i < vet.Length; i++)
            {
                vet[i] = r.Next(0, limite);
            }
        }
        public static void Crescente(int[] vet, int limite)
        {

            double passo = (double)limite / vet.Length;

            for (int i = 0; i < vet.Length; i++)
            {
                vet[i] = (int)(i * passo);
            }
        }
        public static void Decrescente(int[] vet, int limite)
        {
            double passo = (double)limite / vet.Length;

            for (int i = 0; i < vet.Length; i++)
            {
                vet[i] = (int)(limite - i * passo);
            }
        }
    }
}
