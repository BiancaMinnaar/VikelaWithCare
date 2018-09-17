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
                UserImage = _MasterRepo.DataSource.User.UserPicture,
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
                    UserImage = _MasterRepo.DataSource.User.UserPicture,
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
                                         UserImage = source.UserPicture
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
            if (monthsDifference > 1 && monthsDifference < 2)
                return Color.Orange;
            if (monthsDifference < 1)
                return Color.Red;
            return Color.FromHex("#BBDE6B");
        }

        public ActiveCoverViewModel GetActiveCoverTileModelFromPolicy(PolicyModel model, Action OnClick, int index)
        {
            var endDate = DateTime.Parse(model.endDate);
            var startDate = DateTime.Parse(model.startDate);
            var timeCalc = TimeSpan.FromTicks(endDate.AddTicks(-startDate.Ticks).Ticks).Days;
            CultureInfo ci = new CultureInfo("en-ZA");
            return new ActiveCoverViewModel
            {
                Index = index,
                TileColor = GetRobotColor(startDate, endDate),
                Title=model.name,
				CareAmount = (Double.Parse(model.ensuredAmount)/10000).ToString("C", ci),
                BeneficiaryImage = _MasterRepo.DataSource.DefaultBeneficiary.UserPicture,
                ItemClickedCommand = new Command(OnClick),
                TimeLeft = $"{timeCalc} Days Left"
            };
        }

        public List<ActiveCoverViewModel> GetActiveCoverTileModels(Action OnClick)
        {
            if (_MasterRepo.DataSource.PolicyList != null)
            {
                List<ActiveCoverViewModel> list = new List<ActiveCoverViewModel>();
                for (var count = 0; count < _MasterRepo.DataSource.PolicyList.Count; count++)
                    list.Add(GetActiveCoverTileModelFromPolicy(_MasterRepo.DataSource.PolicyList[count], OnClick, count));

                return list;
            }
            return null;
        }
    }
}