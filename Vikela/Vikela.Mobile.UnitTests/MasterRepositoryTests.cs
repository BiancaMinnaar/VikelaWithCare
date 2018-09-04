using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vikela.Trunk.Repository.Implementation;

namespace Vikela.Mobile.UnitTests
{
    [TestClass]
    public class MasterRepositoryTests
    {
        [TestMethod]
        public void TestMasterInitialises()
        {
            Assert.AreNotEqual(null, MasterRepository.MasterRepo);
        }
    }
}
