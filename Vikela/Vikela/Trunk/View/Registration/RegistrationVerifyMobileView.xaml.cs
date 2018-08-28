using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;

namespace Vikela.Implementation.View
{
    public partial class RegistrationVerifyMobileView : ProjectBaseContentPage<RegistrationVerifyMobileViewController, RegistrationVerifyMobileViewModel>
    {
        public RegistrationVerifyMobileView()
        {
            InitializeComponent();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_UpdateOTP_Event(object sender, EventArgs e)
        {
            await _ViewController.UpdateOTPAsync();
        }

        void On_Resend_Event(object sender, System.EventArgs e)
        {
        }
    }
}


