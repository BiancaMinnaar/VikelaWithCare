using SQLite;

namespace Vikela.Trunk.Repository
{
    public interface IOfflineStorageRepository
    {
        SQLiteAsyncConnection Connection
        { get; }
    }
}
