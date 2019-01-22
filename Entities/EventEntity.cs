using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Entities
{
    public class EventEntity
    {
        public int EventID { get; set; }
        public int StatusID { get; set; }
        public int TypeID { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public int When { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Notes { get; set; }
        public int PhotoURL { get; set; }
        public int Active { get; set; }
        public int CreatedByID { get; set; }
        public int DateCreated { get; set; }
        public int ModifiedByID { get; set; }
        public int DateModified { get; set; }
    }
}
