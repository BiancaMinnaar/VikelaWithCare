using System;
using System.Threading.Tasks;
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
                BindingContext = _ViewController.InputObject;
            }
        }

        public ContactDetailView()
        {
            InitializeComponent();
            //_ViewController.Load();

        }

        protected override void SetSVGCollection()
        {
        }

        public void SelectPictureTapped(object sender, EventArgs args)
        {
            _ViewController.CapturePhoto();
        }
     }
}


