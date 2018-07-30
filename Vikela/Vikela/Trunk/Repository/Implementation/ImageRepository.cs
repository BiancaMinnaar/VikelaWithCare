using System.IO;
using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;

namespace Vikela.Trunk.Repository.Implementation
{
    public class ImageRepository : ProjectBaseRepository, IImageRepository
    {
        public ImageRepository(IMasterRepository masterRepository) : base(masterRepository)
        {}

        private byte[] getPhotoBytes(Stream photoStream)
        {
            using (var mStream = new MemoryStream())
            {
                photoStream.CopyTo(mStream);
                photoStream.Flush();
                return mStream.ToArray();
            }
        }

        public async Task<byte[]> GetPhotoBinary(Stream photoStream)
        {
            Task<byte[]> mytask = Task.Run(() =>
            {
                return getPhotoBytes(photoStream);
            });

            return await mytask;
        }
    }
}
