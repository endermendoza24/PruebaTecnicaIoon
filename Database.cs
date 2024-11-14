using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using IoonSistema;

public class Database
{
    private readonly string _connectionString;

    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

public class CommerceRepository
{
    private readonly Database _database;

    public CommerceRepository(Database database)
    {
        _database = database;
    }

    public IEnumerable<Commerce> GetAllCommerces()
    {
        using (var connection = _database.GetConnection())
        {
            return connection.Query<Commerce>("SELECT * FROM Commerce");
        }
    }

    public Commerce GetCommerceById(Guid commerceId)
    {
        using (var connection = _database.GetConnection())
        {
            return connection.QueryFirstOrDefault<Commerce>("SELECT * FROM Commerce WHERE CommerceId = @Id", new { Id = commerceId });
        }
    }

    public void AddCommerce(Commerce commerce)
    {
        using (var connection = _database.GetConnection())
        {
            var query = "INSERT INTO Commerce (CommerceId, CommerceName, Address, RUC, State) VALUES (@CommerceId, @CommerceName, @Address, @RUC, @State)";
            connection.Execute(query, commerce);
        }
    }
}
