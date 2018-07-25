using System;
using System.Threading.Tasks;
using UIKit;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Facebook;

namespace Vikela.iOS.Injection.Facebook
{
    public class FacebookService : PlatformServiceBonsai<IPlatformModelBase>, IFacebookService<IPlatformModelBase>, IFacebookAuthenticationDelegate
    {
        public override string ServiceKey => "FacebookService";
        private object[] _Managers;
        private UIViewController _navigationStack;

        public override void Activate()
        {
            base.Activate();
            Task.Run(async () => await method());
        }

        public override void SetManagers(object[] managers)
        {
            _Managers = managers;
        }

        public void OnAuthenticationCanceled()
        {
            var fail = "";
        }

        public void OnAuthenticationCompleted(FacebookOAuthToken token)
        {
            var _token = token;
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            var fail = message;
        }

        async Task method()
        {
            var auth = new FacebookAuthenticator(
                "2063574180384090",
                "email", this);

            var authenticator = auth.GetAuthenticator();

            var viewController = authenticator.GetUI();
            _navigationStack = ((AppDelegate)_Managers[0]).Window.RootViewController;
            SafariServices.SFSafariViewController c = null;
            c = (SafariServices.SFSafariViewController)viewController;

            viewController = c;
            _navigationStack.PresentViewController(viewController, true, null);
            //if (result.Authenticated)
            //{
            //    ExecuteCallBack(new FingerPrint { IsValid = true });
            //}
            //else
            //{
            //    OnError(new string[] { ServiceKey + " Reported " + result.Status.ToString(), result.ErrorMessage });
            //}
        }
    }
}
