using System;

namespace Core.Entities
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        
        public bool IsFailure => !IsSuccess;

        public Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
            {
                throw new InvalidOperationException();
            }
            
            if (!isSuccess && error == string.Empty)
            {
                throw new InvalidOperationException();
            }


            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new(default(T), false, message);
        }

        public static Result Ok()
        {
            return new(true, String.Empty);
        }
        
        public static Result<T> Ok<T>(T value)
        {
            return new(value, true, string.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }
            return Ok();
        }
        
    }
    
    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (!IsSuccess)
                {
                    throw new InvalidOperationException();
                }

                return _value;
            }
        }

        public Result(T value, bool isSuccess, string error) 
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}