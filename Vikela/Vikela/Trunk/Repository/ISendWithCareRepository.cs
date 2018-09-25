using System;
using System.Collections.Generic;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.Repository
{
    public interface ISendWithCareRepository
    {
        List<PurchaseHistoryDetailViewModel> GetPurchaseDetailTileModels(Guid beneficiaryID, Action<object> OnClick);
    }
}
