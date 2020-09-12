using System;

namespace DemoLuz.Core.Logger
{
    public interface ILogger
    {
        void LogError(Exception e);
        void LogError(string error);
    }
}
