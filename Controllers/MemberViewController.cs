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
        public async Task<IActionResult> GetAll([FromBody] GetMemberParms parms)
        {
            try
            {
                IEnumerable<MemberEntity> members = await _memberRepo.GetAll(parms);
                return this.Ok(members);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest();
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int memberID)
        {
            try
            {
                MemberEntity userInfo = await _memberRepo.Get(memberID);

                return this.Ok(userInfo);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateMemberParms parms)
        {
            try
            {
                await _memberRepo.Create(parms);
                return this.Ok("Success");
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest("There was an error creating the member profile");
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateMemberParms parms)
        {
            try
            {
                await _memberRepo.Update(parms);
                return this.Ok("Success");
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "MemberViewController threw an exception");
                return BadRequest("There was an error creating the member profile");
            }
        }


    }
}
