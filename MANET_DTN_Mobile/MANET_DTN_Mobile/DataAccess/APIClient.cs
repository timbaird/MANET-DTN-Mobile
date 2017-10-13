using System;
using System.Collections.Generic;
using MANET_DTN_Mobile.Models;

namespace MANET_DTN_Mobile.DataAccess
{

    public interface IAPIClient{
        List<string> GetItemIds();
        List<string> GetRemoveFlagIds();
        Item PullItem(string pItemId);
        RemoveFlag PullRemoveFlag(string pFlagId);
        void PushItem(Item pItem);
        void PushRemoveFlag(RemoveFlag pFlag);
    }


    public class APIClient: IAPIClient
    {
        private string url;

        public APIClient(string pURL)
        {
        }

        public List<string> GetItemIds()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRemoveFlagIds()
        {
            throw new NotImplementedException();
        }

        public Item PullItem(string pItemId)
        {
            throw new NotImplementedException();
        }

        public RemoveFlag PullRemoveFlag(string pFlagId)
        {
            throw new NotImplementedException();
        }

        public void PushItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public void PushRemoveFlag(RemoveFlag pFlag)
        {
            throw new NotImplementedException();
        }
    }
}
