using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IDELab.Students;

namespace IDELab.Input
{
    public class ThirdFileInputStrategy : IDataInput
    {
        private List<Student> students = new List<Student>();
        private LinkedList<Student> linkedStudents = new LinkedList<Student>();
        private Queue<Student> queueStudents = new Queue<Student>();

        private Stopwatch stopwatch = new Stopwatch();

        public void InputData()
        {
            if (!File.Exists(Settings.ReadFile))
                return;

            InputToQueue();
            InputToLinkedList();
            InputToList();
        }

        private void InputToList()
        {
            stopwatch.Reset();
            stopwatch.Start();

            DeleteFiles();
            ReadFromFile(CollectionType.List);
            OutputStudents(CollectionType.List);

            stopwatch.Stop();
            Debug.WriteLine($"It took {stopwatch.ElapsedMilliseconds}ms to read from file and output data with list");
        }

        private void InputToQueue()
        {
            stopwatch.Reset();
            stopwatch.Start();

            DeleteFiles();
            ReadFromFile(CollectionType.Queue);
            OutputStudents(CollectionType.Queue);

            stopwatch.Stop();
            Debug.WriteLine($"It took {stopwatch.ElapsedMilliseconds}ms to read from file and output data with queue");
        }

        private void InputToLinkedList()
        {
            stopwatch.Reset();
            stopwatch.Start();

            DeleteFiles();
            ReadFromFile(CollectionType.LinkedList);
            OutputStudents(CollectionType.LinkedList);

            stopwatch.Stop();
            Debug.WriteLine($"It took {stopwatch.ElapsedMilliseconds}ms to read from file and output data with linked list");
        }

        private void ReadFromFile(CollectionType collectionType)
        {
            using var streamReader = new StreamReader(Settings.ReadFile);
            string studentInput;
            var dataStructureLine = true;

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

                var student = new Student
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

                AddToCollection(student, collectionType);
            }
        }

        private void AddToCollection(Student student, CollectionType collectionType)
        {
            switch (collectionType)
            {
                case CollectionType.List:
                {
                    students.Add(student);
                    break;
                }
                case CollectionType.Queue:
                {
                    queueStudents.Enqueue(student);
                    break;
                }
                case CollectionType.LinkedList:
                {
                    linkedStudents.AddLast(student);
                    break;
                }
            }
        }

        private void OutputStudents(CollectionType collectionType)
        {
            switch (collectionType)
            {
                case CollectionType.List:
                    OutputListStudents();
                    break;

                case CollectionType.Queue:
                    OutputQueueStudents();
                    break;

                case CollectionType.LinkedList:
                    OutputLinkedListStudents();
                    break;
            }
        }

        private void OutputListStudents()
        {
            using var studentSr = new StreamWriter(Settings.AllStudentWriteFile);
            using var goodStudentSr = new StreamWriter(Settings.GoodStudentWriteFile);
            using var badStudentSr = new StreamWriter(Settings.BadStudentWriteFile);

            students = students.OrderBy(x => x.LastName).ToList();

            foreach (var student in students)
            {
                if (student.StudentType == StudentType.Good)
                    goodStudentSr.WriteLine(student.GetStudentResultsOutput());
                else
                    badStudentSr.WriteLine(student.GetStudentResultsOutput());
            }
        }

        private void OutputQueueStudents()
        {
            using var studentSr = new StreamWriter(Settings.AllStudentWriteFile);
            using var goodStudentSr = new StreamWriter(Settings.GoodStudentWriteFile);
            using var badStudentSr = new StreamWriter(Settings.BadStudentWriteFile);

            queueStudents = new Queue<Student>(queueStudents.OrderBy(x => x.LastName));

            foreach (var student in queueStudents)
            {
                if (student.StudentType == StudentType.Good)
                    goodStudentSr.WriteLine(student.GetStudentResultsOutput());
                else
                    badStudentSr.WriteLine(student.GetStudentResultsOutput());
            }
        }

        private void OutputLinkedListStudents()
        {
            using var studentSr = new StreamWriter(Settings.AllStudentWriteFile);
            using var goodStudentSr = new StreamWriter(Settings.GoodStudentWriteFile);
            using var badStudentSr = new StreamWriter(Settings.BadStudentWriteFile);

            linkedStudents = new LinkedList<Student>(queueStudents.OrderBy(x => x.LastName));

            foreach (var student in linkedStudents)
            {
                if (student.StudentType == StudentType.Good)
                    goodStudentSr.WriteLine(student.GetStudentResultsOutput());
                else
                    badStudentSr.WriteLine(student.GetStudentResultsOutput());
            }
        }

        private static void DeleteFiles()
        {
            if (File.Exists(Settings.AllStudentWriteFile))
                File.Delete(Settings.AllStudentWriteFile);

            if (File.Exists(Settings.BadStudentWriteFile))
                File.Delete(Settings.BadStudentWriteFile);

            if (File.Exists(Settings.GoodStudentWriteFile))
                File.Delete(Settings.GoodStudentWriteFile);
        }
    }
}