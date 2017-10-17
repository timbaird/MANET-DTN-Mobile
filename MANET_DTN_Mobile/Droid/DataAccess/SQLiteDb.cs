using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using MANET_DTN_Mobile.Controllers;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.Droid.DataAccess;

[assembly: Dependency(typeof(SQLiteDb))]

namespace MANET_DTN_Mobile.Droid.DataAccess
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MANET_DTN_SQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
