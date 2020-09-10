namespace DemoLuz.Core.Common
{
    public class CommandResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
    public class CommandResult<T>: CommandResult
    {
        public T Result { get; set; }
    }
}
