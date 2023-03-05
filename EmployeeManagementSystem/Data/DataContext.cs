using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EmployeeManagementSystem.Data
{
    public class DataContext:DbContext
    {
        public DataContext() 
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = GetConfiguration();
            string connection = configuration.GetSection("Data").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connection);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DbSet<Employees> Employees { get; set; }
    }
}
