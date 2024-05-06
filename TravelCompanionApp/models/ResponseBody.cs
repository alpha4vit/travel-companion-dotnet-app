namespace TravelCompanionApp.models;

public class ResponseBody
{
    public object Data { get; set; }
    public Dictionary<string, string> Headers { get; set; }

    public ResponseBody(object data, Dictionary<string, string> headers)
    {
        Data = data;
        Headers = headers;
    }
}