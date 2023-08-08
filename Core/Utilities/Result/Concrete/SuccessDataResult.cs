namespace Core.Utilities.Result.Concrete;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult() : base(true)
    {

    }
    public SuccessDataResult(string message) : base(message)
    {

    }
    public SuccessDataResult(T data) : base(data)
    {

    }
    public SuccessDataResult(bool success, string message) : base(true, message)
    {

    }
    public SuccessDataResult(T data, bool success) : base(data, true)
    {

    }
    public SuccessDataResult(T data, bool success, string message) : base(data, true, message)
    {

    }
}
