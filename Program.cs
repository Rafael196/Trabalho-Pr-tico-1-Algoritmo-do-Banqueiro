using System;
using System.Threading;

class Program
{
    const int NUMBER_OF_CUSTOMERS = 5;
    const int NUMBER_OF_RESOURCES = 3;

    static int[] available = new int[NUMBER_OF_RESOURCES];
    static int[,] maximum = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];
    static int[,] allocation = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];
    static int[,] need = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];

    static object mutex = new object();

    //OS VALORES DE avaliable vem dos argumentos do programa
    static void Main(string[] args)
    {
        if(args.Length != NUMBER_OF_RESOURCES)
        {
            System.Console.WriteLine("Uso: programa 10 5 7");
        }

        for(int i = 0; i < NUMBER_OF_RESOURCES; i++)
        {
            available[i] = int.Parse(args[i]);
        }
    }

    static void IniciarMaximum()
    {
        Random rand = new Random();

        for(int i = 0; i < NUMBER_OF_CUSTOMERS;i++)
        {
            for(int j = 0; j < NUMBER_OF_RESOURCES; j++)
            {
                maximum[i,j] = rand.Next(1,available[j] + 1);
                allocation[i,j] = 0;
            }
        }
    }
}