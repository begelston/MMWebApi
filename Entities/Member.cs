using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Entities
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string NickName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhotoURL { get; set; }
        public string MemberNote { get; set; }
        public bool Active { get; set; }
        public int CreatedByID { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedByID { get; set; }
        public DateTime DateModified { get; set; }
    }
}
