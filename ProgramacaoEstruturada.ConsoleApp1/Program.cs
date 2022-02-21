using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramacaoEstruturada.ConsoleApp1
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            entradaDeNumero(out int[] numeros,out int media);
            mostraNumeros(numeros);
            Array.Sort(numeros);
            menoresNumeros(numeros, out int menor);// menor agora esta atribuido aqui tambem
            Console.WriteLine($"o menor numero e: {menor}");
            maioresNumeros(ref numeros);
            acharMedia(media);
            numerosNegativos(numeros);
            retirarNumero(numeros);
            Console.ReadKey();
        }
        private static void retirarNumero(int[] numeros)
        {
            List<int> numerosList = numeros.ToList();
        digiteDeNovo:
            DigiteUmNumero("digite um numero", out bool naoENumero, out int numero);
            if (naoENumero)
            {
                mensagemErro();
                goto digiteDeNovo;
            }
            numerosList.Remove(numero);
            numeros = numerosList.ToArray(); // retirar essa linha se nao for necessario entregar essa atividade como um array

            foreach (var numeroEmNumeros in numeros)
            {
                Console.Write(numeroEmNumeros + "/");
            }

        }
        private static void numerosNegativos(int[] numeros)
        {
            Console.Write($"os numeros negativos são: \n");
            foreach (var numero in numeros)
            {
                if (numero < 0)
                    Console.Write($"{numero}/");

            }
            Console.WriteLine();
        }
        private static void acharMedia(int media)
        {
            media = media / 10;
            Console.WriteLine($"media e : {media}");
        }
        private static void menoresNumeros(int[] numeros,out int menor)
        {
            menor = numeros[0];
        }
        private static void maioresNumeros(ref int[] numeros)
        {
            Console.WriteLine($"o maior numero e: {numeros[9]}\n " +
                $"os outros 2 maiores sao: {numeros[8]} e {numeros[7]}");
            
        }
        private static void mostraNumeros(int[] numeros)
        {
            foreach (var numero in numeros)
            {
             Console.Write($"{numero}/");
            }
            Console.WriteLine();
        }
        static void mensagemErro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("valor invalido");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        static void DigiteUmNumero(string mensagen, out bool naoENumero, out int numero)
        {
            Console.WriteLine(mensagen);
            if ((!(int.TryParse(Console.ReadLine(), out numero))))
                naoENumero = true;
            else
                naoENumero = false;
        }
        static void entradaDeNumero(out int[] numeros, out int media)
        {
            numeros = new int[10];
            media = 0;
            for (int i = 0; i < 10; i++)
            {
            digiteDeNovo:
                DigiteUmNumero("digite um numero", out bool naoENumero, out int numero);
                if (naoENumero)
                {
                    mensagemErro();
                    goto digiteDeNovo;
                }
                numeros[i] = numero;
                media += numeros[i];
            }
        }

    }
}
