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
    public class ContactDetailViewViewController : ProjectBaseViewController<ContactDetailViewViewModel>, IContactDetailViewViewController
    {
        IContactDetailViewRepository<ContactDetailViewViewModel> _Reposetory;
        IContactDetailViewService<ContactDetailViewViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new ContactDetailViewService<ContactDetailViewViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<ContactDetailViewViewModel>(U, P, C, A));
            _Reposetory = new ContactDetailViewRepository<ContactDetailViewViewModel>(_MasterRepo, _Service);
        }

        public async Task Load()
        {
            
        }
    }
}