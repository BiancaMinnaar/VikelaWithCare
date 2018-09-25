using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using System.Collections.Generic;
using Vikela.Trunk.ViewModel.Controlls;
using System.Linq;
using Xamarin.Forms;

namespace Vikela.Implementation.Repository
{
    public class SendWithCareRepository : ProjectBaseRepository, ISendWithCareRepository
    {
        ISendWithCareService _Service;

        public SendWithCareRepository(IMasterRepository masterRepository, ISendWithCareService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public List<PurchaseHistoryDetailViewModel> GetPurchaseDetailTileModels(Guid beneficiaryID, Action OnClick)
        {
            var history = from detail in _MasterRepo.DataSource.PurchaseHistory
                          where detail.BeneficiaryID==beneficiaryID
                          select new PurchaseHistoryDetailViewModel
                          {
                              Index = 0,
                              HistoryDetails = detail,
                              ItemClickedCommand = new Command(OnClick)
                          };
            return history.ToList();
        }
    }
}