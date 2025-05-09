﻿
namespace API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request",
                401 => "You are not authorized",
                404 => "Resouce is not found",
                500 => "Error",
                _ => null
            };
        }
    }
}
