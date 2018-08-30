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
    public class ContactDetailViewController : ProjectBaseViewController<ContactDetailViewModel>, IContactDetailViewController
    {
        IContactDetailRepository<ContactDetailViewModel> _Reposetory;
        IContactDetailService<ContactDetailViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new ContactDetailService<ContactDetailViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<ContactDetailViewModel>(U, P, C, A));
            _Reposetory = new ContactDetailRepository<ContactDetailViewModel>(_MasterRepo, _Service);
        }

        public async Task Load()
        {
            
        }
    }
}