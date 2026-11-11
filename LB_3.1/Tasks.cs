using System;
using System.Collections.Generic;
using System.IO;

namespace LB_3._1
{
    public static class Tasks
    {
        //1. List
        public static void Task1()
        {
            List<int> l1 = ReadIntList("Введите " +
                "элементы списка L1 (через пробел):");
            List<int> l2 = ReadIntList("Введите " +
                "элементы списка L2 (через пробел):");

            List<int> result = new List<int>();

            for (int i = 0; i < l1.Count; i++)
            {
                int item = l1[i];
                if (l2.Contains(item) && !result.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine("Список L (общие элементы " +
                "без повторов): " + string.Join(" ", result));
        }

        private static List<int> ReadIntList(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Пустая строка, " +
                        "повторите ввод.");
                    continue;
                }

                string[] parts = line.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                List<int> list = new List<int>();
                bool ok = true;
                for (int i = 0; i < parts.Length; i++)
                {
                    int value;
                    if (!int.TryParse(parts[i], out value))
                    {
                        Console.WriteLine("Некорректное " +
                            "число: " + parts[i]);
                        ok = false;
                        break;
                    }
                    list.Add(value);
                }
                if (ok) return list;
            }
        }

        //2. LinkedList
        public static void Task2()
        {
            LinkedList<int> l = ReadLinkedList("Введите " +
                "элементы непустого списка L (через пробел):");

            if (l.Count == 0)
            {
                Console.WriteLine("Список пуст — " +
                    "по условию он непустой.");
                return;
            }

            LinkedListNode<int> node = l.Last;
            while (node != null)
            {
                l.AddLast(node.Value);
                node = node.Previous;
            }

            Console.Write("Результат: ");
            foreach (int item in l)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static LinkedList<int> ReadLinkedList(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Пустая строка, " +
                        "повторите ввод.");
                    continue;
                }
                string[] parts = line.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                LinkedList<int> list = new LinkedList<int>();
                bool ok = true;
                for (int i = 0; i < parts.Length; i++)
                {
                    int value;
                    if (!int.TryParse(parts[i], out value))
                    {
                        Console.WriteLine("Некорректное " +
                            "число: " + parts[i]);
                        ok = false;
                        break;
                    }
                    list.AddLast(value);
                }
                if (ok) return list;
            }
        }

        //3. HashSet
        public static void Task3()
        {
            HashSet<string> allMalls = ReadStringSet
                ("Введите перечень ТРЦ города (через пробел):");

            Console.Write("Введите количество студентов: ");
            int n = ReadPositiveInt();

            HashSet<string>[] visits =
                new HashSet<string>[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Студент " + (i + 1) + ", " +
                    "введите ТРЦ, которые он посещал " +
                    "(через пробел, пусто = Enter):");
                string line = Console.ReadLine();

                HashSet<string> studentMalls =
                    new HashSet<string>();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < parts.Length; j++)
                    {
                        studentMalls.Add(parts[j]);
                    }
                }
                visits[i] = studentMalls;
            }

            HashSet<string> allVisited = new HashSet<string>(allMalls);
            for (int i = 0; i < visits.Length; i++)
            {
                allVisited.IntersectWith(visits[i]);
            }

            HashSet<string> someVisited = new HashSet<string>();
            for (int i = 0; i < visits.Length; i++)
            {
                someVisited.UnionWith(visits[i]);
            }

            HashSet<string> nobodyVisited = new HashSet<string>(allMalls);
            nobodyVisited.ExceptWith(someVisited);

            Console.WriteLine("Ходили все студенты: "
                + FormatSet(allVisited));
            Console.WriteLine("Ходили некоторые студенты: "
                + FormatSet(someVisited));
            Console.WriteLine("Не ходил никто: "
                + FormatSet(nobodyVisited));
        }

        private static string FormatSet(HashSet<string> set)
        {
            if (set.Count == 0) return "(нет)";
            return string.Join(", ", set);
        }

        private static HashSet<string> ReadStringSet(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Пустая строка, " +
                        "повторите ввод.");
                    continue;
                }
                string[] parts = line.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> set = new HashSet<string>();
                for (int i = 0; i < parts.Length; i++)
                {
                    set.Add(parts[i]);
                }
                return set;
            }
        }

        // 4. HashSet
        public static void Task4()
        {
            Console.WriteLine("Введите текст на русском языке:");
            string text = Console.ReadLine();

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Текст пуст.");
                return;
            }

            HashSet<char> letters = new HashSet<char>();
            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);
                if (char.IsLetter(c))
                {
                    letters.Add(c);
                }
            }

            Console.WriteLine("Количество разных букв " +
                "в тексте: " + letters.Count);
            Console.Write("Это буквы: ");
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        // 5. Dictionary
        public static void Task5()
        {
            string path = "sportsmen.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден, " +
                    "создаём тестовый...");
                FillSportsmenFile(path);
            }

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
            {
                Console.WriteLine("Файл некорректен.");
                return;
            }

            int n, m;
            if (!int.TryParse(lines[0].Trim(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка: N в первой строке.");
                return;
            }
            if (!int.TryParse(lines[1].Trim(), out m) || m <= 0)
            {
                Console.WriteLine("Ошибка: M во второй строке.");
                return;
            }
            if (lines.Length < 2 + n)
            {
                Console.WriteLine("Недостаточно строк в файле.");
                return;
            }

            Dictionary<string, int> sums = 
                new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string line = lines[2 + i].Trim();
                string[] parts = line.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2 + m)
                {
                    Console.WriteLine("Ошибка формата " +
                        "в строке: " + line);
                    return;
                }

                string fullName = parts[0] + " " + parts[1];
                int sum = 0;
                bool ok = true;
                for (int j = 0; j < m; j++)
                {
                    int value;
                    if (!int.TryParse(parts[2 + j], out value))
                    {
                        Console.WriteLine("Ошибка числа " +
                            "в строке: " + line);
                        ok = false;
                        break;
                    }
                    sum += value;
                }
                if (!ok) return;

                if (sums.ContainsKey(fullName))
                {
                    sums[fullName] += sum;
                }
                else
                {
                    sums.Add(fullName, sum);
                }
            }

            string[] names = new string[sums.Count];
            int[] totalSums = new int[sums.Count];
            int idx = 0;
            foreach (KeyValuePair<string, int> pair in sums)
            {
                names[idx] = pair.Key;
                totalSums[idx] = pair.Value;
                idx++;
            }

            for (int i = 0; i < totalSums.Length - 1; i++)
            {
                for (int j = 0; j < totalSums.Length 
                    - 1 - i; j++)
                {
                    if (totalSums[j] < totalSums[j + 1])
                    {
                        int tmpSum = totalSums[j];
                        totalSums[j] = totalSums[j + 1];
                        totalSums[j + 1] = tmpSum;

                        string tmpName = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tmpName;
                    }
                }
            }

            Console.WriteLine("Результирующая таблица:");

            int currentPlace = 1;

            for (int i = 0; i < names.Length; i++)
            {
                if (i > 0 && totalSums[i] != totalSums[i - 1])
                {
                    currentPlace++;
                }

                Console.WriteLine(names[i] + " " 
                    + totalSums[i] + " " + currentPlace);
            }
        }

        public static void FillSportsmenFile(string path)
        {
            string[] data =
            {
                "3",
                "4",
                "Иванов Сергей 100 30 78 13",
                "Петров Антон 90 16 98 14",
                "Сидоров Юрий 100 70 30 21"
            };
            File.WriteAllLines(path, data);
            Console.WriteLine("Файл " + path + " создан.");
        }

        private static int ReadPositiveInt()
        {
            while (true)
            {
                string line = Console.ReadLine();
                int value;
                if (int.TryParse(line, out value) && value > 0)
                {
                    return value;
                }
                Console.Write("Нужно положительное " +
                    "целое число, повторите: ");
            }
        }
    }
}