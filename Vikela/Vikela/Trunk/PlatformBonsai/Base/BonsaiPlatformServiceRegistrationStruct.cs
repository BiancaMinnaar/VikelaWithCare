using System.Collections.Generic;

namespace Vikela.Trunk.Injection.Base
{
    public class BonsaiPlatformServiceRegistrationStructCollection 
        : Dictionary<string, BonsaiPlatformServiceRegistrationStruct>
    {
        public void Add<T>(params object[] managers)
            where T : PlatformServiceBonsai<IPlatformModelBase>, new()
        {
            BonsaiPlatformServiceRegistrationStruct registrationStruct =
                new BonsaiPlatformServiceRegistrationStruct
                {
                    PlatformHarness = new T()
                };
            if (!ContainsKey(registrationStruct.PlatformHarness.ServiceKey))
            {
                registrationStruct.PlatformHarness.SetManagers(managers);
                Add(registrationStruct.PlatformHarness.ServiceKey, registrationStruct);
            }
        }
    }

    public struct BonsaiPlatformServiceRegistrationStruct
    {
        public PlatformServiceBonsai<IPlatformModelBase> PlatformHarness { get; set; }
    }
}
