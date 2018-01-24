using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSPA.Modules
{
    public class ApiResponse<T>
    {
        public Status StatusCode { get; set; }
        public bool IsSuccess { get { return Status.Success == StatusCode; } }
        public string Description { get; set; }
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            StatusCode = Status.Success;
            Data = data;
        }

        public ApiResponse(ErrorMsg error)
        {
            StatusCode = error.Code;
            Description = error.Message;
        }

    }

    public class ErrorMsg
    {
        public Status Code;
        public string Message;
    }

    public enum Status
    {
        Success = 200,
        BadRequest = 400,
        ServerError = 500,
        OtherError = 900
    }
}
