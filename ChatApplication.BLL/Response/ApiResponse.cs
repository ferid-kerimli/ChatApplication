namespace ChatApplication.BLL.Response;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
    public string Message { get; set; } 

    public void Success(T data, int statusCode)
    {
        IsSuccess = true;
        StatusCode = statusCode;
        Data = data;
        Errors = null;
    }

    public void Success(string message, int statusCode)
    {
        IsSuccess = true;
        StatusCode = statusCode;
        Errors = null;
        Data = default;
        Message = message;
    }
    
    public void Failure(List<string> errors, int statusCode)
    {
        IsSuccess = false;
        Data = default;
        Errors = errors;
        StatusCode = statusCode;
    }

    public void Failure(string error, int statusCode)
    {
        IsSuccess = false;
        Data = default;
        Errors = new List<string> { error };
        StatusCode = statusCode;
    }
}