namespace Vikela.Trunk.Service.ReturnModel
{
    public class GetUserReturnModel : DynamixServiceReturn<UserReturnModel>
    {
        public override UserReturnModel body { get; set; }
    }

    public class UserReturnModel
    {
        public string userId { get; set; }
        public string aadObjectId { get; set; }
        public string eMailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string idNumber { get; set; }
        public string mobileNumber { get; set; }
        public string barcode { get; set; }
    }
}
