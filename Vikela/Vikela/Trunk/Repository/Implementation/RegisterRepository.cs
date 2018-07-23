using System;
using System.IO;
using System.Threading.Tasks;
using CorePCL;
using SQLite;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        IRegisterService<T> _Service;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Register(RegisterViewModel model, Action<T> completeAction)
        {
            //var serviceReturnModel = await _Service.Register(model);
            //completeAction(serviceReturnModel);
            await SetUserRecord(model);
        }

        public async Task SetUserRecord(RegisterViewModel model)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            var conn = new SQLiteAsyncConnection(databasePath);
            if (!await CheckUserRecord())
            {
                await conn.CreateTableAsync<User>();
                var s = await conn.InsertAsync(new User()
                {
                    FirstName = model.FisrtName,
                    LastName = model.LastName,
                    MobileNumber = model.MobileNumber,
                    UserPicture = model.UserPicture
                });
            }
        }

        private async Task<bool> CheckUserRecord()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            var conn = new SQLiteAsyncConnection(databasePath);

            var returnVal = await conn.ExecuteScalarAsync<int>("SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'User'");
            return returnVal > 0;
        }
    }
}