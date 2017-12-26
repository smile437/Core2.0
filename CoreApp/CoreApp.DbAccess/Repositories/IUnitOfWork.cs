using System.Collections;

namespace CoreApp.DbAccess.Repositories
{
    interface IUnitOfWork
    {
        //IEnumerable<T> 
        void Save();
        void Dispose();
    }
}
