using System;
using System.Linq;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using System.Collections.Generic;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.Repository
{
    public class PurchaseDetailsRepository : ProjectBaseRepository, IPurchaseDetailsRepository
    {
        IPurchaseDetailsService _Service;

        public PurchaseDetailsRepository(IMasterRepository masterRepository, IPurchaseDetailsService service)
            : base(masterRepository)
        {
            _Service = service;
        }


    }
}