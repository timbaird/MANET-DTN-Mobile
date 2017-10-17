using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
                          
{
    public class RemoveFlag
    {
        [PrimaryKey, Column("ItemId"), MaxLength(30)]
        public string ItemId { set; get; }
        [MaxLength(30)]
        public string RemoverId { set; get; }
        public DateTime DateTimeFlagged { set; get; }

        public RemoveFlag() { }

        public RemoveFlag(string pItemId, string pRemoverId, DateTime pDateTime)
        {
            ItemId = pItemId;
            RemoverId = pRemoverId;
            DateTimeFlagged = pDateTime;
        }
    }
}
