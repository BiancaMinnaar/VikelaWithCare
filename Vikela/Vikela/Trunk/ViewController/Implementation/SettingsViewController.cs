using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class SettingsViewController : ProjectBaseViewController<SettingsViewModel>, ISettingsViewController
    {
        ISettingsRepository<SettingsViewModel> _Reposetory;
        ISettingsService<SettingsViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new SettingsService<SettingsViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<SettingsViewModel>(U, P, C, A));
            _Reposetory = new SettingsRepository<SettingsViewModel>(_MasterRepo, _Service);
        }

        public async Task Show()
        {
            
        }
    }
}