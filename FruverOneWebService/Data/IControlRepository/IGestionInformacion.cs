using Npgsql;

namespace Data.ControlRepository
{
    public interface IGestionInformacion
    {
        bool ConstruirConsulta(string query);
        NpgsqlDataReader ResolveQuerySelect(string query);
        bool InsertBD(string query);
        bool DeleteBD(string query);
        bool UpdateBD(string query);
    }
}
