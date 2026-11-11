using LB_3._2;
using System;

namespace LB_3._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Задание 6. Класс LineSegment ");

            Console.WriteLine("--- Проверка конструкторов ---");
            LineSegment a = new LineSegment(2, 8);
            LineSegment b = new LineSegment(5, 12);
            LineSegment c = new LineSegment();
            LineSegment d = new LineSegment(a);

            Console.WriteLine("a (2, 8):        " + a);
            Console.WriteLine("b (5, 12):       " + b);
            Console.WriteLine("c (по умолч.):   " + c);
            Console.WriteLine("d (копия a):     " + d);

            Console.WriteLine("--- Проверка метода " +
                "IsIntersect ---");
            Console.WriteLine("a пересекает b? " +
                a.IsIntersect(b));
            Console.WriteLine("a пересекает c? " + 
                a.IsIntersect(c));

            Console.WriteLine("\n Задание 7. " +
                "Перегрузка операций");

            Console.WriteLine("--- Унарные операции ---");
            Console.WriteLine("!a (длина диапазона): " + (!a));
            LineSegment expanded = a++;
            Console.WriteLine("a++ (расширение на 1 " +
                "влево/вправо): " + expanded);

            Console.WriteLine("--- Приведение типов ---");
            int xi = a;              
            double yd = (double)a;  
            Console.WriteLine("int(a)    (целая часть x): " + xi);
            Console.WriteLine("(double)a (координата y):   " + yd);

            Console.WriteLine("--- Бинарные операции с целым ---");
            LineSegment left = a - 3;    
            LineSegment right = 3 - a; 
            Console.WriteLine("a - 3 (уменьшение x): " + left);
            Console.WriteLine("3 - a (уменьшение y): " + right);

            Console.WriteLine("--- Операция < ---");
            Console.WriteLine("a < b? " + (a < b));
            Console.WriteLine("a < c? " + (a < c));

            Console.WriteLine("--- Ручной ввод двух отрезков ---");
            LineSegment s1 = ReadLineSegment("Отрезок 1");
            LineSegment s2 = ReadLineSegment("Отрезок 2");

            Console.WriteLine("Введены: " + s1 + " и " + s2);
            Console.WriteLine("Пересекаются? " + (s1 < s2));
            Console.WriteLine("Длина первого: " + (!s1));
            Console.WriteLine("Длина второго: " + (!s2));

            Console.WriteLine();
        }

        private static LineSegment ReadLineSegment(string label)
        {
            double x = ReadDouble(label + ": введите x " +
                "(начало): ");
            double y = ReadDouble(label + ": введите y " +
                "(конец): ");
            return new LineSegment(x, y);
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();
                double value;
                if (double.TryParse(line, out value))
                {
                    return value;
                }
                Console.WriteLine("Некорректное число, " +
                    "повторите.");
            }
        }
        }
}