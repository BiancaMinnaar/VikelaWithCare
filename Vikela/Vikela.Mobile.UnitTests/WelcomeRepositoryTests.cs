using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Trunk.Service;

namespace Vikela.Mobile.UnitTests
{
    [TestClass]
    public class WelcomeRepositoryTests
    {
        const string OID = "d0b680d6-95c5-43e3-b036-c850a2696675";
        MockRepository repository;
        Mock<IMasterRepository> masterRepoMock;
        Mock<IRegisterService> registerServiceMock;
        Mock<IRegisterRepository> registerRepoMock;
        Mock<ISelfieRepository<RegisterViewModel>> selfieRepoMock;
        WelcomeRepository WelcomeRepo;

        public WelcomeRepositoryTests()
        {
            repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            masterRepoMock = repository.Create<IMasterRepository>();
            registerRepoMock = repository.Create<IRegisterRepository>();
            selfieRepoMock = repository.Create<ISelfieRepository<RegisterViewModel>>();
            WelcomeRepo = new WelcomeRepository(masterRepoMock.Object, registerRepoMock.Object, selfieRepoMock.Object);
        }

        [TestMethod]
		public void TestValidExistingUserFlagWithOverrideTrue()
		{
            masterRepoMock.Setup(m => m.GetRegisteredUserOID()).Returns("d0b680d6-95c5-43e3-b036-c850a2696675");
            registerRepoMock.Setup(m => m.GetDyn365RegisterViewModel()).Returns(new RegisterViewModel());

            Assert.AreEqual(true, WelcomeRepo.IsRegisteredUser("a body", true));
            repository.VerifyAll();
        }

        [TestMethod]
        public void TestIsRegisteredUserFlagWithNotFound()
        {
            masterRepoMock.Setup(m => m.GetRegisteredUserOID()).Returns("d0b680d6-95c5-43e3-b036-c850a2696675");
            registerRepoMock.Setup(m => m.GetDyn365RegisterViewModel()).Returns(new RegisterViewModel());

            Assert.AreEqual(false, WelcomeRepo.IsRegisteredUser("Not Found"));
            repository.VerifyAll();
        }

        [TestMethod]
        public void TestRegisterOrShowProfileShowRegisterForNewUser()
        {

        }
    }
}
