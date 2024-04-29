using System;
using System.Text.Json.Serialization;

namespace GitHubIntegration.DataModel.Models
{
    public class Result
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage => Exception?.Message;

        public Exception Exception { get; set; }

        public static Result Success => new() { IsSuccessful = true };

        public static Result Error(Exception exception = default)
        {
            return new Result { IsSuccessful = false, Exception = exception };
        }
    }

    public class Result<T>
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage => Exception?.Message;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public T Data { get; set; }

        public static Result<T> Success(T data = default)
        {
            return new Result<T> { IsSuccessful = true, Data = data };
        }

        public static Result<T> Error(Exception exception = default)
        {
            return new Result<T> { IsSuccessful = false, Exception = exception };
        }
    }
}
