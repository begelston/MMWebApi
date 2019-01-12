using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMWebApi.Entities;
using MMWebApi.Models;

namespace MMWebApi.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> Get(int memberID);
        Task<IEnumerable<Member>> GetAll(MemberViewModel parms);
    }
}
