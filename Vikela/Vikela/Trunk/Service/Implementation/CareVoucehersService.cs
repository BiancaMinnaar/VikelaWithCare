using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
    public class CareVoucehersService<T> : BaseService<T>, ICareVoucehersService<T>
    {
        public CareVoucehersService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task<T>> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task<T> YourMethodNameAsync(CareVoucehersViewModel model)
        {
            string requestURL = "/path/{Parameter}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                //{"Parameter", model.Property},
            };
            return await _NetworkInterfaceWithOutput(requestURL, parameters, httpMethod);
        }
    }
}
