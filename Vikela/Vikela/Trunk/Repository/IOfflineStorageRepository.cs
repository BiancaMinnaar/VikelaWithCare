using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Vikela.Trunk.Repository
{
    public interface IOfflineStorageRepository
    {
        Task<CreateTablesResult> CreateTable<T>() where T:new();
        Task<int> InsertRecord(object model);
        Task<int> UpdateRecord(object model);
        Task<List<T>> QueryTable<T>(string sql, params object[] args) where T : new();
        Task<int> DeleteRecord(object model);
        Task<int> SelectScalar(string sql, params object[] args);
    }
}
