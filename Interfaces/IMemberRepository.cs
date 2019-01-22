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
        Task<MemberEntity> Get(int memberID);
        Task<IEnumerable<MemberEntity>> GetAll(GetMemberParms parms);
        Task<bool> Create(CreateMemberParms parms);
        Task<bool> Update(UpdateMemberParms parms);
    }
}
