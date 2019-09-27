
namespace Generic.Storage.Repository
{
    public class BaseRepository
    {
        public string ConnectionString { get; }

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}