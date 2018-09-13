using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
        public class MyCommunityService : BaseService
        {
            public MyCommunityService(Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> networkInterface)
                :base(networkInterface)
            {
            }

        
    }
}
