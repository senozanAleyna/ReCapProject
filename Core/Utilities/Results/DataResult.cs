using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)//bunun base'i zaten this diyor
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)//mesaj vermedik
        {
            Data = data;
        }
        public T Data { get; }
    }
}
