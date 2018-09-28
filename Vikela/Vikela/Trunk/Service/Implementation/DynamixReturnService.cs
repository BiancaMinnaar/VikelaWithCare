using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Root;

namespace Vikela.Trunk.Service.Implementation
{
    public class DynamixReturnService<T> : BaseService<T>, IDynamixReturnService<T>
    {
        public DynamixReturnService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task<T>> networkInterface)
                : base(networkInterface)
        {
        }

        public async Task<T> GetConnectedContactsAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/Connections/getconnectedcontacts";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"userId", new ParameterTypedValue(model.UserID, ParameterTypeEnum.ValueParameter)}
            };

            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> GetAllActivePoliciesAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/Policy/getpolicyoverview";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"userId", new ParameterTypedValue(model.UserID, ParameterTypeEnum.ValueParameter)}
            };

            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> GetCommunityAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/Communities/{getCommunityName}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"userId", new ParameterTypedValue(model.UserID, ParameterTypeEnum.ValueParameter)}
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> AddTrustedSourceAsync(ContactDetailViewModel model)
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
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> AddBeneficiaryAsync(ContactDetailViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/addbeneficiary";
            var httpMethod = BaseNetworkAccessEnum.Put;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    benefactorUserId= model.UserID,
                    beneficiaryFirstName= model.FirstName,
                    beneficiaryLastName= model.LastName,
                    beneficiaryMobileNumber= model.CellNumber,
                }, ParameterTypeEnum.BodyParameter)}
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> UpdateContactAsync(ContactDetailViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/update";
            var httpMethod = BaseNetworkAccessEnum.Patch;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"body", new ParameterTypedValue(new
                {
                    userId= model.UserID,
                    eMail= "",
                    firstName= model.FirstName,
                    lastName= model.LastName,
                    idNumber=model.IDNumber,
                    mobileNumber=model.CellNumber,
                    profileImageUrl=""
                }, ParameterTypeEnum.BodyParameter)}
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> GetUserWithOIDAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/User/" + model.OID;
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }

        public async Task<T> RegisterUserAsync(RegisterViewModel model)
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
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }
    }
}
