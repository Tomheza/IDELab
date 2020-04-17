using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IDELab.Helpers;
using IDELab.Students;

namespace IDELab
{
    public static class RandomStudentListGenerator
    {
        public static void Generate()
        {
            Console.Write("\n\n\n");
            Generate(1000);
            Generate(10000);
            Generate(100000);
            Generate(1000000);
            Generate(10000000);
        }

        private static void Generate(int studentCount)
        {
            var students = new List<Student>();
            var stopwatch = new Stopwatch();

            Console.WriteLine($"Generating {studentCount} student list");
            stopwatch.Start();
            var filePath = Settings.GetRandomStudentListFile(studentCount);
            var goodStudentFilePath = Settings.GetRandomStudentListFileForStudentType(studentCount, true);
            var badStudentFilePath = Settings.GetRandomStudentListFileForStudentType(studentCount, false);

            Console.WriteLine($"File path: {filePath}");

            if (File.Exists(goodStudentFilePath))
                File.Delete(goodStudentFilePath);

            if (File.Exists(badStudentFilePath))
                File.Delete(badStudentFilePath);

            if (File.Exists(filePath))
                File.Delete(filePath);

            for (var i = 1; i <= studentCount; i++)
            {
                var student = new Student()
                {
                    FirstName = $"Vardas{i}",
                    LastName = $"Pavarde{i}",
                };

                var (homeworkResults, examResult) = GenerateRandomStudentResults.GetRandomStudentResults();

                student.ExamResult = examResult;
                student.HomeworkResults.AddRange(homeworkResults);

                students.Add(student);
            }

            stopwatch.Stop();

            Console.WriteLine($"Finished generating {studentCount} student list");

            Console.WriteLine($"To generate {studentCount} student file took: {stopwatch.ElapsedMilliseconds} ms or {TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds)}");

            using var studentSr = new StreamWriter(filePath);
            using var goodStudentSr = new StreamWriter(goodStudentFilePath);
            using var badStudentSr = new StreamWriter(badStudentFilePath);

            stopwatch.Start();

            foreach (var student in students.OrderBy(x => x.LastName))
            {
                var studentResultOutput = student.GetStudentResultsOutput();
                studentSr.WriteLine(studentResultOutput);

                if (student.StudentType == StudentType.Good)
                    goodStudentSr.WriteLine(studentResultOutput);
                else
                    badStudentSr.WriteLine(studentResultOutput);
            }

            stopwatch.Stop();
            Console.WriteLine($"To write student information to the files took: {stopwatch.ElapsedMilliseconds}ms or {TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds)}");
            Console.Write("\n\n\n\n");
        }
    }
}