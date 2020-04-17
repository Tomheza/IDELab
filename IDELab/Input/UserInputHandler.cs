using System;
using System.Collections.Generic;
using System.Linq;
using IDELab.Helpers;

namespace IDELab.Input
{
    public class UserInputHandler : IDataInput
    {
        public void InputData()
        {
            var students = new List<Students.Student>();

            while (true)
            {
                // Students loop
                Console.WriteLine("Enter student first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter student last name");
                var lastName = Console.ReadLine();

                if (!(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)))
                {
                    var student = new Students.Student() {FirstName = firstName, LastName = lastName};

                    Console.WriteLine("If you wish to get a random set of results enter 0, otherwise any key.");
                    var homeworkResultTypeInput = Console.ReadLine();

                    if (int.TryParse(homeworkResultTypeInput, out var homeWorkResultType) && homeWorkResultType == 0)
                    {
                        var (homeworkResults, examResult) = GenerateRandomStudentResults.GetRandomStudentResults();

                        student.HomeworkResults.AddRange(homeworkResults);
                        student.ExamResult = examResult;
                    }

                    else
                    {
                        SetUserResultsManually(student);
                    }

                    students.Add(student);
                }

                else
                {
                    Console.WriteLine("You did not input first or last name of the student. Try again.");
                }

                Console.WriteLine("If you want to finish entering results and see the output enter: /");

                if (Console.ReadLine() == "/")
                    break;
            }

            Console.WriteLine("If you want to see results with average homework result enter 0, if median enter 1");
            var outputInput = Console.ReadLine();

            bool useMedian;
            if (int.TryParse(outputInput, out var outputOption) && outputOption == 1)
                useMedian = true;
            else
                useMedian = false;

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine($"{"Last Name",-10}\t{"First Name",-10}\t{"Final (Avg.)",10}");
            Console.WriteLine("-------------------------------------------------------");
            students.OrderBy(x => x.LastName).ToList().ForEach(x => Console.WriteLine(x.GetStudentResultsWithOneResultOutput(useMedian)));
        }


        private static void SetUserResultsManually(Students.Student student)
        {
            while (true)
            {
                // Homework results

                Console.WriteLine("Enter student's homework results. If you wish to stop entering homework results enter: /");
                var homeworkInput = Console.ReadLine();

                if (int.TryParse(homeworkInput, out var homeworkResult) && homeworkResult.ValidResult())
                    student.HomeworkResults.Add(homeworkResult);

                else if (homeworkInput == "/")
                    break;

                else
                    Console.WriteLine("Entered value was in an incorrect format, the result will be ignored.");
            }


            Console.WriteLine("Enter exam result");

            while (true)
            {
                var examInput = Console.ReadLine();

                if (int.TryParse(examInput, out var examResult) && examResult.ValidResult())
                {
                    student.ExamResult = examResult;
                    break;
                }

                Console.WriteLine("Entered exam value was incorrect, try again.");
            }
        }
    }
}