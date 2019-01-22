using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Models
{
    public class CreateMessageParms
    {
        public int MessageTypeID { get; set; }
		public int SenderID { get; set; }
        public int TargetMemberID { get; set; }
        public int TargetGroupID { get; set; }
        public int Message { get; set; }
        public string PhotoURL { get; set; }
        public int VisibilityTypeID { get; set; }
        public bool Active { get; set; }
        public DateTime BeginDisplayDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CreatedByID { get; set; }
    }

    public class UpdateMessageParms
    {
        public int MessageID { get; set; }
        public int? MessageTypeID { get; set; }
        public int? SenderID { get; set; }
        public int? TargetMemberID { get; set; }
        public int? TargetGroupID { get; set; }
        public int? Message { get; set; }
        public string  PhotoURL { get; set; }
        public int? VisibilityTypeID { get; set; }
        public bool? Active { get; set; }
        public DateTime? BeginDisplayDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? CreatedByID { get; set; }
    }

    public class GetMessageByIDParms
    {
        public int MessageID { get; set; }
    }

    public class GetMessageByTypeParms
    {
        public int MessageTypeID { get; set; }
    }
    public class GetMessageByDateRangeParms
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
