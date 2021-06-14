using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GedDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GedDefaultMessageForStatusCode(int statudCode)
        {
            return StatusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Autorized, you are not",
                404 => "Resourse found, it was not",
                500 => "Errors are the path to the dark side.",
                _ => null
            };
        }
    }
}