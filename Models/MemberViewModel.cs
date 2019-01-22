using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMWebApi.Models
{
    public class GetMemberParms
    {
        public bool ActiveMembers { get; set; }
    }

    public class CreateMemberParms
    {
        [Required]
        public int CreatedByID { get; set; }
        [Required]
        public int MemberTypeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }        
        public string MiddleInitial { get; set; }
        public string NickName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber1 { get; set; }
        public int PhoneType1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public int PhoneType2 { get; set; }
        public string PhotoURL { get; set; }
        public string MemberNote { get; set; }
        public bool Active { get; set; }        
    }

    public class UpdateMemberParms
    {
        [Required]
        public int UpdatedByID { get; set; }
        [Required]
        public int MemberID { get; set; }        
        public int? MemberTypeID { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string NickName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber1 { get; set; }
        public int? PhoneType1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public int? PhoneType2 { get; set; }
        public string PhotoURL { get; set; }
        public string MemberNote { get; set; }
        public bool? Active { get; set; }
    }
}
