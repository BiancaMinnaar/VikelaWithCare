using System;
using System.Collections.Generic;

namespace Vikela.Trunk.Injection.Base
{
    public sealed class PlatformBonsai : PlatformServiceBonsai<IPlatformModelBonsai>, IPlatformBonsai<IPlatformModelBonsai>
    {
        public new Action<IPlatformModelBonsai> ServiceCallBack
        {
            get => PlatformSingleton.Instance.ServiceCallBack;
            set => PlatformSingleton.Instance.ServiceCallBack = value;
        }

        public IEnumerable<BonsaiPlatformServiceRegistrationStruct> GetBonsaiServices
            => PlatformSingleton.Instance.PlatformServiceList.Values;

        public static void NotifyOfBackgroundChange(IPlatformModelBonsai model)
        {
            PlatformSingleton.Instance.Model.IsBackgroundAvailable = model.IsBackgroundAvailable;
            PlatformSingleton.Instance.Model.IsInBackground = model.IsInBackground;
            PlatformSingleton.Instance.ServiceCallBack?.Invoke(PlatformSingleton.Instance.Model);
        }
    }
}
