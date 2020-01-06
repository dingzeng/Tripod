using System;

namespace Tripod.Application.AdminApi
{
    public class Response<TData>
    {
        public ApiCode Code { get; set; }

        public TData Data { get; set; }

        public string Message { get; set; }

        public static implicit operator Response<TData>(TData value)
        {
            return new Response<TData>()
            {
                Code = ApiCode.SUCCESS,
                Data = value
            };
        }
    }

    public class Response : Response<object>
    {

    }
}