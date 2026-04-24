using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    internal class Instruments
    {
        public static void ShowInStock(List<Item> albums, List<Visitor> visitors)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\tIn stock:");
            var missing = visitors.Select(v => v.Album);
            var grouped = albums
                .Where(match => !missing.Contains(match.Album))
                .GroupBy(a => a.Artist)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Artist = group.Key,
                    Units = group.OrderByDescending(unit => unit.Year)
                });
            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Artist}:");
                foreach (var unit in group.Units)
                {
                    Console.WriteLine($"{unit.Year} – {unit.Album}");
                }
                Console.WriteLine();
            }
        }

        public static void ShowDebts(List<Visitor> visitors)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tDebters:");
            var debters = visitors.Where(v => v.IssueDate !< DateTime.Now.AddMonths(-1)).OrderByDescending(v => v.IssueDate);
            foreach (var debter in debters)
            {
                TimeSpan debtcross = DateTime.Now.AddMonths(-1) - debter.IssueDate;
                Console.WriteLine($"{debter.Name} – {debter.Album} | {debtcross.Days} day(s) overdue");
            }
            Console.WriteLine();
        }

        public static void ShowMostNewGivenAlbums(List<Item> albums, List<Visitor> visitors)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tThe most new given Albums:");
            var weekspan = visitors
                .Where(v => v.IssueDate > DateTime.Now.AddDays(-7))
                .Select(v => v.Album)
                .Distinct();
            var mostnew = albums
                .Where(match => weekspan.Contains(match.Album))
                .OrderByDescending(a => a.Year)
                .ToList();
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    Console.WriteLine($"{mostnew[i].Album} / {mostnew[i].Year}");
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
