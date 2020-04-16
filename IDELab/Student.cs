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
        public int[] HomeworkResultsInArray { get; set; }
        public int ExamResult { get; set; }
        public double AverageHomeworkResult => (double) HomeworkResults.Sum(x => x) / HomeworkResults.Count;
        public double MedianHomeworkResult => GetMedian();
        public double MedianHomeworkResultArray => GetMedianFromArray();
        public double AverageHomeworkResultArray => (double) HomeworkResultsInArray.Sum(x => x) / HomeworkResultsInArray.Length;

        private double GetMedian()
        {
            if (!HomeworkResults.Any())
                return 0;

            var sortedNumbers = new List<int>(HomeworkResults);
            sortedNumbers.Sort();

            return GetMedianNumber(sortedNumbers);
        }

        private double GetMedianFromArray()
        {
            if (!HomeworkResultsInArray.Any())
                return 0;

            var clonedArray = new int[HomeworkResultsInArray.Length];
            Array.Copy(HomeworkResultsInArray, clonedArray, HomeworkResultsInArray.Length);
            Array.Sort(HomeworkResultsInArray);

            return GetMedianNumber(HomeworkResultsInArray);
        }

        private static double GetMedianNumber(IReadOnlyList<int> sortedNumbers)
        {
            var midNumber = sortedNumbers.Count / 2;

            var median = (sortedNumbers.Count % 2 != 0)
                ? sortedNumbers[midNumber]
                : ((double)sortedNumbers[midNumber] + sortedNumbers[midNumber - 1]) / 2;

            return median;
        }

        public void OutputStudentResults(bool useMedian)
        {
            Console.WriteLine($"{LastName,-10}\t{FirstName,-10}\t{GetFinalResult(useMedian),10:N}");
        }

        public double GetFinalResult(bool useMedian)
        {
            return 0.7 * ExamResult + 0.3 * (useMedian ? MedianHomeworkResult : AverageHomeworkResult);
        }
    }
}