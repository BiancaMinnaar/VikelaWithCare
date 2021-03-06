﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;
using System.Linq;
using System.Threading.Tasks;
using Vikela.Trunk.Service;

namespace Vikela.Mobile.UnitTests
{
    [TestClass]
    public class RegisterRepositoryTests
    {
        const string TokenName = "Bianca Kourtney Minnaar";
        const string OID = "d0b680d6-95c5-43e3-b036-c850a2696675";
        const string ARToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJleHAiOjE1MzU1Mjg2MTgsIm5iZiI6MTUzNTUyNTAxOCwidmVyIjoiMS4wIiwiaXNzIjoiaHR0cHM6Ly9sb2dpbi5taWNyb3NvZnRvbmxpbmUuY29tL2Q5ZGIyMzBiLWU1ZDEtNDU5Ny05MzQ3LTE1MGNmODk4ZWM5YS92Mi4wLyIsInN1YiI6ImQwYjY4MGQ2LTk1YzUtNDNlMy1iMDM2LWM4NTBhMjY5NjY3NCIsImF1ZCI6IjhjMWY3MjIwLTFjYmQtNDVhZC1iNWU1LWIxY2ZkZmNiYjMzZCIsImlhdCI6MTUzNTUyNTAxOCwiYXV0aF90aW1lIjoxNTM1NTI1MDE4LCJuYW1lIjoiQmlhbmNhIEtvdXJ0bmV5IE1pbm5hYXIiLCJpZHAiOiJmYWNlYm9vay5jb20iLCJvaWQiOiJkMGI2ODBkNi05NWM1LTQzZTMtYjAzNi1jODUwYTI2OTY2NzQiLCJ0ZnAiOiJCMkNfMV92aWtlbGFfc2lnbl91cF9pbiJ9.ASO7xBNIqRGRUns_MA9fayVGK4LvWM23Hs3Z-bSuRohVJQLo6hBiqX9dh7fe1fOy1EMNnJ5S1gwHsk4IG1ctkBry4F4yOjlfgq7H4AorngF7-LVTZYVoq4F59GnZbpoqdS43wJjuBfVSdU196pa8NFaEr_kne-KROCkZCPHCj2VRK8K8thwrKMzRM74Ggt9hkcTh0PiJFoMu-dp47Vk9f2FPYbh_5aVvOUgqj69AzmqERKkl6gOeMR1Y5xaLF2c-T6udnNzjxP6ZdH8XkOh4rmnr0NIwcVkUq-HCVBmrOolccWnfzi9VvrlIjxjSnc3mXzaNlfsGPrUyW3HwGtML0Q";
        private static readonly byte[] pictureBytes = { 1, 2, 33, 44 };
        MockRepository repository;
        Mock<IMasterRepository> masterRepoMock;
        Mock<IRegisterService> registerService;
        Mock<IDynamixService> dynamixService;
        IRegisterRepository registerRepo;

        public RegisterRepositoryTests()
        {
            repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            masterRepoMock = repository.Create<IMasterRepository>();
            registerService = repository.Create<IRegisterService>();
            dynamixService = repository.Create<IDynamixService>();
            registerRepo = new RegisterRepository(masterRepoMock.Object, registerService.Object, dynamixService.Object);
        }

        private RegisterViewModel getSimpleRegisterModel()
        {
            return new RegisterViewModel()
            {
                FirstName = TokenName
            };
        }

        [TestMethod]
        public void TestGetUserFromARTokenReturnsRegisterModel()
        {
            masterRepoMock.Setup(m => m.GetRegisteredUserOID()).Returns(OID);
            var testARToken = ARToken;
            var testI = new AzureAuthenticationResult()
            {
                IdToken = testARToken
            };

            Assert.AreEqual(TokenName, registerRepo.GetUserFromARToken(testI).FirstName);
		}

        [TestMethod]
        public void TestCallForImageBlobStorageSASAsyncSetsSASToken()
        {
            registerService.Setup(s => s.RegisterForSASAsync(It.IsAny<RegisterViewModel>()));

            registerRepo.CallForImageBlobStorageSASAsync(getSimpleRegisterModel());

            repository.VerifyAll();

        }

        [TestMethod]
        public void TestSetUserRecordWithRegisterViewModelAsyncSetsUserDataSource()
        {
            var regModel = new RegisterViewModel()
            {
                FirstName = TokenName,
                LastName = "Minnaar",
                MobileNumber = "0835666566",
                OID = OID,
                UserPicture = pictureBytes,
                TokenID = ARToken,
                PictureStorageSASToken = "Picture SAS"
            };
            var actionModel = new UserModel()
            {
                FirstName = TokenName,
                LastName = "Minnaar",
                MobileNumber = "0835666566",
                OID = OID,
                UserPicture = pictureBytes,
                TokenID = ARToken,
                PictureStorageSASToken = "Picture SAS"
            };
            masterRepoMock.Setup(m => m.SetUserRecordAsync(It.Is<UserModel>(a => a.FirstName == actionModel.FirstName)));

            registerRepo.SetUserRecordWithRegisterViewModelAsync(regModel);

            repository.VerifyAll();
        }

        [TestMethod]
        public void TestGetUserWithOIDAsyncTranslatesModel()
        {
            var regModel = new RegisterViewModel()
            {
                FirstName = TokenName,
                LastName = "Minnaar",
                MobileNumber = "0835666566",
                OID = OID,
                UserPicture = pictureBytes,
                TokenID = ARToken,
                PictureStorageSASToken = "Picture SAS"
            };
            dynamixService.Setup(s => s.GetUserWithOIDAsync(It.Is<RegisterViewModel>(a => a.FirstName == TokenName)));
            registerRepo.GetUserWithOIDAsync(regModel);
            repository.VerifyAll();
        }
    }
}
