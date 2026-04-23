/* Дано файл, який містить інформацію про аудіо-альбоми у бібліотеці: виконавця,
   назву альбома, рік видання, дату видачі слухачеві, ПІБ слухача. Вивести всіх
   слухачів-боржників, відсортувавши за датою видачі. Вивести всі альбоми,
   які є у бібліотеці за винятком тих, які видано. Вивести 4
   найбільш нові альбоми, які видано за останній тиждень */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Item> albums = new(Item.Init());
            List<Visitor> visitors = new(Visitor.Init());

            Instruments.ShowInStock(albums, visitors);
            Instruments.ShowDebts(visitors);
            Instruments.ShowMostNewGivenAlbums(albums, visitors);        
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
