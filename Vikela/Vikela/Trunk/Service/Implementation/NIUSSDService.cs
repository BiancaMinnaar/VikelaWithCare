using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
    public class NIUSSDService<T> : BaseService<T>, INIUSSDService<T>
    {
        public NIUSSDService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task<T>> networkInterface)
            :base(networkInterface)
        {
        }

        public async Task<T> SendUSSDAsync(NIUSSDViewModel model)
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
