using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MANET_DTN_Mobile.Models;
using SQLite;
using Xamarin.Forms;


namespace MANET_DTN_Mobile.DataAccess
{
    public interface ILocalDBHandler
    {
        void DeleteItem(Item pItem);
        ObservableCollection<Item> GetData();
        Item GetItemById(string pItemId);
        List<string> GetItemIdsToPush(List<Item> pInputList);
        List<string> GetItemIdsToPull(List<Item> pInputList);
        DateTime GetLastSync(string pThrowboxId);
        ObservableCollection<Item> GetReceivedMessages();
        ObservableCollection<Item> GetSentMessages();

        RemoveFlag GetRemoveFlagById(string pFlagId);
        List<string> GetRemoveFlagIdsToPush(List<RemoveFlag> pInputList);
        List<string> GetRemoveFlagIdsToPull(List<RemoveFlag> pInputList);
        void LogSyncStarted();
        void LogSyncComplete();
        void SaveItem(Item pItem);
        void SaveRemoveFlag(RemoveFlag pFlag);

    }

    public class LocalDBHandler : ILocalDBHandler
    {
        SQLiteAsyncConnection connection;
       // ObservableCollection<Item> receivedMessages;
       // ObservableCollection<Item> sentMessages;
       // ObservableCollection<Item> data;
        string nodeId = NodeData.GetNodeId();


        public LocalDBHandler()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async static void CreateDatabaseIfNeeded()
        {
            SQLiteAsyncConnection connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            await connection.CreateTableAsync<Item>();
            await connection.CreateTableAsync<RemoveFlag>();
            await connection.CreateTableAsync<TransferLog>();
            await connection.CreateTableAsync<SyncLog>();

            if (!Application.Current.Properties.ContainsKey("sequence"))
            { Application.Current.Properties["sequence"] = 1; } 

            await connection.ExecuteAsync("delete from item");

        }

        public void DeleteItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Item> GetData()
        {
            {
                var result = connection.Table<Item>().Where(t => t.ItemType.Equals("DATA")).ToListAsync().Result;
                return new ObservableCollection<Item>(result);
            }
        }

        public Item GetItemById(string pItemId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetItemIdsToPull(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<string> GetItemIdsToPush(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastSync(string pThrowboxId)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Item> GetReceivedMessages()
        {
            var result = connection.Table<Item>().Where(t => t.ItemType.Equals("MESSAGE") && 
                                                        t.RecipientId.Equals(nodeId)).ToListAsync().Result;
            return new ObservableCollection<Item>(result);
        }

        public RemoveFlag GetRemoveFlagById(string pFlagId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRemoveFlagIdsToPull(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRemoveFlagIdsToPush(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Item> GetSentMessages()
        {
            var result = connection.Table<Item>().Where(t => t.ItemType.Equals("MESSAGE") && 
                                                        t.OriginatorId.Equals(nodeId)).ToListAsync().Result;
            return new ObservableCollection<Item>(result);
        }

        public void LogSyncComplete()
        {
            throw new NotImplementedException();
        }

        public void LogSyncStarted()
        {
            throw new NotImplementedException();
        }

        public async void SaveItem(Item pItem)
        {
            await connection.InsertAsync(pItem);
        }

        public void SaveRemoveFlag(RemoveFlag pFlag)
        {
            throw new NotImplementedException();
        }
    }
}
