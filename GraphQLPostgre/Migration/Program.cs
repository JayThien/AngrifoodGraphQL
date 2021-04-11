using DbUp;
using DbUp.Engine;
using DbUp.ScriptProviders;
using DbUp.Support;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.ModelContext;

namespace Migration
{
    class Program
    {
        private static IConfiguration _configuration;

        private static void Run()
        {
            var connString = _configuration.GetConnectionString("MyWebApiConection");
            //var createNewDb = _configuration.GetValue("CreateNewDb", false);

            var scriptFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 17), $"Scripts");
            //Console.WriteLine(scriptFolderPath);
            //Log.Logger?.Information($"MigrationDb: createNewDb={createNewDb}");
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production" /*&& createNewDb*/)
            {
                Log.Logger?.Information($"MigrationDb: ensure database created by using postgresdb metadata");
                EnsureDatabase.For.PostgresqlDatabase(connString);
            }

            var upgrader = DeployChanges
                .To
                .PostgresqlDatabase(connString)
                .WithScriptsFromFileSystem
                (
                    scriptFolderPath, new FileSystemScriptOptions
                    {
                        IncludeSubDirectories = true
                    }
                )
                .WithTransactionPerScript()
                .WithVariablesDisabled()
                .Build();
            //Console.WriteLine(upgrader);
            upgrader.PerformUpgrade();
        }
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Console.WriteLine("Starting to Migration");

            Run();

        }
    }
}
