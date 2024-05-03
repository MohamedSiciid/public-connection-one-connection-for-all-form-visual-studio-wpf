using System.Data.SqlClient;
using System.Configuration;

public static class DatabaseHelper
{
    private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}