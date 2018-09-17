using System;
namespace Vikela.Trunk.Service.ReturnModel
{
    public class DynamicTrustedSourceAddReturn : DynamixServiceReturn<DynamixTrustedSource>
    {
        public override DynamixTrustedSource body { get; set; }
    }
}
