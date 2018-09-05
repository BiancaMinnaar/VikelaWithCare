using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;

namespace Vikela.Implementation.View
{
    public partial class RegistrationEmailView : ProjectBaseContentPage<RegistrationEmailViewController, RegistrationEmailViewModel>
    {
        public RegistrationEmailView()
        {
            InitializeComponent();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_UpdateEmail_EventAsync(object sender, EventArgs e)
        {
            await _ViewController.UpdateEmailAsync();
        }
    }
}


