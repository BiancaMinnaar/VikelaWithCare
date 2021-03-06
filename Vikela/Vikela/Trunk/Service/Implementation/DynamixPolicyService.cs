﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Root;
using Vikela.Trunk.Service.ReturnModel;
namespace Vikela.Trunk.Service.Implementation
{
    public class DynamixPolicyService: BaseService<List<DynamixPolicy>>, IDynamixPolicyService
    {
        public DynamixPolicyService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task<List<DynamixPolicy>>> networkInterface)
                : base(networkInterface)
        {
        }

        public async Task<List<DynamixPolicy>> GetAllActivePoliciesAsync(RegisterViewModel model)
        {
            string requestURL = "/dyn365/api/v1.0/Policy";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Ocp-Apim-Subscription-Key", new ParameterTypedValue(Constants.APIM_GUID, ParameterTypeEnum.HeaderParameter)},
                {"Authorization", new ParameterTypedValue(model.TokenID, ParameterTypeEnum.HeaderParameter)},
                {"getpolicyoverview", new ParameterTypedValue("", ParameterTypeEnum.ValueParameter)},
                {"userId", new ParameterTypedValue(model.UserID, ParameterTypeEnum.ValueParameter)}
            };

            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }
    }
}
