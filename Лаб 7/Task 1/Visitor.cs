using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Task_1
{
    internal class Visitor
    {
        public string Name { get; set; }
        public string Album { get; set; }
        public DateTime IssueDate { get; set; }

        [JsonConstructor]
        public Visitor(string name, string album, string issuedate)
        {
            Name = name;
            Album = album;
            IssueDate = DateTime.Parse(issuedate);
        }


        public static List<Visitor> Init()
        {
            using StreamReader sr = new StreamReader(@"E:\КНУ\1 курс\2 семестр\Об’єкт-орієнт програмування\Лабораторні роботи\Лабораторна 7\Tasks\Lab-7\Лаб 7\Task 1\Visitors.json");
            using JsonTextReader reader = new(sr);
            JsonSerializer serializer = new();
            List<Visitor> visitors = serializer.Deserialize<List<Visitor>>(reader)!;
            return visitors;
        }

        public static void Print(List<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                Console.WriteLine(visitor);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{IssueDate}\n{Name} – {Album}";
        }
    }
}
