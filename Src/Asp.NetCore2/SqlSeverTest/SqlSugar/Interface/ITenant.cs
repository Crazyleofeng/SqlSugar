using System;
using System.Threading.Tasks;

namespace SqlSugar
{
    public interface ITenant
    {
        void BeginTran();
        void CommitTran();
        void RollbackTran();
        void ChangeDatabase(dynamic configId);
        void ChangeDatabase(Func<ConnectionConfig, bool> changeExpression);
        DbResult<bool> UseTran(Action action, Action<Exception> errorCallBack = null);
        Task<DbResult<bool>> UseTranAsync(Action action, Action<Exception> errorCallBack = null);
        DbResult<T> UseTran<T>(Func<T> action, Action<Exception> errorCallBack = null);

        Task<DbResult<T>> UseTranAsync<T>(Func<T> action, Action<Exception> errorCallBack = null);
        void AddConnection(ConnectionConfig connection);
        SqlSugarProvider GetConnection(dynamic configId);

        void Close();
        void Open();
    }
}
