namespace LingoPartnerShared.result
{
  public class Result
  {
    public bool Success { get; set; }
    public string Message { get; set; }
    public Exception Exception { get; set; }

    public Result(bool success, string message, Exception exception = null)
    {
      Success = success;
      Message = message;
      Exception = exception;
    }
  }
}