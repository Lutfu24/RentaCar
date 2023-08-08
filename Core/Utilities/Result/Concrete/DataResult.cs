using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Result.Concrete;

public class DataResult<T> : IDataResult<T>
{
    public T Data { get; }
    public bool Success { get; }
    public string Message { get; }
    public DataResult(bool success)
    {
        Success = success;
    }
    public DataResult(T data)
    {
        Data = data;
    }
    public DataResult(T data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }
    public DataResult(string message)
    {
        Message = message;
    }
    public DataResult(T data, bool success)
    {
        Data = data;
        Success = success;
    }
    public DataResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
