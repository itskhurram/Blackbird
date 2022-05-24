using Blackbird.Domain.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class BaseRepository : IBaseRepository {
        private string ConnectionString { get; set; }
        private readonly IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration) {
            _configuration = configuration;
            ConnectionString = _configuration["ConnectionStrings:BirdConnectionString"];
        }
        public string GetConnectionString() {
            return ConnectionString;
        }
        public NpgsqlConnection GetConnection() {
            NpgsqlConnection npgSqlConnection = new(ConnectionString);
            npgSqlConnection.Open();
            return npgSqlConnection;
        }
        public NpgsqlCommand GetSqlCommand(NpgsqlConnection npgSqlConnection, string npgSqlCommandName, bool isStoredProcedure) {
            if (isStoredProcedure)
                return GetProcedureSqlCommand(npgSqlConnection, npgSqlCommandName);
            else
                return GetFunctionSqlCommand(npgSqlConnection, npgSqlCommandName);
        }
        private NpgsqlCommand GetFunctionSqlCommand(NpgsqlConnection npgSqlConnection, string npgSqlCommandName) {
            NpgsqlCommand npgSqlCommand = new("SELECT * FROM " + npgSqlCommandName, npgSqlConnection) {
                CommandType = CommandType.Text,
                CommandTimeout = Common.Conversion.ToInt(_configuration["ConnectionStrings:DefaultCommandTimeOutDurationSeconds"])
            };
            return npgSqlCommand;
        }
        private NpgsqlCommand GetProcedureSqlCommand(NpgsqlConnection npgSqlConnection, string npgSqlCommandName) {
            NpgsqlCommand npgSqlCommand = new("CALL " + npgSqlCommandName, npgSqlConnection) {
                CommandType = CommandType.Text,
                CommandTimeout = Common.Conversion.ToInt(_configuration["ConnectionStrings:DefaultCommandTimeOutDurationSeconds"])
            };
            return npgSqlCommand;
        }
    }
}
