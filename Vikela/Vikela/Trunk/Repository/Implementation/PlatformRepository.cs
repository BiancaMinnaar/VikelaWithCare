using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Injection.Base;
using CorePCL;
using Xamarin.Forms;

namespace Vikela.Trunk.Repository.Implementation
{
    public class PlatformRepository<T> : ProjectBaseRepository, IPlatformRepository<T>
        where T : BaseViewModel
    {
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public PlatformRepository(IMasterRepository masterRepository, IPlatformBonsai<IPlatformModelBonsai> platformBonsai)
            : base(masterRepository)
        {
            _PlatformBonsai = platformBonsai;
            //??
            _PlatformBonsai.OnError = (obj) =>
            {
                OnError(obj);
            };
            AddCallBackToAllPlatformServices();
        }

        void AddCallBackToAllPlatformServices()
        {
            foreach (var platformService in _PlatformBonsai.GetBonsaiServices)
            {
                platformService.PlatformHarness.ServiceCallBack = (platformModel) =>
                {
                    SetPlatformModelAndReportToAllListeners(platformService, platformModel);

                };
                platformService.PlatformHarness.OnError = (errorList) =>
                {
                    Errors = errorList;
                    OnError?.Invoke(errorList);
                };
                //Only activate on demand
                //platformService.PlatformHarness.Activate();
            }
        }

        void SetPlatformModelAndReportToAllListeners(BonsaiPlatformServiceRegistrationStruct platformService, IPlatformModelBase platformModel)
        {
            _MasterRepo.DataSource.PlatformModel = platformModel;
            _MasterRepo.ReportToAllListeners(platformService.PlatformHarness.ServiceKey, platformModel);
        }
    }
}
