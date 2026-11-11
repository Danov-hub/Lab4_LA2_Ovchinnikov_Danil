using LB_3._1;
using System;

namespace LB_3._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. List ");
            Tasks.Task1();

            Console.WriteLine("\n Задание 2. LinkedList ");
            Tasks.Task2();

            Console.WriteLine("\n Задание 3. HashSet (ТРЦ)");
            Tasks.Task3();

            Console.WriteLine("\n Задание 4. HashSet (буквы)");
            Tasks.Task4();

            Console.WriteLine("\n Задание 5. " +
                "Dictionary (многоборье) ");
            Tasks.Task5();

        }
    }
}