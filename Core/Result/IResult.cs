namespace Core.Result
{
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}