using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMWebApi.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MMWebApi.Interfaces;
using MMWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MemberViewController : ControllerBase
    {
        ILogger<MemberViewController> Log { get; set; }
        IConfigurationRoot _configuration;
        IMemberRepository _memberRepo;

        public MemberViewController(IConfigurationRoot configuration,
            IMemberRepository userRepo,
            ILogger<MemberViewController> log)
        {
            _configuration = configuration;
            _memberRepo = userRepo;
            Log = log;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] MemberViewModel parms)
        {
            try
            {
                IEnumerable<Member> members = await _memberRepo.GetAll(parms);
                return this.Ok(members);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest();
            }
        }
        // GET: api/Default
        //[HttpGet("GetAll") ]
        //public async Task<IActionResult> GetAll(bool activeMembers)
        //{
        //    try
        //    {
        //        IEnumerable<Member> members = await _memberRepo.GetAll(activeMembers);
        //        return this.Ok(members);                
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.LogError(ex, "MemberViewController threw an exception");
        //        return BadRequest();
        //    }
        //}

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int memberID)
        {
            try
            {
                Member userInfo = await _memberRepo.Get(memberID);

                return this.Ok(userInfo);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest();
            }
        }

        //// POST api/values
        //[HttpPost ("GetMember")]
        //public async Task<IActionResult> Get([FromBody] MemberViewSearchParms searchParms)        
        //{
        //    try
        //    {
        //        Member userInfo = await _memberRepo.Get(searchParms);

        //        return this.Ok(userInfo);
        //    }
        //    catch(Exception ex)
        //    {
        //        Log.LogError(ex, "MemberViewController threw an exception");
        //        return BadRequest();
        //    }
            
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
