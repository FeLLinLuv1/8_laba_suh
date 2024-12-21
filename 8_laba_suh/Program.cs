using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_laba_suh
{

    /*  public class PerformanceTest
      {
          public void RunTest()
          {
              var stopwatch = System.Diagnostics.Stopwatch.StartNew();

              var numbers = Enumerable.Range(1, 1000000).ToList();
              var evenNumbers = new List<int>();

              foreach (var number in numbers)
              {
                  if (number % 2 == 0)
                  {
                      evenNumbers.Add(number);
                  }
              }

              Console.WriteLine($"Total even numbers: {evenNumbers.Count}");
              stopwatch.Stop();
              Console.WriteLine($"Total even numbers: {evenNumbers.Count}");
              Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
              Console.ReadLine();
          }
      }
      static void Main(string[] args)
      {

          PerformanceTest test = new PerformanceTest();
          test.RunTest();

      }*/

    public class NumberProcessor
    {
        public void ProcessNumbers(string inputFilePath, string outputFilePath)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine("Input file does not exist.");
                    return;
                }

                // Чтение чисел, обработка, сортировка и удаление дубликатов
                var numbers = File.ReadLines(inputFilePath) // Используем ReadLines для работы с большими файлами
                                  .Select(line => int.TryParse(line, out int num) ? (int?)num : null)
                                  .Where(num => num.HasValue)
                                  .Select(num => num.Value)
                                  .Distinct()
                                  .OrderBy(n => n)
                                  .ToList();

                // Сохранение результата
                File.WriteAllLines(outputFilePath, numbers.Select(n => n.ToString()));
                Console.WriteLine("Processing complete. Results saved to " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                string inputFilePath = "input.txt";
                string outputFilePath = "output.txt";

                NumberProcessor processor = new NumberProcessor();
                processor.ProcessNumbers(inputFilePath, outputFilePath);
                Console.ReadLine();

            }
        }

    }
}
