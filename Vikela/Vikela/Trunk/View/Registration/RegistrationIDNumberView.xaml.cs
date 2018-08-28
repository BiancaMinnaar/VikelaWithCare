using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;

namespace Vikela.Implementation.View
{
    public partial class RegistrationIDNumberView : ProjectBaseContentPage<RegistrationIDNumberViewController, RegistrationIDNumberViewModel>
    {
        public RegistrationIDNumberView()
        {
            InitializeComponent();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_UpdateIDNumber_Event(object sender, EventArgs e)
        {
            await _ViewController.UpdateIDNumberAsync();
        }
    }
}


