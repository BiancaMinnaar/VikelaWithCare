namespace Vikela.Trunk.Service.ReturnModel
{
    public abstract class DynamixServiceUserReturn<T>
    {
        public bool success { get; set; }
        public object errors { get; set; }
        public abstract T data { get; set; }
    }
    public abstract class DynamixServiceReturn<T>
    {
        public string id { get; set; }
		public string timeStamp { get; set; }
        public string streamId { get; set; }
        public string correlationId { get; set; }
        public abstract T body { get; set; }
        public string eventType { get; set; }
        public string version { get; set; }
        public string isReplay { get; set; }
    }
}
