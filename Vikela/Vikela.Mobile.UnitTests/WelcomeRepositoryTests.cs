using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;

namespace Vikela.Mobile.UnitTests
{
    [TestClass]
    public class WelcomeRepositoryTests
    {
        [TestMethod]
		public void TestValidExistingUserFlagWithOverrideTrue()
		{
            var repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };

            var masterRepoMock = repository.Create<IMasterRepository>();
            masterRepoMock.Setup(m => m.GetRegisteredUserOID()).Returns("d0b680d6-95c5-43e3-b036-c850a2696675");
            var registerRepoMock = repository.Create<IRegisterRepository<RegisterViewModel>>();
            registerRepoMock.Setup(m => m.GetDyn365RegisterViewModel()).Returns(new RegisterViewModel());
            var selfieRepoMock = repository.Create <ISelfieRepository <RegisterViewModel>>();
            var WelcomeRepo = new WelcomeRepository(masterRepoMock.Object, registerRepoMock.Object, selfieRepoMock.Object);

            Assert.AreEqual(true, WelcomeRepo.IsRegisteredUser("a body", true));
            repository.VerifyAll();
        }
    }
}
