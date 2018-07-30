using System.IO;
using System.Threading.Tasks;

namespace Vikela.Trunk.Repository
{
    public interface IImageRepository
    {
        Task<byte[]> GetPhotoBinary(Stream photoStream);
    }
}
