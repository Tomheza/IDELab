using System;
using IDELab.Input;

namespace IDELab
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("IDE LAB!");

            Console.WriteLine("If you want to enter data manually enter 0, if you want to load data from the file, any key.");
            var dataInputType = Console.ReadLine();

            IDataInput inputHandler;

            if (int.TryParse(dataInputType, out var inputType) && inputType == 0)
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.User);
            else
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.File);

            inputHandler.InputData();

            RandomStudentListGenerator.Generate();
        }
    }
}