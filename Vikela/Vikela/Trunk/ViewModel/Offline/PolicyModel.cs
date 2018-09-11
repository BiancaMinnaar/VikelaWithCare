using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class PolicyModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name {get;set;}
        public string startDate {get;set;}
        public string endDate {get;set;}
        public string ensuredAmount {get;set;}
        public string ownerContactId {get;set;}
        public string ownerProfileImageUrl {get;set;}
        public string beneficiaryContactId{get;set;}
        public string beneficiaryProfileImageUrl{get;set;}
    }
}
