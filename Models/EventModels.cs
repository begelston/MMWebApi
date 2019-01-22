using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Models
{
    public class CreateEventParms
    {
        public int StatusID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string When { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public string PhotoURL { get; set; }
        public bool Active { get; set; }
        public int UserID {get;set;}
    }
    
    public class UpdateEventParms
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int StatusID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string When { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public string PhotoURL { get; set; }
        public bool Active { get; set; }        
    }
    public class GetEventByTypeParms
    {
        public int EventTypeID { get; set; }
        public DateTime StartRange { get; set; }
        public DateTime EndTime { get; set; }
    }
}
