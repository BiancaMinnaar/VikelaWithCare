using System;

namespace Vikela.Trunk.Injection.Base
{
    public class PlatformModelBonsai : IPlatformModelBonsai
    {
        public bool IsBackgroundAvailable { get; set; }
        public bool IsInBackground { get; set; }

        public string ErrorMessage { get; }
        public Action HideLoaderFromPlatform { get; set; }
        public Action ShowLoaderFromPlatform { get; set; }

        public PlatformModelBonsai()
        {
            IsInBackground = false;
            IsBackgroundAvailable = false;
        }
    }
}
