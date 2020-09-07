using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;

namespace Permission.ApiGateway
{
    public class MyResponse
    {
        public string NameOfRespone { get; set; }
        public bool IsOk { get; set; }
    }
    public class TestHandler : DelegatingHandler
    {
//        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var result1 = base.SendAsync(request, cancellationToken);
//            var waitOnResult1 = result1.GetAwaiter();
//            var result = base.SendAsync(request, cancellationToken).GetAwaiter();
//            while (waitOnResult1.IsCompleted == false)
//            {
//                Thread.Sleep(5);
//            }
//            var resultValue = result.GetResult();
//            var newResult = new HttpResponseMessage(result1.Result.StatusCode);
//            //            result.Content = new ObjectContent<MyResponse>(new MyResponse{ NameOfRespone = "My Name", IsOk = true}, new JsonMediaTypeFormatter());
//            result.OnCompleted((() => result1.Result.Headers.Add("X-MyHeader-123", "asdfsdfadf")));
//
//            result1.Result.Headers.Add("X-NewHeader", "AAAAA");
//            return result1;
//        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            //...Extract and log request
            LogRequest(request);

            // Send the request on to the inner handler(s) and get the response
            var response = await base.SendAsync(request, cancellationToken);

            //...Extract details from response for logging
            LogResponse(response);

            return response;
        }

        private void LogRequest(HttpRequestMessage request)
        {
            //... code removed for brevity
        }

        private void LogResponse(HttpResponseMessage response)
        {
            response.Headers.Add("X-My-Header", "AAA");
        }
    }
}