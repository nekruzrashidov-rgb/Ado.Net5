using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private const string connectionString = "Host=localhost;Database=Yalla;Username=postgres;Password=07806634";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
