using System;

namespace Vikela.Trunk.Injection.Base
{
    public interface IPlatformModelBonsai : IPlatformModelBase
    {
        bool IsBackgroundAvailable { get; set; }
        bool IsInBackground { get; set; }
        Action HideLoaderFromPlatform { get; set; }
        Action ShowLoaderFromPlatform { get; set; }
    }
}
