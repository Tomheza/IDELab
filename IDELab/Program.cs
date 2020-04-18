using System;
using IDELab.Input;

namespace IDELab
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("IDE LAB!");

            Console.WriteLine("If you want to enter data manually enter 0\n" +
                              "If you want to load data from the file with a first input strategy enter 1\n" +
                              "If you want to load data from the file with a second input strategy enter enter 2\n" +
                              "If you want to load data from the file with a third input strategy enter any key");
            var dataInputType = Console.ReadLine();

            IDataInput inputHandler;

            if (int.TryParse(dataInputType, out var inputType) && inputType == 0)
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.User);
            else if (inputType == 1)
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.FirstFileInputStrategy);
            else if (inputType == 2)
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.SecondFileInputStrategy);
            else
                inputHandler = InputServiceFactory.CreateInstance(DataInputType.ThirdFileInputStrategy);

            inputHandler.InputData();
            RandomStudentListGenerator.Generate();
        }
    }
}