using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository;
using Vikela.Trunk.ViewModel.Offline;
using Xamarin.Auth;

namespace Vikela.Implementation.Repository
{
    public class LoginRepository<T> : ProjectBaseRepository, ILoginRepository<T>
        where T : BaseViewModel, new()
    {
        ILoginService<T> _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public void AuthenticateFaceBook(
            IFacebookGraphRepository<T> graphRepo, Action<UserModel> completeAction)
        {
            var _auth = new OAuth2Authenticator("2063574180384090",
                                "email",
                                new Uri("https://www.facebook.com/dialog/oauth/"),
                                new Uri("https://www.facebook.com/connect/login_success.html"));

            _auth.Completed += async (sender, e) =>
            {
                var userModel = new UserModel()
                {
                    FacebookToken = e.Account.Properties["access_token"],
                    EmailAddress = 
                        await graphRepo.GetEmailAsync(
                            e.Account.Properties["access_token"])
                };
                completeAction(userModel);
            };
            _auth.Error += (sender, e) => 
            { 
                //_MasterRepo.errors 
            };
        }

        private void OnAuthenticationCompleted(object sender,
            AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var token = e.Account.Properties["access_token"];
                // Do something
            }
            else
            {
                // The user is not authenticated
            }
        }

        public async Task Login(LoginViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Login(model);
            completeAction(serviceReturnModel);
        }
    }
}