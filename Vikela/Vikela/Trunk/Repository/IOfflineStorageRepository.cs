using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Vikela.Trunk.Repository
{
    public interface IOfflineStorageRepository
    {
        Task<CreateTableResult> CreateTableAsync<T>() where T:new();
        Task<int> InsertRecordAsync(object model);
        Task<int> UpdateRecordAsync(object model);
        Task<List<T>> QueryTableAsync<T>(string sql, params object[] args) where T : new();
        Task<int> DeleteRecordAsync(object model);
        Task<int> SelectScalarAsync(string sql, params object[] args);
    }
}
