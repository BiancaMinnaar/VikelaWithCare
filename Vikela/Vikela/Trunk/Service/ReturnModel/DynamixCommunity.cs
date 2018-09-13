using CorePCL;

namespace Vikela.Trunk.Service.ReturnModel
{
    public class DynamixCommunityName : BaseViewModel
	{
        public string communityName{get;set;}
	}
    public class DynamixCommunity : BaseViewModel
    {
		public string success{get;set;}
		public DynamixCommunityName data{get;set;}
		public string errors{get;set;}
    }
}
