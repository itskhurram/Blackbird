using Blackbird.Domain;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Interfaces.Base;
using Blackbird.Infrastructure.Common;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Blackbird.Infrastructure.Persistance.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly IBaseRepository _baseRepository;
        public CategoryRepository(IBaseRepository baseRepository) {
            _baseRepository = baseRepository;
        }
        #region SQL Procedures
        protected const string GETCATEGORIES = "master.getcategories(@isactive)";
        #endregion SQL Procedures

        #region Parameters
        protected const string CATEGORYID = "CategoryId";
        protected const string CATEGORYNAME = "CategoryName";
        protected const string ISACTIVE = "IsActive";
        #endregion Parameters

        #region Functions
        private static Category Mapper(IDataReader reader) {
            Category category = new() {
                CategoryId = (reader[CATEGORYID] != DBNull.Value) ? Conversion.ToInt(reader[CATEGORYID]) : 0,
                CategoryName = (reader[CATEGORYNAME] != DBNull.Value) ? Conversion.ToString(reader[CATEGORYNAME]) : string.Empty,
                IsActive = (reader[ISACTIVE] != DBNull.Value) && Conversion.ToBool(reader[ISACTIVE]),
            };
            return category;
        }
        public async Task<IList<Category>> GetAllCategories(bool? IsActive = null) {
            IList<Category> categoryList = new List<Category>();
            using NpgsqlConnection sqlConnection = _baseRepository.GetConnection();
            using (NpgsqlCommand sqlCommand = _baseRepository.GetSqlCommand(sqlConnection, GETCATEGORIES)) {
                sqlCommand.Parameters.AddWithValue(ISACTIVE, NpgsqlDbType.Boolean, IsActive == null ? DBNull.Value : IsActive);
                using var reader = await sqlCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync()) {
                    categoryList.Add(Mapper(reader));
                }
            }
            return categoryList;
        }
        #endregion Functions
    }
}
