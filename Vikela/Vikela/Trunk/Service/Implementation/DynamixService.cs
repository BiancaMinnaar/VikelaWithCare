using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Root;

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
            string requestURL = "/dyn365/api/v1.0/User/create";
            var httpMethod = BaseNetworkAccessEnum.Post;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    aadObjectId= model.OID,
                    eMail= model.EmailAddress,
                    firstName= model.FirstName,
                    lastName= model.LastName,
                    idNumber= model.IDNumber,
                    mobileNumber= model.MobileNumber,
                    UserPictureURL="edit"
                }, ParameterTypeEnum.BodyParameter)}
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }

        public async Task GetUserWithOIDAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/" + model.OID;
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }

        public async Task AddTrustedSourceAsync(ContactDetailViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/addsource";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    trusteeUserId= model.UserID,
                    trustedSourceFirstName= model.FirstName,
                    trustedSourceLastName= model.LastName,
                    trustedSourceMobileNumber= model.CellNumber,
                }, ParameterTypeEnum.BodyParameter)}
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }

        public async Task AddBeneficiaryAsync(AddContactViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/addbeneficiary";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    benefactorUserId= model.SourceDetail.UserID,
                    beneficiaryFirstName= model.SourceDetail.FirstName,
                    beneficiaryLastName= model.SourceDetail.LastName,
                    beneficiaryMobileNumber= model.SourceDetail.CellNumber,
                }, ParameterTypeEnum.BodyParameter)}
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }

        public async Task GetConnectedContacts(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/Connections/getconnectedcontacts";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"userId", new ParameterTypedValue(model.UserID, ParameterTypeEnum.ValueParameter)}
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }
    }
}
