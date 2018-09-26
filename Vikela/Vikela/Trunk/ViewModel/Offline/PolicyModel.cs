using System;
using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class PolicyModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid PolicyID { get; set; }
        public Guid storeId { get; set; }
        public string storeName { get; set; }
        public string name {get;set;}
        public DateTime startDate {get;set;}
        public DateTime endDate {get;set;}
        public double premiumAmount { get; set; }
        public double ensuredAmount {get;set;}
        public string ownerContactId {get;set;}
        public Guid beneficiaryContactId{get;set;}
    }
}
