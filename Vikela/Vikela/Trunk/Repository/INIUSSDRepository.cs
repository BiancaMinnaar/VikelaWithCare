using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface INIUSSDRepository
    {
        Task YourMethodNameAsync(NIUSSDViewModel model, Action completeAction);
    }
}
