using Vikela.Implementation.ViewModel;
using CorePCL;
namespace Vikela.Trunk.Service.ReturnModel
{
    public class NIUSSDReturnModel : DynamixServiceReturn<NIUSSDViewModel>
    {
        public override NIUSSDViewModel body { get; set; }
        public string userId {get;set;}
        public string mobileNumber {get;set;}
        public string result{get;set;}
        public string clientResult{get;set;}
        public string eventType {get;set;}
    }
}
