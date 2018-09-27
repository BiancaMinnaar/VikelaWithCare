using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.Repository
{
    public class MyCoverRepository<T> : ProjectBaseRepository, IMyCoverRepository<T>
        where T : BaseViewModel
    {
        public MyCoverRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public void Load(MyCoverViewModel model, Action detailClick, Action<object> trustedSourcesClick)
        {

            model.UserProfile = new ProfileModel()
            {
                FirstName = _MasterRepo.DataSource.User.FirstName,
                UserImage = new SelfieViewModel { Selfie = _MasterRepo.DataSource.User.UserPicture },
                LastName = _MasterRepo.DataSource.User.LastName,
                TrustedSources = new List<ContactDetailViewModel>()
            };
            model.DetailTiles = new List<ITableScrollItemModel>
            {
                GetPersonalDetailTileViewModel(detailClick),
                GetTrustedSourcesTileViewModel(trustedSourcesClick)
            };
        }

        public PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnCLick)
        {
            return new PersonalDetailViewModel()
            {
                Index = 0,
                Profile = new ProfileModel
                {
                    UserImage = new SelfieViewModel { Selfie = _MasterRepo.DataSource.User.UserPicture },
                    FirstName = _MasterRepo.DataSource.User.FirstName,
                    LastName = _MasterRepo.DataSource.User.LastName,
                    BarCode = _MasterRepo.DataSource.User.BarCode
                },
                ItemClickedCommand = new Command(OnCLick)
            };
        }

        internal List<ProfileModel> GetTrustesSourceProfileModelList()
        {
            if (_MasterRepo.DataSource.TrustedSources != null)
            {
                var TrustesSources = from source in _MasterRepo.DataSource.TrustedSources
                                     select new ProfileModel
                                     {
                                         UserID = source.UserID,
                                         FirstName = source.FirstName,
                                         LastName = source.LastName,
                                         CellPhoneNumber = source.CellNumber,
                                         IDNumber = source.IDNumber,
                                         UserImage = new SelfieViewModel { Selfie = source.UserPicture }
                                     };

                return TrustesSources.ToList();
            }
            else return null;
        }

        public TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick)
        {
            return new TrustedSourcesViewModel()
            {
                Index = 1,
                ThreeSources = GetTrustesSourceProfileModelList(),
                ItemClickedCommand = new Command(OnClick)
            };
        }

        public SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick)
        {
            return new SiyabongaViewModel()
            {
                Index = 0,
                TotalBenefits="R750",
                ClaimFreePeriod="9",
                ItemClickedCommand = new Command(OnClick)
            };
        }

        public Color GetRobotColor(DateTime startTime, DateTime endTime)
        {
            var monthsDifference = Math.Abs((startTime.Month - endTime.Month) + 12 * (startTime.Year - endTime.Year));
            if (monthsDifference == 0)
                return Color.Red;
            if (monthsDifference == 1)
                return Color.Orange;
            return Color.FromHex("#BBDE6B");
        }

        public ActiveCoverViewModel GetActiveCoverTileModelFromPolicy(PolicyModel model, Action<object> OnClick, int index)
        {
            CultureInfo ci = new CultureInfo("en-ZA");
            var timeCalc = TimeSpan.FromTicks(model.endDate.AddTicks(-model.startDate.Ticks).Ticks).Days;
            return new ActiveCoverViewModel
            {
                Index = index,
                TileColor = GetRobotColor(model.startDate, model.endDate),
                Title = model.name,
                CareAmount = (model.ensuredAmount/ 10000).ToString("C", ci),
                BeneficiaryImage = _MasterRepo.DataSource.DefaultBeneficiary.UserPicture,
                ItemClickedCommand = new Command(OnClick),
                TimeLeft = $"{timeCalc} Days Left"
            };
        }

        public List<ActiveCoverViewModel> GetActiveCoverTileModels(Action<object> OnClick)
        {
            if (_MasterRepo.DataSource.PolicyList != null && _MasterRepo.DataSource.PurchaseHistory != null)
            {
                var productCover = from policy in _MasterRepo.DataSource.PurchaseHistory
                           group policy.Cover by policy.Product into Transaction
                           select new {
                               Product=Transaction.Key,
                               CoverAmount=Transaction.Sum()
                           };
                var ProductStartDate = from policy in _MasterRepo.DataSource.PurchaseHistory
                                       group policy.StartDate by policy.Product into Transaction
                                       select new { product = Transaction.Key, StartDate = Transaction.Min() };
                var ProductEndDate = from policy in _MasterRepo.DataSource.PurchaseHistory
                                       group policy.EndDate by policy.Product into Transaction
                                       select new { product = Transaction.Key, EndDate = Transaction.Max() };
                var product = new PolicyModel
                {
                    name = productCover.FirstOrDefault().Product,
                    ensuredAmount = productCover.FirstOrDefault().CoverAmount,
                    startDate=ProductStartDate.FirstOrDefault().StartDate,
                    endDate=ProductEndDate.FirstOrDefault().EndDate
                };





                List < ActiveCoverViewModel > list = new List<ActiveCoverViewModel>();
                    list.Add(GetActiveCoverTileModelFromPolicy(product, OnClick, 1));

                return list;
            }
            return null;
        }
    }
}