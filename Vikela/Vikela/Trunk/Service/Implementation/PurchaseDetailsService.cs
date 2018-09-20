using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
    public class PurchaseDetailsService : BaseService, IPurchaseDetailsService
    {
        public PurchaseDetailsService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task YourMethodName(PurchaseDetailsViewModel model)
        {
            string requestURL = "/path/{Parameter}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                //{"Parameter", model.Property},
            };
            await _NetworkInterface(requestURL, parameters, httpMethod);
        }
    }
}
