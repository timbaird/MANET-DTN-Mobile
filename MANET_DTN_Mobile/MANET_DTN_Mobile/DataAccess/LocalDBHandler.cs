using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Models;


namespace MANET_DTN_Mobile.DataAccess
{
    public interface ILocalDBHandler
    {
        void DeleteItem(Item pItem);
        List<Item> GetData();
        Item GetItemById(string pItemId);
        List<Item> GetItemIdsToPush(List<Item> pInputList);
        List<Item> GetItemIdsToPull(List<Item> pInputList);
        DateTime GetLastSync(string pThrowboxId);
        List<Item> GetReceivedMessages();
        List<Item> GetSentMessages();
        RemoveFlag GetRemoveFlagById(string pFlagId);
        List<RemoveFlag> GetRemoveFlagIdsToPush(List<RemoveFlag> pInputList);
        List<RemoveFlag> GetRemoveFlagIdsToPull(List<RemoveFlag> pInputList);
        void LogSyncStarted();
        void LogSyncComplete();
        void SaveItem(Item pItem);
        void SaveRemoveFlag(RemoveFlag pFlag);

    }

    public class LocalDBHandler : ILocalDBHandler
    {
        public LocalDBHandler(string pPathToDB)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(string pItemId)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItemIdsToPull(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItemIdsToPush(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetData()
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastSync(string pThrowboxId)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetReceivedMessages()
        {
            throw new NotImplementedException();
        }

        public RemoveFlag GetRemoveFlagById(string pFlagId)
        {
            throw new NotImplementedException();
        }

        public List<RemoveFlag> GetRemoveFlagIdsToPull(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<RemoveFlag> GetRemoveFlagIdsToPush(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetSentMessages()
        {
            throw new NotImplementedException();
        }

        public void LogSyncComplete()
        {
            throw new NotImplementedException();
        }

        public void LogSyncStarted()
        {
            throw new NotImplementedException();
        }

        public void SaveItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public void SaveRemoveFlag(RemoveFlag pFlag)
        {
            throw new NotImplementedException();
        }
    }
}
