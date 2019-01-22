using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Entities
{
    public class MessageEntity
    {
        public int MessageID { get; set; }
        public int MessageTypeID { get; set; }
        public int SenderID { get; set; }
        public int TargetMemberID { get; set; }
        public int TargetGroupID { get; set; }
        public string Message { get; set; }
        public string PhotoURL { get; set; }
        public int VisibilityTypeID { get; set; }
        public int Active { get; set; }
        public DateTime BeginDisplayDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CreatedByID { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedByID { get; set; }
        public DateTime DateModified { get; set; }
    }
}
