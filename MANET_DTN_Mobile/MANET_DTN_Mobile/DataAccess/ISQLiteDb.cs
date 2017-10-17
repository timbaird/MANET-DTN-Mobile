using System;
using SQLite;

namespace MANET_DTN_Mobile.DataAccess
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
