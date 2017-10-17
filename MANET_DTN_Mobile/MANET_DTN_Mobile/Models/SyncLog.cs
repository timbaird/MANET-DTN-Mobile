using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
{
    public class SyncLog
    {

        [Indexed(Name = "SyncCompPK", Order = 1, Unique = true), MaxLength(30)]
        public string SyncNodeId { set; get; }
        [Indexed(Name = "SyncCompPK", Order = 2, Unique = true)]
        public DateTime DateTimeStart { set; get; }
        public DateTime DateTimeComplete { set; get; }

        public SyncLog(){}

        public SyncLog(string pSyncNodeId, DateTime pDateTimeStart)
        {
            SyncNodeId = pSyncNodeId;
            DateTimeStart = pDateTimeStart;
        }

        public void SetDateTimeComplete(DateTime pDateTimeComplete)
        {
            DateTimeComplete = pDateTimeComplete;
        }

    }
}
