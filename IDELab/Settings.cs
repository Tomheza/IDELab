using System.IO;

namespace IDELab
{
    public static class Settings
    {
        public static string ReadFile => Path.Combine(Directory.GetCurrentDirectory(), "Data\\Studentai.txt");
        public static string GoodStudentWriteFile => Path.Combine(Directory.GetCurrentDirectory(), "Data\\GeriStudentai.txt");
        public static string BadStudentWriteFile => Path.Combine(Directory.GetCurrentDirectory(), "Data\\BlogiStudentai.txt");
        public static string AllStudentWriteFile => Path.Combine(Directory.GetCurrentDirectory(), "Data\\VisiStudentai.txt");


        public static string GetRandomStudentListFile(int studentCount)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"Data\\Studentai{studentCount}.txt");
        }

        public static string GetRandomStudentListFileForStudentType(int studentCount, bool goodStudent)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"Data\\Studentai{studentCount}{(goodStudent ? "good": "bad")}.txt");
        }
    }
}
