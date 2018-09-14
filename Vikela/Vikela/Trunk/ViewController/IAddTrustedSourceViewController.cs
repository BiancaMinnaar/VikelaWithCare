using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IAddTrustedSourceViewController
    {
        void LoadTrustedSourcesAsync();
        void LoadBeneficiaryAsync();
        Task SaveBenificiaryAsync();
		Task SaveTrustedSourceAsync();
        void PopToCover();
    }
}
