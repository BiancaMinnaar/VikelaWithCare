using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class ContactDetailView : ProjectBaseContentView<ContactDetailViewController, ContactDetailViewModel>
    {
        public static readonly BindableProperty DataProperty = BindableProperty.Create(nameof(Data), typeof(ContactDetailViewModel), typeof(ContactDetailView));

        public ContactDetailViewModel Data
        {
            get
            {
                return (ContactDetailViewModel)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
                _ViewController.InputObject = value;
            }
        }

        public ContactDetailView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Load_Event(object sender, EventArgs e)
        {
            await _ViewController.Load();
        }
    }
}


