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
            

            if (File.Exists(combinedString))
            {

            }
        }
    }
}
