using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class EditProfileView : ProjectBaseContentPage<EditProfileViewController, EditProfileViewModel>
    {
        public EditProfileView()
        {
            InitializeComponent();
            _ViewController.Load();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Edit_Event(object sender, EventArgs e)
        {
            await _ViewController.Edit();
        }
    }
}


