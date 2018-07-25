using System.Collections.Generic;
using Vikela.Trunk.Injection.Base;

namespace Vikela.Root.ViewModel
{
    public sealed class MasterModel
    {
        public bool Authenticated { get; set; }
        public bool IsExistingClient { get; set; }
        public IPlatformModelBase PlatformModel { get; set; }
        public IEnumerable<PlatformServiceBonsai<IPlatformModelBase>> PlatformServiceList { get; }
    }
}

