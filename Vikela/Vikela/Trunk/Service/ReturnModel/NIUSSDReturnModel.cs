using Vikela.Implementation.ViewModel;
using CorePCL;
namespace Vikela.Trunk.Service.ReturnModel
{
    public class ussdReturnmodel :BaseViewModel
    {
        public string userId { get; set; }
        public string mobileNumber { get; set; }
        public string result { get; set; }
        public string clientResult { get; set; }
        public string eventType { get; set; }
    }

    public class NIUSSDReturnModel : DynamixServiceReturn<ussdReturnmodel>
    {
        public override ussdReturnmodel body { get; set; }
    }
}
