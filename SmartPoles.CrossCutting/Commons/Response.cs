using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.CrossCutting.Commons
{
    public class Response<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public Response(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public Response(bool isSuccess, params string[] messages)
        {
            IsSuccess = isSuccess;
            ErrorMessages.AddRange(messages);
        }

        public static Response<T> Fail(string error)
        {
            return new Response<T>(false, error);
        }

        public static Response<T> Ok(T value)
        {
            return new Response<T>(value);
        }

        public static Response<T> Ok()
        {
            return new Response<T>(true);
        }
    }
}
