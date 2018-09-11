using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class CongratulationsRepository<T> : ProjectBaseRepository, ICongratulationsRepository
        where T : BaseViewModel
    {
        public CongratulationsRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }
    }
}