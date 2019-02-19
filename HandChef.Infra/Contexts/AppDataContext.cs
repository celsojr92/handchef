using HandChef.Shared.Classes;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace OT.Hub.Infra.Contexts
{
    public class AppDataContext
    {
        public AppDataContext(IOptions<Settings> settings)
        {
            Connection = new MySqlConnection(settings.Value.ConnectionString);
        }

        public MySqlConnection Connection { get; private set; }
    }
}