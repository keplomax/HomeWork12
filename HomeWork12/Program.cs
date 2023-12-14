using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork12
{
    internal class Program
    {
        private static bool chek;

        static void CountNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(1000);
            }
        }
        static int CalculateFactorial(int number)
        {
            int result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            Console.WriteLine("Ожидайте 8 сек.");
            Thread.Sleep(8000);

            return result;
        }
        static int CalculateSquare(int number)
        {
            return number * number;
        }
        static void Main(string[] args)
        {
            // HT 1
            Thread thread1 = new Thread(CountNumbers);
            Thread thread2 = new Thread(CountNumbers);
            Thread thread3 = new Thread(CountNumbers);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            // HT 2
            int number;
            do
            {
                Console.Write("Введите число: ");
                chek = int.TryParse(Console.ReadLine(), out number);
            } while (!chek);


            int square = CalculateSquare(number);
            Console.WriteLine($"Квадрат числа {number} равен {square}");

            Task<int> factorialTask = Task.Run(() => CalculateFactorial(number));
            Console.WriteLine($"Факториал числа {number} равен {factorialTask.Result}");

        }


    }
}
