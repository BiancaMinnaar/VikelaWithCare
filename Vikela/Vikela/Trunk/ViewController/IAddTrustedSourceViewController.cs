using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IAddTrustedSourceViewController
    {
        void LoadTrustedSources();
        void LoadBeneficiary();
        Task SaveBenificiaryAsync();
		Task SaveTrustedSourceAsync();
        void PopToCover();
    }
}
