namespace Core.Utilities.Result.Concrete;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult() : base(false)
    {

    }
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {

    }
    public ErrorDataResult(T data) : base(data)
    {

    }
    public ErrorDataResult(string message) : base(message)
    {

    }
    public ErrorDataResult(T data, bool success) : base(data, false)
    {

    }
    public ErrorDataResult(bool success, string message) : base(false, message)
    {

    }
}
