using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
    public class RegisterService : BaseService, IRegisterService
    {
        public RegisterService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task RegisterEnvironmentUserAsync(RegisterViewModel model)
        {
            string requestURL = "/register";
            var httpMethod = BaseNetworkAccessEnum.Post;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"FisrtName", new ParameterTypedValue(model.FirstName)},
                {"LastName", new ParameterTypedValue(model.LastName)},
                {"MobileNumber", new ParameterTypedValue(model.MobileNumber)},
                {"UserPicture", new ParameterTypedValue(model.UserPicture)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }

        public async Task RegisterForSASAsync(RegisterViewModel model)
        {
            string requestURL = "/tokens/api/v1.0/Tokens/register";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue("a77f84e222b54957a9c946b99347c1f1", ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }
    }
}
