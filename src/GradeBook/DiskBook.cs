using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            string line;

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                while((line = reader.ReadLine()) != null)
                {
                    stats.Add(double.Parse(line));
                }
            }
            return stats;
        }
    }
}