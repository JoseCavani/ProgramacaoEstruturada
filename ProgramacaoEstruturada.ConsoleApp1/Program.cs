using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramacaoEstruturada.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //opção = 0
            entradaDeNumero(out int[] numeros, out int media);
            while (true)
            {
                // retorno = operação(input);


                // opção =  digitarOpcao();
                digitarOpcao(out int opção);


                switch (opção)
                {
                    case 0:
                        mostraNumeros(numeros);
                        continue;
                    case 1:
                        menoresNumeros(numeros, out int menor);
                        Console.WriteLine($"o menor numero e: {menor}");
                        continue;
                    case 2:
                        maioresNumeros(ref numeros);
                        continue;
                    case 3:
                        acharMedia(media);
                        continue;
                    case 4:
                        numerosNegativos(numeros);
                        continue;
                    case 5:
                        retirarNumero(numeros);
                        continue;
                    case 6:
                        goto fim;
                }
            }
        fim:;
        }
        static void digitarOpcao(out int opção)
        {
        digiteDeNovo:
            DigiteUmNumero("selecione opção 0 = mostrar numeros\n  1 = menor numero \n2 = maiores numeros \n" +
                "3 = achar a media\n" +
                "4 = numeros negativos\n" +
                "5 = retirar numero\n" +
                "6 = sair\n", out bool naoENumero, out opção);
            if (naoENumero || opção > 6 || opção < 0)
            {
                mensagemErro();
                goto digiteDeNovo;
            }
        }
        static void retirarNumero(int[] numeros)
        {
            int z = 0;
            int[] numeros2 = new int[9];
            int quantidadeNumerosParaRetirar = 0;
            int lugar = 0;
        digiteDeNovo:
            DigiteUmNumero("digite um numero", out bool naoENumero, out int numeroRetirar);
            if (naoENumero)
            {
                mensagemErro();
                goto digiteDeNovo;
            }



            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeroRetirar == numeros[i])
                {
                    quantidadeNumerosParaRetirar++;
                }
            }


            if (quantidadeNumerosParaRetirar > 1)
            {
                int[] numerosParaRetirar = new int[quantidadeNumerosParaRetirar];

                int j = 0;
                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeroRetirar == numeros[i])
                    {
                        numerosParaRetirar[j] = i;
                        j++;
                    }
                }

                Console.Write("o numero digitado esta nas posições: ");

                foreach (var item in numerosParaRetirar)
                {
                    Console.Write(item + "/");
                }
                volta:
                Console.WriteLine("qual deseja remover?");
                if (!(int.TryParse(Console.ReadLine(), out lugar)))
                    Console.WriteLine("erro");
                goto volta;
            }
            else
            {
                lugar = numeroRetirar;
            }

 
            for (int i = 0; i < numeros.Length; i++)
            {
                if (i != lugar)
                {
                    numeros2[z] = numeros[i];
                    z++;
                }
            }
            numeros = numeros2;
            mostraNumeros(numeros);

        }
        static void numerosNegativos(int[] numeros)
        {
            Console.Write($"os numeros negativos são: \n");
            foreach (var numero in numeros)
            {
                if (numero < 0)
                    Console.Write($"{numero}/");

            }
            Console.WriteLine();
        }
        static void acharMedia(int media)
        {
            media = media / 10;
            Console.WriteLine($"media e : {media}");
        }
        static void menoresNumeros(int[] numeros,out int menor)
        {
            Array.Sort(numeros);
            menor = numeros[0];
        }
        static void maioresNumeros(ref int[] numeros)
        {
            Array.Sort(numeros);
            Console.WriteLine($"o maior numero e: {numeros[9]}\n " +
                $"os outros 2 maiores sao: {numeros[8]} e {numeros[7]}");
            
        }
        static void mostraNumeros(int[] numeros)
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
