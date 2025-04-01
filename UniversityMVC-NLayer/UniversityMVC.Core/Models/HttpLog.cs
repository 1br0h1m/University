namespace UniversityMVC.Models;

public class HttpLog
{
    public string RequestId { get; set; }
    public string Url { get; set; }
    public string RequestBody { get; set; }
    public string RequestHeaders { get; set; }
    public int MethodTypeId { get; set; }
    public string ResponseBody { get; set; }
    public string ResponseHeaders { get; set; }
    public int StatusCode { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string ClientIp { get; set; }
}