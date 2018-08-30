using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository
    {
        ContactDetailViewModel GetTrustedContactDetailFromMaster();
        void UpdateMasterWithTrustedSource(ContactDetailViewModel model);
    }
}
