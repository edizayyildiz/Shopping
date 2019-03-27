using System;

namespace Shopping.Service
{
    public class Result
    {
        public Result()
        {

        }

        // bu yapıcı metodu hata olduğunda çağırın
        public Result(bool success, dynamic value, string message, bool tokenStatus, string stackTrace)
        {
            Success = success;
            Value = value;
            Message = message;
            TokenStatus = tokenStatus;
            StackTrace = stackTrace;
        }
        // bu yapıcı metodu işlem başarılıysa çağırın
        public Result(bool success, dynamic value, string message, bool tokenStatus, long totalRecordCount)
        {
            Success = success;
            Value = value;
            Message = message;
            TotalRecordCount = totalRecordCount;
            TokenStatus = TokenStatus;
        }
        
        public dynamic Value { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public long TotalRecordCount { get; set; }
        public bool TokenStatus { get; set; }
        public string StackTrace { get; set; }
    }
}
