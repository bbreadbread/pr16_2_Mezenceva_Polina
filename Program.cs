using System;
using System.IO;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\nВведите имя файла для чтения(num): ");
                    string name = Console.ReadLine();

                    if (File.Exists($"{name}.txt"))
                    {
                        string[] numFile = File.ReadAllText("num.txt").Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                        double[] numWork = numFile.Select(double.Parse).ToArray();
                        
                        var ch = numWork.GroupBy(a => a)
                            .Select(b => new { number = b.Key, freq = b.Count() });
                        Console.WriteLine("Число\tЧастота");

                        foreach (var bb in ch) { Console.WriteLine($"{bb.number}\t{bb.freq}"); }

                        var newNumArray = numWork.Select(a => a * ch.First(b => b.number == a).freq).ToArray();
                        var ch2 = newNumArray.GroupBy(a => a)
                           .Select(b => new { number = b.Key, freq = b.Count() });
                        File.WriteAllLines("newNum.txt", ch2.Select(n => n.ToString()));

                        Console.WriteLine("\nЧисло\tЧастота(Старого массива)");
                        foreach (var bbNew in ch2) { Console.WriteLine($"{bbNew.number}\t{bbNew.freq}"); }
                        Console.ReadKey();
                        break;
                    }
                    else Console.WriteLine("Файл не найден");
                }
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
        }
    }
}
