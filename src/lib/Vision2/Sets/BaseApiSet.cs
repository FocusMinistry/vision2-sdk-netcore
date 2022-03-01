using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;

namespace Vision2 {
    public class BaseSet<T> where T : new() {
        private readonly Vision2Options _options;
        private readonly Vision2Token _token;
        private readonly string _baseUrl;
        private readonly Action<IVision2RestResponse> _loggingAction;

        public BaseSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) {
            _baseUrl = apiUrl;
            _token = token;
            _loggingAction = loggingAction;
        }

        internal async Task<IVision2RestResponse<Vision2Response<T>>> GetAsync(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<Vision2Response<T>>(response, url, null, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<List<T>>> FindAsync(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<List<T>>(response, url, null, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<List<T>>> FindAsync(string url, BaseQO qo, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(BuildURLParametersString(url, qo));
                return await ConvertResponseAsync<List<T>>(response, url, qo.ToQueryString(), memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<Vision2PagedResponse<S>>> SearchAsync<S>(string url, BaseQO qo, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var query = qo.ToDictionary();
                var queryJson = JsonConvert.SerializeObject(query);

                var jsonContent = JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);

                return await ConvertResponseAsync<Vision2PagedResponse<S>>(response, url, jsonContent, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<List<S>>> FindAsync<S>(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<List<S>>(response, url, string.Empty, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<List<S>>>> FindResultsAsync<S>(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<Vision2Response<List<S>>>(response, url, string.Empty, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<List<S>>> FindAsync<S>(string url, BaseQO qo, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(BuildURLParametersString(url, qo));
                return await ConvertResponseAsync<List<S>>(response, url, qo.ToQueryString(), memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<S>>> PostAsync<S>(S entity, string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<S>>(response, url, jsonContent, memberName, fileName, lineNumber);
                vision2Response.RequestValue = jsonContent;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<T>>> PostAsync(T entity, string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<T>>(response, url, jsonContent, memberName, fileName, lineNumber);
                vision2Response.RequestValue = jsonContent;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<T>>> PutAsync(T entity, string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PutAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<T>>(response, url, jsonContent, memberName, fileName, lineNumber);
                vision2Response.RequestValue = jsonContent;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<S>>> PutAsync<S>(string url, string data, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PutAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<S>>(response, url, data, memberName, fileName, lineNumber);
                vision2Response.RequestValue = data;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse> PostAsync(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var response = await http.PostAsync(url, null);
                return await ConvertResponseAsync(response, url, null, memberName, fileName, lineNumber);
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<S>>> PostAsync<S>(string url, string data, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            using (var http = CreateClient()) {
                StringContent content = null;
                if (data != null) {
                    content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                }
                var response = await http.PostAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<S>>(response, url, data, memberName, fileName, lineNumber);
                vision2Response.RequestValue = data;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse<Vision2Response<T>>> PatchAsync(T entity, string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json-patch+json");
                var response = await http.PatchAsync(url, content);

                var vision2Response = await ConvertResponseAsync<Vision2Response<T>>(response, url, jsonContent, memberName, fileName, lineNumber);
                vision2Response.RequestValue = jsonContent;
                return vision2Response;
            }
        }

        internal async Task<IVision2RestResponse> DeleteAsync(string url, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            using (var http = CreateClient()) {
                var response = await http.DeleteAsync(url);
                return await ConvertResponseAsync(response, url, null, memberName, fileName, lineNumber);
            }
        }

        private HttpClient CreateClient() {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.access_token);
            return httpClient;
        }

        private async Task<IVision2RestResponse<S>> ConvertResponseAsync<S>(HttpResponseMessage response, string url, string request = "", [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) where S : new() {
            var vision2Response = new Vision2RestResponse<S> {
                StatusCode = response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(),
                RequestValue = request,
                Url = url,
                CallerFilePath = fileName,
                CallerLineNumber = lineNumber,
                CallerMemberName = memberName,
            };

            try {
                vision2Response.Data = JsonConvert.DeserializeObject<S>(vision2Response.JsonResponse);
            }
            catch (Exception ex) {
                if (!string.IsNullOrEmpty(vision2Response.JsonResponse) && (int)response.StatusCode > 300) {
                    var responseError = JsonConvert.DeserializeObject<dynamic>(vision2Response.JsonResponse);
                    vision2Response.ErrorMessage = responseError.error_message;
                }
            }

            _loggingAction?.Invoke(vision2Response);

            return vision2Response;
        }

        private async Task<IVision2RestResponse> ConvertResponseAsync(HttpResponseMessage response, string url, string request = "", [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0) {
            var vision2Response = new Vision2RestResponse {
                StatusCode = response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(),
                RequestValue = request,
                Url = url,
            };

            if (!string.IsNullOrEmpty(vision2Response.JsonResponse) && (int)response.StatusCode > 300) {
                var responseError = JsonConvert.DeserializeObject<dynamic>(vision2Response.JsonResponse);
                vision2Response.ErrorMessage = responseError.error_message;
            }

            _loggingAction?.Invoke(vision2Response);

            return vision2Response;
        }

        private string BuildURLParametersString(string uri, BaseQO qo) {
            return $"{ uri}?{qo.ToQueryString()}";
        }

        private int? GetHeaderValue(string value, HttpResponseMessage response) {
            if (!response.Headers.Contains(value)) {
                return null;
            }

            var values = response.Headers.GetValues(value).FirstOrDefault();
            if (values != null) {
                return int.Parse(values);
            }

            return null;
        }
    }
}
