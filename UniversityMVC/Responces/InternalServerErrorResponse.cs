namespace UniversityMVC.Responses;

public class InternalServerErrorResponse
{
    public string Message { get; set; }

    public InternalServerErrorResponse(string message)
    {
        Message = message;
    }
}
