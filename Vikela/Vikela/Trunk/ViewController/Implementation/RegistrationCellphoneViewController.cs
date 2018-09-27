using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.ViewController
{
    public class RegistrationCellphoneViewController : ProjectBaseViewController<RegistrationCellphoneViewModel>, IRegistrationCellphoneViewController
    {
        IRegistrationCellphoneRepository _Reposetory;
        INIUSSDService<NIUSSDReturnModel> nIUSSDService;

        public override void SetRepositories()
        {
            nIUSSDService = new NIUSSDService<NIUSSDReturnModel>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<NIUSSDReturnModel>(U, P, A));
            _Reposetory = new RegistrationCellphoneRepository(_MasterRepo, nIUSSDService);

            InputObject.Greeting = "Hi " + _MasterRepo.DataSource.User.FirstName +
                ", what is your cellphone number?";
            InputObject.CellPhoneNumber = _MasterRepo.DataSource.User.MobileNumber;
        }

        public async Task UpdateCellPhoneAsync()
        {
            //var isValid = await _Reposetory.UpdateCellPhoneWithUSSDTestAsync(InputObject);
            //if (isValid)
                _MasterRepo.PushRegistrationIDNumber();
        }
    }
}