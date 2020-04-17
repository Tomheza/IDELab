using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IDELab.Input
{
    public class FileInputHandler : IDataInput
    {
        public void InputData()
        {
            var path = "Data\\Studentai.txt";
            var combinedString = Path.Combine(Directory.GetCurrentDirectory(), path);


            if (!File.Exists(combinedString))
                return;

            using var streamReader = new StreamReader(combinedString);
            string studentInput;
            var dataStructureLine = true;

            var students = new List<Student>();

            while ((studentInput = streamReader.ReadLine()) != null)
            {
                var studentData = studentInput.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (!studentData.Any())
                    continue;

                if (dataStructureLine)
                {
                    dataStructureLine = false;
                    continue;
                }

                var student = new Student()
                {
                    FirstName = studentData[0],
                    LastName = studentData[1]
                };
                
                for (var i = 2; i < studentData.Length - 1; i++)
                {
                    if (int.TryParse(studentData[i], out var result) && result.ValidResult())
                        student.HomeworkResults.Add(result);
                }

                if (int.TryParse(studentData[^1], out var examResult) && examResult.ValidResult())
                    student.ExamResult = examResult;

                students.Add(student);
            }


            Console.WriteLine("\n\n\n\n");
            Console.WriteLine($"{"Last Name",-10}\t{"First Name",-10}\t{"Final (Avg.)",10}\t{"Final (Med.)",10}");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            students.ForEach(x => x.OutputStudentResults());
        }
    }
}