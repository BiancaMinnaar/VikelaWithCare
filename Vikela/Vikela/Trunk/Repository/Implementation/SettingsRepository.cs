using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class SettingsRepository<T> : ProjectBaseRepository, ISettingsRepository<T>
        where T : BaseViewModel
    {
        public SettingsRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }
    }
}