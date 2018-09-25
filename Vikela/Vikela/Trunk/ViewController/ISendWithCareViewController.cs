using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.ViewController
{
    public interface ISendWithCareViewController
    {
        List<PurchaseHistoryDetailViewModel> GetPurchaseDetailTileModels(Action OnClick);
        void PopToCover();
    }
}
