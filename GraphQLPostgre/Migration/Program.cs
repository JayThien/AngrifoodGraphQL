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

            var scriptFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 17), $"Scripts");
            Console.WriteLine(scriptFolderPath);
            EnsureDatabase.For.PostgresqlDatabase(connString);

            var upgradeBuilder = DeployChanges.To.PostgresqlDatabase(connString);
            upgradeBuilder
                .WithScriptsFromFileSystem
                (
                    scriptFolderPath, new FileSystemScriptOptions
                    {
                        IncludeSubDirectories = true
                    }
                );

            var upgrader = upgradeBuilder
                .WithTransactionPerScript()
                .WithVariablesDisabled().LogToAutodetectedLog()
                .Build();
            Console.WriteLine(upgrader);
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
