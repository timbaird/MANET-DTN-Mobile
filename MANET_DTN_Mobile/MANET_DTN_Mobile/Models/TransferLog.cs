using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
{
    public class TransferLog
    {
        [PrimaryKey, AutoIncrement]
        public int TransferId { set; get; }
        [MaxLength(30)]
        public string ItemId { set; get; }
        [MaxLength(1)]
        public int IsRemoveFlag { set; get; }
        [MaxLength(30)]
        public string TransToId { set; get; }
        [MaxLength(30)]
        public string TransFromId { set; get; }
        public DateTime DateTimeTransferred { set; get; }


        public TransferLog(){}

        public TransferLog(string pItemId, string pTransToId,
                           string pTransFromId, DateTime pDateTimeTransferred,
                           int pIsRemoveFlag = 0)
        {
            ItemId = pItemId;
            TransToId = pTransToId;
            TransFromId = pTransFromId;
            DateTimeTransferred = pDateTimeTransferred;
            IsRemoveFlag = pIsRemoveFlag;
        }
    }
}
