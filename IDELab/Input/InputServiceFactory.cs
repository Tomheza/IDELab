using System;
using System.Collections.Generic;

namespace IDELab.Input
{
    public static class InputServiceFactory
    {
        private static readonly IDictionary<DataInputType, Func<IDataInput>> Creators =
            new Dictionary<DataInputType, Func<IDataInput>>()
            {
                {DataInputType.File, () => new FileInputHandler()},
                {DataInputType.User, () => new UserInputHandler()}
            };

        public static IDataInput CreateInstance(DataInputType dataInputType)
        {
            return Creators[dataInputType]();
        }
    }
}
