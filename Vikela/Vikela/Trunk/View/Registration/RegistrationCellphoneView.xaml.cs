using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;

namespace Vikela.Implementation.View
{
    public partial class RegistrationCellphoneView : ProjectBaseContentPage<RegistrationCellphoneViewController, RegistrationCellphoneViewModel>
    {
        public RegistrationCellphoneView()
        {
            InitializeComponent();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_UpdateCellPhone_Event(object sender, EventArgs e)
        {
            await _ViewController.UpdateCellPhoneAsync();
        }
    }
}


