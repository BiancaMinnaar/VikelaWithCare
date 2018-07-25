using System;

namespace Vikela.Trunk.Injection.Base
{
    public sealed class PlatformSingleton
    {
        static readonly Lazy<PlatformSingleton> lazy = new Lazy<PlatformSingleton>(
            () => new PlatformSingleton());
        public IPlatformModelBonsai Model { get; set; }
        public Action<IPlatformModelBonsai> ServiceCallBack;
        public BonsaiPlatformServiceRegistrationStructCollection PlatformServiceList { get; set; }
        public static PlatformSingleton Instance { get { return lazy.Value; } }

        private PlatformSingleton()
        {
            Model = new PlatformModelBonsai();
            PlatformServiceList = new BonsaiPlatformServiceRegistrationStructCollection();
        }
    }
}
