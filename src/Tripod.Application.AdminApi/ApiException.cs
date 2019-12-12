using System;

namespace Tripod.Application.AdminApi
{
  public class ApiException : Exception
  {
    public int Code { get; set; }

    public ApiException() { }

    public ApiException(int code)
        : this(code, "")
    {

    }

    public ApiException(string message)
        : this(0, message)
    {

    }

    public ApiException(int code, string message)
        : base(message)
    {
        this.Code = code;
    }
  }
}