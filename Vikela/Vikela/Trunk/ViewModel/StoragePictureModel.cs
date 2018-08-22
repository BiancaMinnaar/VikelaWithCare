using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel
{
    public class StoragePictureModel : ProjectBaseViewModel
    {
        public string UserID
        {
            get;
            set;
        }
        public string PictureStorageSASToken
        {
            get;
            set;
        }

        public byte[] UserPicture
        {
            get;
            set;
        }
    }
}
