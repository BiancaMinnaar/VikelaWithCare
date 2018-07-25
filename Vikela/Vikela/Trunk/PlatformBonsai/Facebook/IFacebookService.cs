using Vikela.Trunk.Injection.Base;

namespace Vikela.Trunk.PlatformBonsai.Facebook
{
    public interface IFacebookService<T> : IPlatformService<T> where T : IPlatformModelBase
    {
    }
}
