using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service.Implementation
{
	public class DynamixService : BaseService, IDynamixService
    {
        public DynamixService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
                :base(networkInterface)
		{
		}

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/register";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue("a77f84e222b54957a9c946b99347c1f1", ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    userId= new Guid(model.OID),
                    eMail= model.EmailAddress,
                    firstName= model.FirstName,
                    lastName= model.LastName,
                    idNumber= model.IDNumber,
                    mobileNumber= model.MobileNumber,
                    UserPictureURL="edit"
                }, ParameterTypeEnum.BodyParameter)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }

        public async Task GetUserWithOIDAsync(RegisterViewModel model)
        {
            string requestURL = "dyn365/api/v1.0/User/" + model.OID;
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue("a77f84e222b54957a9c946b99347c1f1", ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }
    }
}
