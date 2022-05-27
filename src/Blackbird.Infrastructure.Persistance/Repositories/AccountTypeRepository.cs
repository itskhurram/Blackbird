using Blackbird.Domain;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Interfaces.Base;
using Blackbird.Infrastructure.Common;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class AccountTypeRepository : IAccountTypeRepository {
        private readonly IBaseRepository _baseRepository;
        public AccountTypeRepository(IBaseRepository baseRepository) {
            _baseRepository = baseRepository;
        }
        #region SQL Procedures
        protected const string GETACCOUNTTYPES = "master.getaccounttypes(@isactive)";
        #endregion SQL Procedures

        #region Parameters
        protected const string ACCOUNTTYPEID = "AccountTypeId";
        protected const string ACCOUNTTYPENAME = "AccountTypeName";
        protected const string ISACTIVE = "IsActive";
        #endregion Parameters

        #region Functions
        private static AccountType Mapper(IDataReader reader) {
            AccountType accountType = new() {
                AccountTypeId = (reader[ACCOUNTTYPEID] != DBNull.Value) ? Conversion.ToInt(reader[ACCOUNTTYPEID]) : 0,
                AccountTypeName = (reader[ACCOUNTTYPENAME] != DBNull.Value) ? Conversion.ToString(reader[ACCOUNTTYPENAME]) : string.Empty,
                IsActive = (reader[ISACTIVE] != DBNull.Value) && Conversion.ToBool(reader[ISACTIVE]),
            };
            return accountType;
        }
        public async Task<IList<AccountType>> GetAllAccountTypes(bool? isActive = null) {
            IList<AccountType> accountTypeList = new List<AccountType>();
            using NpgsqlConnection sqlConnection = _baseRepository.GetConnection();
            using (NpgsqlCommand sqlCommand = _baseRepository.GetSqlCommand(sqlConnection, GETACCOUNTTYPES)) {
                sqlCommand.Parameters.AddWithValue(ISACTIVE, NpgsqlDbType.Boolean, isActive == null ? DBNull.Value : isActive);
                using var reader = await sqlCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync()) {
                    accountTypeList.Add(Mapper(reader));
                }
            }
            return accountTypeList;
        }
        #endregion Functions
    }
}
