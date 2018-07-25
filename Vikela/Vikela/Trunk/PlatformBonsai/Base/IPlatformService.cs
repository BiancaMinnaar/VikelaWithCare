using System;

namespace Vikela.Trunk.Injection.Base
{
    public interface IPlatformService<T>
    {
        Action<T> ServiceCallBack { set; }
        Action<string[]> OnError { get; set; }
    }
}
