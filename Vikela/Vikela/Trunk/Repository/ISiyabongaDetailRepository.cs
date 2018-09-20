using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ISiyabongaDetailRepository
    {
        Task YourMethodName(SiyabongaDetailViewModel model, Action completeAction);
    }
}
