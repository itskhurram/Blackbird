using Npgsql;

namespace Blackbird.Domain.Interfaces.Base {
    public interface IBaseRepository {
        string GetConnectionString();
        NpgsqlConnection GetConnection();
        NpgsqlCommand GetSqlCommand(NpgsqlConnection npgSqlConnection, string npgSqlCommandName, bool isStoredProcedure = false);
    }
}
