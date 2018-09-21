using CorePCL;
namespace Vikela.Trunk.Service.ReturnModel
{
    public class DynamixPolicy : BaseViewModel
    {
        public string name {get;set;}
        public string startDate {get;set;}
        public string endDate {get;set;}
        public decimal ensuredAmount {get;set;}
        public string ownerContactId {get;set;}
        public string ownerProfileImageUrl {get;set;}
        public string beneficiaryContactId{get;set;}
        public string beneficiaryProfileImageUrl{get;set;}
    }
}
