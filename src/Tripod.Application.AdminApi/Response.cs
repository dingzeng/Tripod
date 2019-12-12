using System;

namespace Tripod.Application.AdminApi
{
    public class Response<TData>
    {
        private Response() { }
        
        public int Code { get; set; }

        public TData Data { get; set; }

        public string Message { get; set; }

        public static implicit operator Response<TData>(TData value)
        {
            return new Response<TData>()
            {
                Code = 20000,
                Message = "success",
                Data = value
            };
        }
    }
}