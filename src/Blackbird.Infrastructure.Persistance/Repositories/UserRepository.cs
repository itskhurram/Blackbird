using Blackbird.Domain;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Interfaces.Base;
using Blackbird.Infrastructure.Common;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class UserRepository : IUserRepository {
        private readonly IBaseRepository _baseRepository;
        public UserRepository(IBaseRepository baseRepository) {
            _baseRepository = baseRepository;
        }
        #region SQL Procedures
        protected const string GETALLUSERS = @"""user"".getallusers(@isactive)";
        protected const string GETUSERBYID = @"""user"".getuserbyid(@userid)";
        protected const string PROC_USER_LOGIN = @"""user"".getuserbyid(@userid)";
        #endregion SQL Procedures

        #region Parameters
        protected const string USERID = "UserId";
        protected const string LOGINNAME = "LoginName";
        protected const string FIRSTNAME = "FirstName";
        protected const string LASTNAME = "LastName";
        protected const string LOGINPASSWORD = "LoginPassword";
        protected const string RATING = "rating";
        protected const string ISACTIVE = "IsActive";
        protected const string CREATEDBY = "CreatedBy";
        protected const string CREATEDDATE = "CreatedDate";
        protected const string UPDATEDBY = "UpdatedBy";
        protected const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters

        #region Functions
        private static User Mapper(IDataReader reader) {
            User userAccount = new() {
                UserId = (reader[USERID] != DBNull.Value) ? Conversion.ToInt(reader[USERID]) : 0,
                LoginName = (reader[LOGINNAME] != DBNull.Value) ? Conversion.ToString(reader[LOGINNAME]) : string.Empty,
                FirstName = (reader[FIRSTNAME] != DBNull.Value) ? Conversion.ToString(reader[FIRSTNAME]) : string.Empty,
                LastName = (reader[LASTNAME] != DBNull.Value) ? Conversion.ToString(reader[LASTNAME]) : string.Empty,
                Rating = (reader[RATING] != DBNull.Value) ? Conversion.ToDecimal(reader[RATING]) : 0,
                IsActive = (reader[ISACTIVE] != DBNull.Value) ? Conversion.ToBool(reader[ISACTIVE]) : false,
                CreatedBy = (reader[CREATEDBY] != DBNull.Value) ? Conversion.ToInt(reader[CREATEDBY]) : 0,
                CreatedDate = (reader[CREATEDDATE] != DBNull.Value) ? Conversion.ToDateTime(reader[CREATEDDATE]) : DateTime.MinValue,
                UpdatedBy = (reader[UPDATEDBY] != DBNull.Value) ? Conversion.ToInt(reader[UPDATEDBY]) : 0,
                UpdatedDate = (reader[UPDATEDDATE] != DBNull.Value) ? Conversion.ToDateTime(reader[UPDATEDDATE]) : DateTime.MinValue
            };
            return userAccount;
        }
        public async Task<IList<User>> GetAllUsers(bool? isActive = null) {
            IList<User> userList = new List<User>();
            using NpgsqlConnection sqlConnection = _baseRepository.GetConnection();
            using (NpgsqlCommand sqlCommand = _baseRepository.GetSqlCommand(sqlConnection, GETALLUSERS)) {
                sqlCommand.Parameters.AddWithValue(ISACTIVE, NpgsqlDbType.Boolean, isActive == null ? DBNull.Value : isActive);
                using var reader = await sqlCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync()) {
                    userList.Add(Mapper(reader));
                }
            }
            return userList;
        }
        public async Task<User> GetById(long userId) {
            try {
                User userAccount = new();
                using NpgsqlConnection sqlConnection = _baseRepository.GetConnection();
                using (NpgsqlCommand sqlCommand = _baseRepository.GetSqlCommand(sqlConnection, GETUSERBYID)) {
                    sqlCommand.Parameters.AddWithValue(USERID, NpgsqlDbType.Bigint, userId);
                    using var reader = await sqlCommand.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                        userAccount = Mapper(reader);
                }
                return userAccount;
            }
            finally { }
        }
        public async Task<User> Login(string loginName, string loginPassword) {
            try {
                User userAccount = new();
                using NpgsqlConnection sqlConnection = _baseRepository.GetConnection();
                using (NpgsqlCommand sqlCommand = _baseRepository.GetSqlCommand(sqlConnection, PROC_USER_LOGIN, false)) {
                    sqlCommand.Parameters.AddWithValue(LOGINNAME, NpgsqlDbType.Varchar, loginName);
                    sqlCommand.Parameters.AddWithValue(LOGINPASSWORD, NpgsqlDbType.Varchar, loginPassword);
                    using var reader = await sqlCommand.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                        userAccount = Mapper(reader);
                }
                return userAccount;
            }
            finally { }
        }

        public Task<User> Signup(User user) {
            throw new NotImplementedException();
        }
        #endregion Functions

    }

}
