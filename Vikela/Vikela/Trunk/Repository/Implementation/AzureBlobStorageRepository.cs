using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CorePCL;
using Microsoft.WindowsAzure.Storage.Blob;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel;

namespace Vikela.Trunk.Repository.Implementation
{
    public class AzureBlobStorageRepository<T> : ProjectBaseRepository, IAzureBlobStorageRepository
        where T : BaseViewModel
    {
        public AzureBlobStorageRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public void DeleteBlob()
        {
            throw new NotImplementedException();
        }

        public async Task GetBlobImageAsync(StoragePictureModel model)
        {
            var uri = new Uri(model.PictureStorageSASToken.Trim('\"'));
            CloudBlobContainer container = new CloudBlobContainer(uri);
            CloudBlockBlob blob = container.GetBlockBlobReference("Picture1.jpg");

            using (var msRead = new MemoryStream())
            {
                msRead.Position = 0;
                using (msRead)
                {
                    await blob.DownloadToStreamAsync(msRead);
                }
                msRead.Flush();
                model.UserPicture = msRead.GetBuffer();
            }
        }

        public ICloudBlob GetBlobImage(string name)
        {
            throw new NotImplementedException();
        }

        public List<ICloudBlob> GetBlobs()
        {
            throw new NotImplementedException();
        }

        public async Task SaveBlobImageAsync(StoragePictureModel model)
        {
            var uri = new Uri(model.PictureStorageSASToken.Trim('\"'));
            CloudBlobContainer container = new CloudBlobContainer(uri);
            CloudBlockBlob blob = container.GetBlockBlobReference("Picture1.jpg");
            await blob.UploadFromByteArrayAsync(model.UserPicture, 0, model.UserPicture.Length);
        }

        public void SaveBlobImage()
        {
            throw new NotImplementedException();
        }
    }
}
