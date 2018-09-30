using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class MyCommunityViewModel : ProjectBaseViewModel
    {

        private string communityName;
        private string userID;
        public string CommunityName { get => communityName; set { communityName = value; OnPropertyChanged("CommunityName"); } }
        public string UserID { get => userID; set { userID = value; OnPropertyChanged("UserID"); } }
        public byte[] Selfie { get; set; }

    }
}