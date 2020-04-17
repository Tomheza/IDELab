using System;
using System.Collections.Generic;

namespace IDELab.Helpers
{
    public static class GenerateRandomStudentResults
    {
        public static Tuple<List<int>, int> GetRandomStudentResults()
        {
            var rnd = new Random();
            var resultCount = rnd.Next(1, 11);
            var homeWorkResults = new List<int>();

            for (var i = 0; i < resultCount; i++)
            {
                var randomGeneratedNumber = rnd.Next(1, 11);
                homeWorkResults.Add(randomGeneratedNumber);
            }
            //Console.Write("Random generated homework results: ");
            //homeWorkResults.ForEach(x => Console.Write(x + " "));

            var randomExamResult = rnd.Next(1, 11);
            //Console.WriteLine("\nRandom generated exam result: " + randomExamResult);
            var examResult = randomExamResult;

            return new Tuple<List<int>, int>(homeWorkResults, examResult);
        }
    }
}
