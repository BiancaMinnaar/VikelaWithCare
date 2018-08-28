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
                    //idNumber= model.IDNumber,
                    //mobileNumber= model.MobileNumber,
                    UserPictureURL="qq",
                //    userId = "995d0312-254b-488f-ab9a-7ae47c407228",
                //EmailAddress = "26AugUser2@vikelaproductsdev.onmicrosoft.com",
                //firstName = "26AugUser2",
                //lastName = "User2Lastname",
                idNumber = "1234567890149",
                mobileNumber = "1234567891"
                //profileImageUrl = "qq"
                }, ParameterTypeEnum.BodyParameter)}
            };
            await _NetworkInterfaceWithTypedParameters(requestURL, parameters, httpMethod);
        }
    }
}
