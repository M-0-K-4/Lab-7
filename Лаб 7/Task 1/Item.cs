using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    internal class Item
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }

        public static List<Item> Init()
        {
            using StreamReader sr = new StreamReader(@"E:\КНУ\1 курс\2 семестр\Об’єкт-орієнт програмування\Лабораторні роботи\Лабораторна 7\Tasks\Lab-7\Лаб 7\Task 1\Albums.json");
            using JsonTextReader reader = new(sr);
            JsonSerializer serializer = new();
            List<Item> albums = serializer.Deserialize<List<Item>>(reader)!;
            return albums;
        }

        public static void Print(List<Item> albums)
        {
            foreach (var unit in albums)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{Artist} – {Album}, {Year}";
        }
    }
}
