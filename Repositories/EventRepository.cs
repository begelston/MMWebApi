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
    public class EventRepository : IEventRepository
    {
        public string ConnectionString { get; private set; }
        private IDbConnection _connection;

        public EventRepository(IOptions<SqlDBConfiguration> settings)
        {
            ConnectionString = settings.Value.LocalDatabaseConnection;// settings.Value.DatabaseConnection;
            //_connection = new SqlConnection(settings.Value.DatabaseConnection);
            _connection = new SqlConnection(settings.Value.LocalDatabaseConnection);
        }

        public EventRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<EventEntity> Get(int eventID)
        {
            var parameters = new
            {
                EventID = eventID
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                EventEntity userInfo = await connection.QueryFirstAsync<EventEntity>("dbo.GetEvent", parameters, commandType: CommandType.StoredProcedure);
                return userInfo;
            }
        }

        public async Task<IEnumerable<EventEntity>> GetAll(GetEventByTypeParms parms)
        {
            var parameters = new
            {
                EventTypeID = parms.EventTypeID,
                StartRange = parms.StartRange,
                EndTime = parms.EndTime
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    IEnumerable<EventEntity> members = (IEnumerable<EventEntity>)await connection.QueryAsync<EventEntity>("dbo.GetEvent", parameters, commandType: CommandType.StoredProcedure);
                    return members;
                }
                catch (Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return null;
                }

            }
        }

        public async Task<bool> Create(CreateEventParms parms)
        {
            var parameters = new
            {
            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    bool ok = 1 == (int)await connection.ExecuteAsync("dbo.CreateEvent", parameters, commandType: CommandType.StoredProcedure);
                    return ok;
                }
                catch (Exception ex)
                {
                    Console.Write(string.Format("Error: {0}", ex.Message));
                    return false;
                }

            }
        }

        public async Task<bool> Update(UpdateEventParms parms)
        {
            var parameters = new
            {

            };

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    bool ok = 1 == (int)await connection.ExecuteAsync("dbo.UpdateEvent", parameters, commandType: CommandType.StoredProcedure);
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
