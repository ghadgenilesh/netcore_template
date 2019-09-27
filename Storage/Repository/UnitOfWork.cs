
namespace Generic.Storage.Repository
{
    using DbUp;
    using Interfaces;
    using Serilog;
    using System;
    using System.Reflection;

    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        protected ILogger Logger { get; }

        public UnitOfWork(ILogger logger, string connectionString) : base(connectionString)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            InitializeDatabaseUsingDbUp(connectionString);
        }

        private void InitializeDatabaseUsingDbUp(string connectionString)
        {
            //Logger.Information("Initializing database upgrade");
            //EnsureDatabase.For.SqlDatabase(ConnectionString);

            //var upgradeEngineBuilder = DeployChanges.To
            //                .SqlDatabase(connectionString, null)
            //                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            //                .WithTransaction();

            //var upgrader = upgradeEngineBuilder.Build();
            //if (upgrader.IsUpgradeRequired())
            //{
            //    Logger.Information("Performing database upgrade");
            //    upgrader.PerformUpgrade();
            //}
            //else
            //{
            //    Logger.Information("No upgrade required");
            //}
        }

        public string SayHi(string name)
        {
            return $"Hi {name}";
        }
    }
}
