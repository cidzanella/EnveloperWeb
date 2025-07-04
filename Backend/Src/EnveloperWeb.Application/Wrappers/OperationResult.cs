﻿namespace EnveloperWeb.Application.Wrappers
{
    //Uso interno na Application Layer (Services, Use Cases)
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static OperationResult<T> Success(T data)
            => new() { IsSuccess = true, Data = data };

        public static OperationResult<T> Failure(string error)
            => new() { IsSuccess = false, Errors = new List<string> { error } };

        public static OperationResult<T> Failure(IEnumerable<string> errors)
            => new() { IsSuccess = false, Errors = errors.ToList() };
    }
}
