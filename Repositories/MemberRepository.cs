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

        public async Task<Member> Get(int memberID)
        {
            var parameters = new
            {
                MemberID = memberID
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                Member userInfo = await connection.QueryFirstAsync<Member>("dbo.GetMember", parameters, commandType: CommandType.StoredProcedure);
                return userInfo;
            }
        }

        public async Task<IEnumerable<Member>> GetAll(MemberViewModel parms)
        {
            var parameters = new
            {
                Active = parms.ActiveMembers
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    IEnumerable<Member> members = (IEnumerable<Member>)await connection.QueryAsync<Member>("dbo.GetMembers", parameters, commandType: CommandType.StoredProcedure);
                    return members;
                }
                catch(Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return null;
                }

            }
        }
    }
}

