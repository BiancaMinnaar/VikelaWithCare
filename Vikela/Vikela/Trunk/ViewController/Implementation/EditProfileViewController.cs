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
    public class EditProfileViewController : ProjectBaseViewController<EditProfileViewModel>, IEditProfileViewController
    {
        IEditProfileRepository<EditProfileViewModel> _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new EditProfileRepository<EditProfileViewModel>(_MasterRepo);
        }

        public void Load()
        {
            InputObject.UserProfile = _Reposetory.Load();
        }

        public void PushSettings()
        {
            _MasterRepo.PushSettings();
        }

        public async Task Edit()
        {
            
        }
    }
}