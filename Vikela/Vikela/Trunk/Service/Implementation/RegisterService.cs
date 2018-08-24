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

        public async Task Register365UserAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/register";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue("a77f84e222b54957a9c946b99347c1f1", ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"userId", new ParameterTypedValue(model.OID)},
                {"eMail", new ParameterTypedValue(model.EmailAddress)},
                {"firstName", new ParameterTypedValue(model.FirstName)},
                {"lastName", new ParameterTypedValue(model.LastName)},
                {"idNumber", new ParameterTypedValue(model.IDNumber)},
                {"mobileNumber", new ParameterTypedValue(model.MobileNumber)},
                {"profileImageUrl", new ParameterTypedValue(model.UserPictureURL)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
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
