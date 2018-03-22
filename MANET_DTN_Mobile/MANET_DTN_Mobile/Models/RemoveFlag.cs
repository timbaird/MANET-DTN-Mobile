using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
                          
{
    public class RemoveFlag
    {
        [PrimaryKey, Column("ItemId"), MaxLength(50)]
        public string ItemId { set; get; }
        [MaxLength(30)]
        public string OriginatorId { set; get; }
        public DateTime DateTimeFlagged { set; get; }

        public RemoveFlag() { }

        public RemoveFlag(string pItemId, string pOriginatorId, DateTime pDateTime)
        {
            ItemId = pItemId;
            OriginatorId = pOriginatorId;
            DateTimeFlagged = pDateTime;
        }


        public string ToJson()
        {
            // return string.Format("[Item: ItemId={0}, ItemType={1}, OriginatorId={2}, RecipientId={3}, Title={4}, Body={5}, DateTimeCreated={6}, Priority={7}]", ItemId, ItemType, OriginatorId, RecipientId, Title, Body, DateTimeCreated, Priority);
            var serialised = string.Format("'ItemId':'{0}', 'OriginatorId':'{1}', 'DateTimeFlagged':'{2}'",
                                           ItemId,  OriginatorId, DateTimeFlagged);


            return "{" + serialised + "}";
        }



    }
}
