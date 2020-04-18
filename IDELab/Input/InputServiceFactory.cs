using System;
using System.Collections.Generic;

namespace IDELab.Input
{
    public static class InputServiceFactory
    {
        private static readonly IDictionary<DataInputType, Func<IDataInput>> Creators =
            new Dictionary<DataInputType, Func<IDataInput>>
            {
                {DataInputType.User, () => new UserInputHandler()},
                {DataInputType.FirstFileInputStrategy, () => new FirstFileInputStrategy()},
                {DataInputType.SecondFileInputStrategy, () => new SecondFileInputStrategy()},
                {DataInputType.ThirdFileInputStrategy, () => new ThirdFileInputStrategy()}
            };

        public static IDataInput CreateInstance(DataInputType dataInputType)
        {
            return Creators[dataInputType]();
        }
    }
}