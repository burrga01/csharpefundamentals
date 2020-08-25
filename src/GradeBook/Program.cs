using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Graham's GradeBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"The average grade is: {stats.Average:N1}");
            Console.WriteLine($"The high grade is: {stats.High:N1}");
            Console.WriteLine($"The low grade is: {stats.Low:N1}");
            Console.WriteLine($"The Letter is: {stats.Letter}");

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added");
            }

            //     if(args.Length > 0 ){
            //         Console.WriteLine($"Hello, {args[0]}!");
            //     }else{
            //         Console.WriteLine("Hello!");
            //     }            
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
