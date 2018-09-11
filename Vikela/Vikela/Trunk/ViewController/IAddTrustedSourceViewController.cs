using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IAddTrustedSourceViewController
    {
        void LoadTrustedSources();
        void LoadBeneficiary();
		void SaveBenificiary();
		Task SaveTrustedSourceAsync();
        void PopToCover();
    }
}
