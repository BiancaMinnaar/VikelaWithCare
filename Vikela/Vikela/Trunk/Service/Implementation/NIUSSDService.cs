using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;
using Vikela.Root;

namespace Vikela.Implementation.Service
{
    public class NIUSSDService<T> : BaseService<T>, INIUSSDService<T>
    {
        public NIUSSDService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task<T>> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task<T> SendUSSDAsync(NIUSSDViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/retryverifyuserniussd";
            var httpMethod = BaseNetworkAccessEnum.Post;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    model.userId,
                    model.mobileNumber
                }, ParameterTypeEnum.BodyParameter)}
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }
    }
}
