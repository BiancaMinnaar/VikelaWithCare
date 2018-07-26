using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Service
{
        public class RegisterService<T> : BaseService<T>, IRegisterService<T>
            where T : BaseViewModel
        {
            public RegisterService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
                :base(networkInterface)
            {
            }

            public async Task<T> Register(RegisterViewModel model)
            {
                string requestURL = "/register";
                var httpMethod = BaseNetworkAccessEnum.Post;
                var parameters = new Dictionary<string, ParameterTypedValue>()
                {
                    {"FisrtName", new ParameterTypedValue(model.FisrtName)},
                    {"LastName", new ParameterTypedValue(model.LastName)},
                    {"MobileNumber", new ParameterTypedValue(model.MobileNumber)},
                    {"UserPicture", new ParameterTypedValue(model.UserPicture)}
                };
                return await _NetworkInterface(requestURL, parameters, null, httpMethod);
            }
    }
}
