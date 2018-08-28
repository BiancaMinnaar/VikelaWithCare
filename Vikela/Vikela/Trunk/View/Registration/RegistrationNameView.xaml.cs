using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;

namespace Vikela.Implementation.View
{
    public partial class RegistrationNameView : ProjectBaseContentPage<RegistrationNameViewController, RegistrationNameViewModel>
    {
        public RegistrationNameView()
        {
            InitializeComponent();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_UpdateName_Event(object sender, EventArgs e)
        {
            await _ViewController.UpdateNameAsync();
        }
    }
}


