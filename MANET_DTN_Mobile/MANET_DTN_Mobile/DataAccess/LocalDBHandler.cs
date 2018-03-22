using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MANET_DTN_Mobile.Models;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace MANET_DTN_Mobile.DataAccess
{
    public interface ILocalDBHandler
    {
        // for syncing
        List<Item> GetAllItems();
        List<RemoveFlag> GetAllFlags();

        // for use on mobile app
        ObservableCollection<Item> GetData();
        ObservableCollection<Item> GetReceivedMessages();
        ObservableCollection<Item> GetSentMessages();

        // for logging
        void LogSyncStarted();
        void LogSyncComplete();
        DateTime GetLastSyncDateTime(string pThrowboxId);

        // CRUD - individual items / flags
        void SaveItem(Item pItem);
        void SaveFlag(RemoveFlag pFlag);
        void DeleteItem(RemoveFlag pFlag);
    }

    public class LocalDBHandler : ILocalDBHandler
    {
        SQLiteAsyncConnection connection;
        string nodeId = NodeData.GetNodeId();

        SyncLog log;

        public LocalDBHandler()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        // methods used for syncing
        public List<Item> GetAllItems()
        {
            var result = connection.Table<Item>().ToListAsync().Result;
            return result;
        }

        public List<RemoveFlag> GetAllFlags()
        {
            var result = connection.Table<RemoveFlag>().ToListAsync().Result;
            return result;
        }


        // methods used for displaying in mobile app

        public ObservableCollection<Item> GetData()
        {
            var result = connection.Table<Item>().Where(t => t.ItemType.Equals("DATA")).ToListAsync().Result;
            return new ObservableCollection<Item>(result);
        }

        public ObservableCollection<Item> GetReceivedMessages()
        {
            var table = connection.Table<Item>();
            var result = table.Where(t => t.ItemType.Equals("MESSAGE") &&
                                                        t.RecipientId.Equals(nodeId)).ToListAsync().Result;
            return new ObservableCollection<Item>(result);
        }

        public ObservableCollection<Item> GetSentMessages()
        {
            var table = connection.Table<Item>();
            var result = table.Where(t => t.ItemType.Equals("MESSAGE") && 
                                                        t.OriginatorId.Equals(nodeId)).ToListAsync().Result;
            return new ObservableCollection<Item>(result);
        }

        // logging methods

        public void LogSyncStarted()
        {
            log = new SyncLog(NodeData.GetNodeId(), DateTime.Now);
            connection.InsertAsync(log);
        }

        public void LogSyncComplete()
        {
            log.SetDateTimeComplete(DateTime.Now);
            connection.UpdateAsync(log);
        }

        public DateTime GetLastSyncDateTime(string pThrowboxId)
        {
            var table = connection.Table<SyncLog>();
            var syncList = table.Where(x => x.SyncNodeId.Equals(pThrowboxId)).OrderByDescending(x => x.DateTimeComplete).ToListAsync().Result;
            if (syncList.Count > 0)
            {
                return syncList[0].DateTimeStart;
            }
            else
            {
                return new DateTime(2000, 1, 1);
            }
        }

        // Individual CRUD methods


        public async void SaveItem(Item pItem)
        {
            await connection.InsertOrReplaceAsync(pItem);
        }

        public async void SaveFlag(RemoveFlag pFlag)
        {
            await connection.InsertOrReplaceAsync(pFlag);
        }

        public async void DeleteItem(RemoveFlag pFlag)
        {

            //await connection.DeleteAsync(item);
            throw new NotImplementedException();
        }

        // database creation


        public async static void CreateDatabaseIfNeeded()
        {
            SQLiteAsyncConnection connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            //await connection.DropTableAsync<Item>();
            //await connection.DropTableAsync<RemoveFlag>();
            //await connection.DropTableAsync<TransferLog>();
            //await connection.DropTableAsync<SyncLog>();


            await connection.CreateTableAsync<Item>();
            await connection.CreateTableAsync<RemoveFlag>();
            await connection.CreateTableAsync<TransferLog>();
            await connection.CreateTableAsync<SyncLog>();

            if (!Application.Current.Properties.ContainsKey("sequence"))
            { Application.Current.Properties["sequence"] = 1; }

            // TODO LocalDBHandler : this clears out existing items
            //await connection.ExecuteAsync("delete from item");
        }
    }
}
