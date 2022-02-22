using System.Net;

namespace Vision2.Model {
    public interface IVision2RestResponse {
        string RequestValue { get; set; }

        string JsonResponse { get; set; }

        HttpStatusCode StatusCode { get; set; }

        string ErrorMessage { get; set; }

        bool IsSuccessful { get; }

        string Url { get; set; }

        string HttpMethod { get; set; }

        public string CallerMemberName { get; set; }

        public string CallerFilePath { get; set; }

        public int? CallerLineNumber { get; set; }
    }
    
    public interface IVision2RestResponse<T> : IVision2RestResponse {
        T Data { get; set; }
    }

    public class Vision2RestResponse : IVision2RestResponse {
        public string RequestValue { get; set; }

        public string JsonResponse { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccessful {
            get {
                return (int)StatusCode >= 200 && (int)StatusCode < 300;
            }
        }

        public string Url { get; set; }

        public string CallerMemberName { get; set; }

        public string CallerFilePath { get; set; }

        public int? CallerLineNumber { get; set; }

        public string HttpMethod { get; set; }
    }

    public class Vision2RestResponse<T> : Vision2RestResponse, IVision2RestResponse<T> where T : new() {
        public T Data { get; set; }
    }
}
