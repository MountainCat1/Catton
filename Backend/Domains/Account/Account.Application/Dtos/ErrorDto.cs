namespace Account.Service.Dtos;

public class ErrorDto
{
    public Error Error { get; set; }
}

public class Error
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}