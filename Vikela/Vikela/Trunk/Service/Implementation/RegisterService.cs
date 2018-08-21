using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
        public class RegisterService<T> : BaseService<T>, IRegisterService<T>
            where T : BaseViewModel
        {
            public RegisterService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
                :base(networkInterface)
            {
            }

            public async Task<T> Register(RegisterViewModel model)
            {
                string requestURL = "/register";
                var httpMethod = BaseNetworkAccessEnum.Post;
                var parameters = new Dictionary<string, ParameterTypedValue>()
                {
                    {"FisrtName", new ParameterTypedValue(model.FisrtName)},
                    {"LastName", new ParameterTypedValue(model.LastName)},
                    {"MobileNumber", new ParameterTypedValue(model.MobileNumber)},
                    {"UserPicture", new ParameterTypedValue(model.UserPicture)}
                };
                return await _NetworkInterface(requestURL, parameters, null, httpMethod);
            }

        public async Task<T> RegisterForSASAsync(RegisterViewModel model)
        {
            string requestURL = "/tokens/api/v1.0/Tokens/register";
            var httpMethod = BaseNetworkAccessEnum.Post;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue("a77f84e222b54957a9c946b99347c1f1", ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)}
            };
            return await _NetworkInterface(requestURL, parameters, null, httpMethod);
        }
    }
}
