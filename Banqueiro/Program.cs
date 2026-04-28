using System;
using System.Globalization;
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

    static void Main(string[] args)
    {
        if (args.Length != NUMBER_OF_RESOURCES)
        {
            System.Console.WriteLine("Uso: programa 10 5 7");
        }

        for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
        {
            available[i] = int.Parse(args[i]);
        }

        IniciarMaximum();
        CalcularNeed();
        CriarThreads();

        Thread.Sleep(Timeout.Infinite);
    }

    static void IniciarMaximum()
    {
        Random rand = new Random();

        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
            {
                maximum[i, j] = rand.Next(1, available[j] + 1);
                allocation[i, j] = 0;
            }
        }
    }

    static void CalcularNeed()
    {
        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
            {
                need[i, j] = maximum[i, j] - allocation[i, j];
            }
        }
    }

    static int request_resources(int customer, int[] request)
    {
        lock (mutex)
        {
            Console.WriteLine($"Cliente {customer} pediu: {string.Join(",", request)}");

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
                if (request[i] > need[customer, i]) return -1;

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
                if (request[i] > available[i]) return -1;

            // simulação
            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                available[i] -= request[i];
                allocation[customer, i] += request[i];
                need[customer, i] -= request[i];
            }

            if (!isSafe())
            {
                for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
                {
                    available[i] += request[i];
                    allocation[customer, i] -= request[i];
                    need[customer, i] += request[i];
                }

                return -1;
            }
            return 0;
        }
    }

    static int release_resources(int customer, int[] release)
    {
        lock (mutex)
        {
            Console.WriteLine($"Cliente {customer} liberou: {string.Join(",", release)}");

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                if (release[i] > allocation[customer, i])
                    return -1;

                available[i] += release[i];
                allocation[customer, i] -= release[i];
                need[customer, i] += release[i];
            }

            return 0;
        }
    }

    static void Cliente(int id)
    {
        Console.WriteLine($"Cliente {id} iniciou");

        Random rand = new Random();

        while (true)
        {
            int[] request = new int[NUMBER_OF_RESOURCES];

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                request[i] = rand.Next(0, need[id, i] + 1);
            }

            request_resources(id, request);

            Thread.Sleep(1000);

            int[] release = new int[NUMBER_OF_RESOURCES];

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                release[i] = rand.Next(0, allocation[id, i] + 1);
            }

            release_resources(id, release);

            Thread.Sleep(1000);
        }
    }

    static void CriarThreads()
    {
        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            int id = i;
            Thread t = new Thread(() => Cliente(id));
            t.Start();
        }
    }

    static bool isSafe()
    {
        int[] work = (int[])available.Clone();
        bool[] finish = new bool[NUMBER_OF_CUSTOMERS];

        bool mudou;

        do
        {
            mudou = false;

            for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
            {
                if (!finish[i])
                {
                    bool pode = true;

                    for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
                    {
                        if (need[i, j] > work[j])
                        {
                            pode = false;
                            break;
                        }
                    }

                    if (pode)
                    {
                        for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
                            work[j] += allocation[i, j];

                        finish[i] = true;
                        mudou = true;
                    }
                }
            }

        } while (mudou);

        foreach (bool f in finish)
            if (!f) return false;

        return true;
    }
}