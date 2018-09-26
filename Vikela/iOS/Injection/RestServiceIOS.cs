using System;
using System.Net;
using System.Threading.Tasks;
using BasePCL.Networking;
using CorePCL;
using Newtonsoft.Json;
using RestSharp;
using Vikela.iOS.Injection;
using Vikela.Root;
using Xamarin.Forms;

[assembly: Dependency(typeof(RestServiceIOS))]
namespace Vikela.iOS.Injection
{
    public class RestRqst : RestRequest, INetworkRequest
    {
        public RestRqst(string urlExtention, Method httpMethodType)
            : base(urlExtention, httpMethodType)
        {
        }

        public static Method GetHttpMethod(BaseNetworkAccessEnum httpMethodType)
        {
            switch (httpMethodType)
            {
                default:
                    return Method.GET;
                case BaseNetworkAccessEnum.Post:
                    return Method.POST;
                case BaseNetworkAccessEnum.Put:
                    return Method.PUT;
                case BaseNetworkAccessEnum.Patch:
                    return Method.PATCH;
            }
        }

        public void AddFile(string name, byte[] value, string fileName)
        {
            base.AddFile(name, value, fileName);
        }

        public new void AddHeader(string name, string value)
        {
            base.AddHeader(name, value);
        }

        public new void AddJsonBody(object body)
        {
            base.AddJsonBody(body);
        }

        void INetworkRequest.AddParameter(string name, object value)
        {
            base.AddParameter(name, value);
        }
    }

    public class RestRspns : INetworkResponse
    {
        IRestResponse _RestResponse;
        public HttpStatusCode StatusCode => _RestResponse.StatusCode;
        public string StatusDescription => _RestResponse.StatusDescription;
        public string Content => _RestResponse.Content;
        public byte[] RawBytes => _RestResponse.RawBytes;

        public RestRspns(IRestResponse response)
        {
            _RestResponse = response;
        }
    }

    public class RestRspns<T> : RestRspns, INetworkResponse<T>
    {
        IRestResponse<T> _RestResponse;

        public RestRspns(IRestResponse<T> response)
            : base(response)
        {
            _RestResponse = response;
        }

        public T Data 
        {
            get
            {
                if (_RestResponse.Content.StartsWith("{", StringComparison.Ordinal) || _RestResponse.Content.StartsWith("[{", StringComparison.Ordinal))
                    return JsonConvert.DeserializeObject<T>(_RestResponse.Content);
                return default(T);
            }
        }
    }

    public class RestServiceIOS : INetworkInteraction
    {
        public INetworkRequest GetNetworkRequest(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public INetworkRequest GetNetworkRequestForJson(string urlExtention, BaseNetworkAccessEnum httpMethodType)
        {
            return new RestRqst(urlExtention, RestRqst.GetHttpMethod(httpMethodType));
        }

        public async Task<INetworkResponse> ExecuteTaskAsync(INetworkRequest req)
        {
            var client = new RestClient(Constants.BASE_URL);
            var response = await client.ExecuteTaskAsync((IRestRequest)req);
            Console.WriteLine("Network Response: " + JsonConvert.SerializeObject(response));
            return new RestRspns(response);
        }

        public async Task<INetworkResponse<T>> ExecuteTaskAsync<T>(INetworkRequest req)
        {
            var client = new RestClient(Constants.BASE_URL);
            var response = await client.ExecuteTaskAsync<T>((IRestRequest)req);
            Console.WriteLine("Network Response: " + JsonConvert.SerializeObject(response));
            return new RestRspns<T>(response);
        }
    }
}

