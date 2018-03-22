using System;
using System.Collections.Generic;
using System.Linq;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;
using Xamarin.Forms;


namespace MANET_DTN_Mobile.Controllers
{
    public interface ISyncController{
        bool SyncRequired();
        void Sync();
    }

    public class SyncController:ISyncController
    {

        private ILocalDBHandler db;
        private IAPIClient api;

        public SyncController()
        {
            db = new LocalDBHandler();
            api = new APIClient();
        }

        public bool SyncRequired()
        {
            var throwBoxId = api.GetThrowBoxId().Result;

            var lastSync = db.GetLastSyncDateTime(throwBoxId);
            var resyncThreshold = NodeData.GetMinsBetweenResync();
            var targetDateTime = lastSync.AddMinutes(resyncThreshold);

            // check if last sync was longer ago than the resync threshold
            return targetDateTime < DateTime.Now;
        }

        public void Sync()
        {
            db.LogSyncStarted();

            SyncRemoveFlags();

            SyncItems();

            db.LogSyncComplete();
        }

        private void SyncRemoveFlags()
        {
            // get list of remove flag ID's from throwbox
            List<RemoveFlagID> remoteFlagIds = api.GetRemoveFlagIds().Result;
            List<RemoveFlag> localFlags = db.GetAllFlags();
         
            int i;
            List<RemoveFlag> temp;

            // loop through each 
            for (i = 0; i < remoteFlagIds.Count;i++)
            {
                temp = localFlags.Where(x => x.ItemId == remoteFlagIds[i].ItemId).ToList();

                if (temp.Count() < 1){
                    // flag exists in remote but not in local
                    // pull it from remote
                    var flag = api.PullRemoveFlag(remoteFlagIds[i].ItemId).Result;
                    // save it to local
                    db.SaveFlag(flag);
                    // delete 
                    db.DeleteItem(flag);

                }
                else{
                    // flag already exists in both local and remote
                    // remove it from localList
                    localFlags = localFlags.Except(temp).ToList();
                }
            }

            for (i = 0; i < localFlags.Count(); i++)
            {
                // for each local flag not in remote db push it through
                api.PushRemoveFlag(localFlags[i]);
            }
        }

        private void SyncItems()
        {
            List<ItemID> remoteItemIds = api.GetItemIds().Result;
            List<Item> localItems = db.GetAllItems();

            int i;
            List<Item> temp;

            // loop through each 
            for (i = 0; i < remoteItemIds.Count; i++)
            {
                temp = localItems.Where(x => x.ItemId == remoteItemIds[i].ItemId).ToList();

                if (temp.Count() < 1)
                {
                    // flag exists in remote but not in local
                    // pull it from remote
                    var item = api.PullItem(remoteItemIds[i].ItemId).Result;
                    // save it to local
                    db.SaveItem(item);
                }
                else
                {
                    // flag already exists in both local and remote
                    // remove it from localList
                    localItems = localItems.Except(temp).ToList();
                }
            }

            for (i = 0; i < localItems.Count(); i++)
            {
                // for each local flag not in remote db push it through
                api.PushItem(localItems[i]);
            }
        }
    }
}
