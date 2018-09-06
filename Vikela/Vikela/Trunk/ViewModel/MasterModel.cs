using System.Collections.Generic;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Root.ViewModel
{
    public sealed class MasterModel
    {
        public bool IsRegistered { get { return User != null && User.OID != ""; } }
        public bool IsExistingClient { get; set; }
        public IPlatformModelBase PlatformModel { get; set; }
        public IEnumerable<PlatformServiceBonsai<IPlatformModelBase>> PlatformServiceList { get; }
        public UserModel User { get; set;}
		public ContactModel DefaultBeneficiary{ get; set;}
		public List<ContactModel> TrustedSources { get; set;}
        public int TrustedSourceEditIndex { get; set; }
        public List<ContactModel> Beneficiaries {get;set;}
    }
}

