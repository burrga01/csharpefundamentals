using System;
using System.Threading;

namespace GradeBook
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public int Count;
        public double Sum;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
        }
        public void Add(double number)
        {
            Sum += number;
            Count++;
            High = Math.Max(High, number);
            Low = Math.Min(Low, number);

        }
    }
}