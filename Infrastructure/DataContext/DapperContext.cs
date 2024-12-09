using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string connectionString =
        "Server = localhost;Port=5432;Database = dapcruddb;Username = postgres;Password = 7070";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}