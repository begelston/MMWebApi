using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MMWebApi.Configuration;
using MMWebApi.Entities;
using MMWebApi.Interfaces;
using Dapper;
using MMWebApi.Models;

namespace MMWebApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public string ConnectionString { get; private set; }
        private IDbConnection _connection;

        public MemberRepository(IOptions<SqlDBConfiguration> settings)
        {
            ConnectionString = settings.Value.LocalDatabaseConnection;// settings.Value.DatabaseConnection;
            //_connection = new SqlConnection(settings.Value.DatabaseConnection);
            _connection = new SqlConnection(settings.Value.LocalDatabaseConnection);
        }

        public MemberRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<MemberEntity> Get(int memberID)
        {
            var parameters = new
            {
                MemberID = memberID
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                MemberEntity userInfo = await connection.QueryFirstAsync<MemberEntity>("dbo.GetMember", parameters, commandType: CommandType.StoredProcedure);
                return userInfo;
            }
        }

        public async Task<IEnumerable<MemberEntity>> GetAll(GetMemberParms parms)
        {
            var parameters = new
            {
                Active = parms.ActiveMembers
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    IEnumerable<MemberEntity> members = (IEnumerable<MemberEntity>)await connection.QueryAsync<MemberEntity>("dbo.GetMembers", parameters, commandType: CommandType.StoredProcedure);
                    return members;
                }
                catch(Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return null;
                }

            }
        }

        public async Task<bool> Create(CreateMemberParms parms)
        {
            var parameters = new
            {
                MemberTypeID = parms.MemberTypeID,                
                FirstName = parms.FirstName,
                LastName = parms.LastName,
                MiddleInitial = parms.MiddleInitial,
                NickName = parms.NickName,
                Address1 = parms.Address1,                
                City = parms.City,
                State = parms.State,
                Zip = parms.Zip,
                Email = parms.Email,
                PhoneNumber1 = parms.PhoneNumber1,
                PhoneType1 = parms.PhoneType1,
                PhoneNumber2 = parms.PhoneNumber2,
                PhoneType2 = parms.PhoneType2,
                PhotoURL = parms.PhotoURL,
                MemberNote = parms.MemberNote,
                Active = parms.Active,
                CreatedByID = parms.CreatedByID
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    bool ok = 1 == (int)await connection.ExecuteAsync("dbo.CreateMember", parameters, commandType: CommandType.StoredProcedure);
                    return ok;
                }
                catch (Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return false;
                }

            }
        }

        public async Task<bool> Update(UpdateMemberParms parms)
        {
            var parameters = new
            {
                MemberID = parms.MemberID,
                UpdatedByID = parms.UpdatedByID,
                MemberTypeID = parms.MemberTypeID,
                FirstName = parms.FirstName,
                LastName = parms.LastName,
                MiddleInitial = parms.MiddleInitial,
                NickName = parms.NickName,
                Address1 = parms.Address1,
                City = parms.City,
                State = parms.State,
                Zip = parms.Zip,
                Email = parms.Email,
                PhoneNumber1 = parms.PhoneNumber1,
                PhoneType1 = parms.PhoneType1,
                PhoneNumber2 = parms.PhoneNumber2,
                PhoneType2 = parms.PhoneType2,
                PhotoURL = parms.PhotoURL,
                MemberNote = parms.MemberNote,
                Active = parms.Active,                
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    bool ok = 1 == (int)await connection.ExecuteAsync("dbo.UpdateMember", parameters, commandType: CommandType.StoredProcedure);
                    return ok;
                }
                catch (Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return false;
                }

            }        
        }
    }
}

