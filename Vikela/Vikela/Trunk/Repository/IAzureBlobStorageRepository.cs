using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using Vikela.Trunk.ViewModel;

namespace Vikela.Trunk.Repository
{
    public interface IAzureBlobStorageRepository
    {
        List<ICloudBlob> GetBlobs();
        Task GetBlobImageAsync(StoragePictureModel model);
        Task SaveBlobImageAsync(StoragePictureModel model);
        void DeleteBlob();
    }
}
