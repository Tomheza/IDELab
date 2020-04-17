using System;
using System.Collections.Generic;
using System.Linq;

namespace IDELab
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> HomeworkResults { get; } = new List<int>();
        public int ExamResult { get; set; }
        public double AverageHomeworkResult => (double) HomeworkResults.Sum(x => x) / HomeworkResults.Count;
        public double MedianHomeworkResult => GetMedian();

        private double GetMedian()
        {
            if (!HomeworkResults.Any())
                return 0;

            var sortedNumbers = new List<int>(HomeworkResults);
            sortedNumbers.Sort();

            return GetMedianNumber(sortedNumbers);
        }

        private static double GetMedianNumber(IReadOnlyList<int> sortedNumbers)
        {
            var midNumber = sortedNumbers.Count / 2;

            var median = (sortedNumbers.Count % 2 != 0)
                ? sortedNumbers[midNumber]
                : ((double)sortedNumbers[midNumber] + sortedNumbers[midNumber - 1]) / 2;

            return median;
        }

        public void OutputStudentResultsWithOneResult(bool useMedian)
        {
            Console.WriteLine($"{LastName,-10}\t{FirstName,-10}\t{GetFinalResult(useMedian),10:N}");
        }

        public void OutputStudentResults()
        {
            Console.WriteLine($"{LastName,-10}\t{FirstName,-10}\t{GetFinalResult(false),10:N}\t{GetFinalResult(true),10:N}");
        }

        public double GetFinalResult(bool useMedian)
        {
            return 0.7 * ExamResult + 0.3 * (useMedian ? MedianHomeworkResult : AverageHomeworkResult);
        }
    }
}