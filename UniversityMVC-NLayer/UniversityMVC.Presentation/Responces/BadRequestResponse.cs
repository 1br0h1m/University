namespace UniversityMVC.Responses;

public class BadRequestResponse
{
    public string Message { get; set; }
    public string? Parameter { get; set; }

    public BadRequestResponse(string message)
    {
        Message = message;
    }
}
