using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewController
{
    public class SendWithCareViewController : ProjectBaseViewController<SendWithCareViewModel>, ISendWithCareViewController
    {
        ISendWithCareRepository _Reposetory;
        ISendWithCareService _Service;

        public override void SetRepositories()
        {
            _Service = new SendWithCareService((U, C, A) => 
                                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, C, A));
            _Reposetory = new SendWithCareRepository(_MasterRepo, _Service);
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public List<PurchaseHistoryDetailViewModel> GetPurchaseDetailTileModels(Action OnClick)
        {
            return _Reposetory.GetPurchaseDetailTileModels(OnClick);
        }
    }
}