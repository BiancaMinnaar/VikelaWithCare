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

        public override void SetRepositories()
        {
            _Reposetory = new SettingsRepository<SettingsViewModel>(_MasterRepo);
        }

        public async Task LogoutAsync()
        {
            await _MasterRepo.RemoveUserRecordAsync(_MasterRepo.DataSource.User);
            foreach (var user in App.PCA.Users) { App.PCA.Remove(user); }
            _MasterRepo.PushLogOut();
        }
    }
}